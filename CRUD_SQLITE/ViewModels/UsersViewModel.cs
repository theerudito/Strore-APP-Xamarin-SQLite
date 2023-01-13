

using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace CRUD_SQLITE.ViewModels
{
    public class UsersViewModel : BaseViewModel
    {
        #region CONSTRUCTOR
        public UsersViewModel(INavigation navigation)
        {
            Navigation = navigation;
            Get_ALL_Users();
        }
        #endregion


        #region VARIABLES
        string _Text;
        #endregion


        #region OBJETOS
        public string Text
        {
            get { return _Text; }
            set { SetValue(ref _Text, value); }
        }
        #endregion


        #region METODOS ASYNC
        public async Task Get_ALL_Users()
        {

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
