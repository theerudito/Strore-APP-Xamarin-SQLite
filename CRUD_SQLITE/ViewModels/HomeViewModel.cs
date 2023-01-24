using CRUD_SQLITE.Models;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace CRUD_SQLITE.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        DB.SQLite_Config connection = new DB.SQLite_Config();

        #region CONSTRUCTOR
        public HomeViewModel(INavigation navigation)
        {
            Navigation = navigation;
            Get_Company();
        }
        #endregion

        #region VARIABLES
        private string _Version = "v1.1.0";
        private string _NameStore;
        private string _NameOwner;
        private string GitHub = "https://github.com/theerudito";
        private string Instagram = "https://www.instagram.com/theerudito";
        private string Twitter = "https://twitter.com/theerudito";
        private string Web = "https://byerudito.web.app/";
        private string Linkedin = "https://www.linkedin.com/in/theerudito";
        #endregion

        #region OBJECTS
        public string Name
        {
            get { return _NameStore; }
            set { SetValue(ref _NameStore, value); }
        }

        public string Owner
        {
            get { return _NameOwner; }
            set { SetValue(ref _NameOwner, value); }
        }
        public string Version
        {
            get { return _Version; }
            set { SetValue(ref _Version, value); }
        }
        #endregion


        #region METHODS
        public async Task Get_Company()
        {
            var RUC = "1234567890";
            var db = connection.openConnection();
            //var queryFindCompany = "SELECT * FROM MCompany WHERE RUC = " + RUC;
            var user = db.Table<MCompany>().Where(c => c.RUC == RUC).FirstOrDefault();
            if (user != null)
            {
                Name = $"Name Store: {user.NameCompany}";
                Owner = $"Welcome: {user.NameOwner}";
            }
        }


        public async Task Go_GitHub()
        {
            await Launcher.OpenAsync(GitHub);
        }
        public async Task Go_Instagram()
        {
            await Launcher.OpenAsync(Instagram);
        }
        public async Task Go_Twitter()
        {
            await Launcher.OpenAsync(Twitter);
        }
        public async Task Go_My_Web()
        {
            await Launcher.OpenAsync(Web);
        }
        public async Task Go_Linkedin()
        {
            await Launcher.OpenAsync(Linkedin);
        }
        #endregion

        #region COMMANDS
        public ICommand btnGitHub => new Command(async () => await Go_GitHub());
        public ICommand btnInstagram => new Command(async () => await Go_Instagram());
        public ICommand btnTwitter => new Command(async () => await Go_Twitter());
        public ICommand btnWeb => new Command(async () => await Go_My_Web());
        public ICommand btnLinkedin => new Command(async () => await Go_Linkedin());
        #endregion
    }


}

