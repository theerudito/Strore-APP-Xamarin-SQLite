using CRUD_SQLITE.Models;
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
        private bool _StackLoyoud_Login;
        private bool _StackLoyoud_Register;
        #endregion

        #region  OBJECTS
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
        public bool StackLoyoud_Login
        {
            get { return _StackLoyoud_Login; }
            set { SetValue(ref _StackLoyoud_Login, value); }
        }
        public bool StackLoyoud_Register
        {
            get { return _StackLoyoud_Login; }
            set { SetValue(ref _StackLoyoud_Login, value); }
        }

        #endregion


        #region CONSTRUCTOR
        public AuthViewModel(INavigation navigation)
        {
            Navigation = navigation;
        }
        #endregion



        #region METHODS
        public async Task Login()
        {
            var db = connection.openConnection();
            var user = db.Table<Auth>().Where(u => u.Email == Email && u.Password == Password).FirstOrDefault();

            if (user != null)
            {
                await DisplayAlert("Success", "User Logged In", "Ok");
            }
            else
            {
                await DisplayAlert("Error", "Email or Password is incorrect", "Ok");
            }


        }
        public async Task show_Login()
        {
            StackLoyoud_Register = false;
        }
        public async Task Register()
        {
            var db = connection.openConnection();
            var sql = "SELECT * FROM Auth WHERE Email = '" + Email + "'";
            var result = db.Query<Auth>(sql);
            if (result.Count == 0)
            {
                var sql2 = "INSERT INTO Auth (Name, Email, Password) VALUES ('" + Name + "', '" + Email + "', '" + Password + "')";
                db.Execute(sql2);
                await DisplayAlert("Success", "User Registered", "Ok");
            }
            else
            {
                await DisplayAlert("Error", "Email already exists", "Ok");
            }
        }
        public async Task show_Register()
        {
            StackLoyoud_Login = false;
        }
        #endregion


        #region COMMANDS
        public ICommand btnLoginCommand => new Command(async () => await Login());
        public ICommand btnShowRegisterCommand => new Command(async () => await show_Login());
        public ICommand btnRegisterCommand => new Command(async () => await Register());
        public ICommand LoginCommand => new Command(async () => await show_Register());
        #endregion 
    }
}