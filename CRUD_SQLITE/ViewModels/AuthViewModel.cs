using CRUD_SQLITE.Context;
using CRUD_SQLITE.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace CRUD_SQLITE.ViewModels
{
    class AuthViewModel : BaseViewModel
    {
        DB.SQLite_Config connection = new DB.SQLite_Config();
        DB_Context _dbContext = new DB_Context();

        #region  VARIABLES
        private string _email;
        private string _password;
        private string _user;
        ObservableCollection<MAuth> _List_Users;
        private StackLayout showRegister;
        private StackLayout showLogin;
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

            if (query == null)
            {
                await DisplayAlert("Error", "User does not exist", "Ok");
            }

            if (!BCrypt.Net.BCrypt.Verify(query.Password, Password))
            {
                await DisplayAlert("Error", "Password or email is wrong", "Ok");
            }
            else
            {
                await DisplayAlert("Success", "Welcome", "Ok");
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
                await DisplayAlert("Register", "Register Success", "Ok");
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