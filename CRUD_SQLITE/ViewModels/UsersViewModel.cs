using CRUD_SQLITE.Views;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace CRUD_SQLITE.ViewModels
{
    public class UsersViewModel : BaseViewModel
    {
        DB.SQLite_Config connection = new DB.SQLite_Config();
        #region CONSTRUCTOR
        public UsersViewModel(INavigation navigation)
        {
            Navigation = navigation;
            Get_ALL_Users();
        }
        #endregion


        #region VARIABLES
        string _Text;
        ObservableCollection<Auth> _List_Users;
        #endregion


        #region OBJETOS
        public ObservableCollection<Auth> List_Users
        {
            get { return _List_Users; }
            set
            {
                SetValue(ref _List_Users, value);
                OnpropertyChanged();
            }
        }
        #endregion


        #region METODOS ASYNC
        public async Task Get_ALL_Users()
        {
            var db = connection.openConnection();
            var sql = "SELECT * FROM Auth";

            var result = db.Query<Auth>(sql);

            List_Users = new ObservableCollection<Auth>(result);
        }
        public async Task Delete_User()
        {

        }
        public async Task Update_User()
        {

        }
        public async Task Admin()
        {

        }
        #endregion


        #region METODOS SIMPLE
        public void MetodoSimple()
        {

        }
        #endregion


        #region COMANDOS
        public ICommand btnDeleteUser => new Command(async () => await Delete_User());
        public ICommand btnUpdateUser => new Command(async () => await Update_User());
        public ICommand btnSuperUser => new Command(async () => await Admin());
        #endregion
    }
}
