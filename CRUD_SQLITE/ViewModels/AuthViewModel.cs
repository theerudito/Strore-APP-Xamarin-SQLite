using CRUD_SQLITE.Models;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace CRUD_SQLITE.ViewModels
{
    class AuthViewModel : BaseViewModel
    {
        DB.SQLite_Config connection = new DB.SQLite_Config();

        #region  VARIABLES
        private string _email;
        private string _password;
        private string _name;
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
        public string Name
        {
            get { return _name; }
            set { SetValue(ref _name, value); }
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
            var db = connection.openConnection();
            var user = db.Table<MAuth>().Where(u => u.Email == Email && u.Password == Password).FirstOrDefault();
            if (user != null)
            {
                await DisplayAlert("Success", "User Logged In", "Ok");
                Name = "";
                Email = "";
                Password = "";
            }
            else
            {
                await DisplayAlert("Error", "Email or Password is incorrect", "Ok");
            }
        }

        public async Task Register()
        {
            var db = connection.openConnection();
            var user = db.Table<MAuth>().Where(u => u.Email == Email).FirstOrDefault();

            if (user == null)
            {
                var userRegister = new MAuth()
                {
                    Name = Name,
                    Email = Email,
                    Password = Password
                };

                db.Insert(userRegister);
                await DisplayAlert("Success", "User Registered", "Ok");
                Name = "";
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