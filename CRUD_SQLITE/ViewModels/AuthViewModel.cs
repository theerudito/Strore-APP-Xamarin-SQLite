using CRUD_SQLITE.Context;
using CRUD_SQLITE.Models;
using CRUD_SQLITE.Views;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace CRUD_SQLITE.ViewModels
{
    class AuthViewModel : BaseViewModel
    {
        DB_Context _dbContext = new DB_Context();

        #region  VARIABLES
        private string _email;
        private string _password;
        private string _user;
        ObservableCollection<MAuth> _List_Users;
        private StackLayout showRegister;
        private StackLayout showLogin;
        private readonly string LocalStorageUser = "user";
        private readonly string LocalStorageToken = "token";
        #endregion

        #region  OBJECTS
        public ObservableCollection<MAuth> List_Users
        {
            get { return _List_Users; }
            set
            {
                SetValue(ref _List_Users, value);
                OnpropertyChanged();
            }
        }
        public string User
        {
            get { return _user; }
            set { SetValue(ref _user, value); }
        }
        public string Email
        {
            get { return _email; }
            set { _email = value; OnPropertyChanged(); }
        }
        public string Password
        {
            get { return _password; }
            set { SetValue(ref _password, value); }
        }
        #endregion


        #region CONSTRUCTOR
        public AuthViewModel(INavigation navigation, StackLayout showRegister, StackLayout showLogin)
        {
            showRegister.IsVisible = false;
            Navigation = navigation;
            this.showRegister = showRegister;
            this.showLogin = showLogin;
        }

        #endregion

        #region METHODS
        public async Task Login()
        {
            var query = await _dbContext.Auth.FirstOrDefaultAsync(user => user.Email == Email);

            if (query != null)
            {
                // check the password
                if (BCrypt.Net.BCrypt.Verify(Password, query.Password))
                {
                    await DisplayAlert("Login", "Welcome " + query.User, "Ok");
                    await Xamarin.Essentials.SecureStorage.SetAsync(LocalStorageUser, query.User);
                    //await Navigation.PushAsync(new AppShell());
                    // navegar a la pagina principal AppShell
                    NavigationPage navigationPage = new NavigationPage(new AppShell());

                    User = "";
                    Email = "";
                    Password = "";
                }
                else
                {
                    await DisplayAlert("Login", "Password or Email is Wrong", "Ok");
                }
            }
            else
            {
                await DisplayAlert("Login", "User not found", "Ok");
            }
        }



        public async Task Register()
        {
            var query = await _dbContext.Auth.FirstOrDefaultAsync(user => user.Email == Email);

            if (query == null)
            {
                var user = new MAuth()
                {
                    User = User,
                    Email = Email,
                    Password = BCrypt.Net.BCrypt.HashPassword(Password)
                };

                _dbContext.Auth.Add(user);
                await _dbContext.SaveChangesAsync();
                await DisplayAlert("Register", query.User, "Ok");
                await Xamarin.Essentials.SecureStorage.SetAsync(LocalStorageUser, query.User);
                await Navigation.PushAsync(new Home());
                User = "";
                Email = "";
                Password = "";
            }
            else
            {
                await DisplayAlert("Error", "Email already exists", "Ok");
            }

        }
        public void show_Login()
        {
            showRegister.IsVisible = false;
            showLogin.IsVisible = true;
        }
        public void show_Register()
        {
            showRegister.IsVisible = true;
            showLogin.IsVisible = false;
        }

        #endregion


        #region COMMANDS
        public ICommand btnLoginCommand => new Command(async () => await Login());
        public ICommand btnShowRegisterCommand => new Command(show_Login);
        public ICommand btnRegisterCommand => new Command(async () => await Register());
        public ICommand btnShowLoginCommand => new Command(show_Register);
        #endregion 
    }
}