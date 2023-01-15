using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace CRUD_SQLITE.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        #region CONSTRUCTOR
        public HomeViewModel(INavigation navigation)
        {
            Navigation = navigation;
            Get_Name_Store();
            Get_Name_Owner();
        }
        #endregion

        #region VARIABLES
        private string _NameStore;
        public string _NameOwner;
        public string GitHub = "https://github.com/theerudito";
        public string Instagram = "https://www.instagram.com/theerudito";
        public string Twitter = "https://twitter.com/theerudito";
        public string Web = "https://byerudito.web.app/";
        public string Linkedin = "https://www.linkedin.com/in/theerudito";
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
        #endregion


        #region METHODS
        public async Task Get_Name_Store()
        {
            Name = "Erudito Dev";
        }
        public async Task Get_Name_Owner()
        {
            Name = "Welcome: Jorge Loor";
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

