using Microsoft.EntityFrameworkCore;
using MyStore.Context;
using MyStore.ViewModels;
using MyStore.Views;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MyStore
{
    public partial class App : Application
    {
        private readonly string _localStorageToken = "token";

        public void ShowAppShell()
        {
            if (string.IsNullOrEmpty(SecureStorage.GetAsync(_localStorageToken).Result))
            {
                MainPage = new NavigationPage(new ViewAuth());
            }
            else
            {
                MainPage = new AppShell();
            }
        }

        public App()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            var _dbCcontext = new DB_Context();

            _dbCcontext.Database.Migrate();

            InitialValues.CreateDataInitial();

            InitializeComponent();

            ShowAppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}