﻿using Microsoft.EntityFrameworkCore;
using MyStore.Context;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MyStore.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        private DB_Context _dbCcontext = new DB_Context();

        #region CONSTRUCTOR

        public HomeViewModel(INavigation navigation)
        {
            Navigation = navigation;
            Get_Company();
        }

        #endregion CONSTRUCTOR

        #region VARIABLES

        private string _Version = "v1.2.0";
        private string _NameStore;
        private string _NameOwner;
        private readonly string GitHub = "https://github.com/theerudito";
        private readonly string Instagram = "https://www.instagram.com/theerudito";
        private readonly string Twitter = "https://twitter.com/theerudito";
        private readonly string Web = "https://byerudito.web.app/";
        private readonly string Linkedin = "https://www.linkedin.com/in/theerudito";
        private readonly string LocalStorageUser = "user";

        #endregion VARIABLES

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

        #endregion OBJECTS

        #region METHODS

        public async Task Get_Company()
        {
            var auth = await SecureStorage.GetAsync(LocalStorageUser);
            var id = 1;
            var user = await _dbCcontext.Company.FirstOrDefaultAsync(com => com.IdCompany == id);
            if (user != null)
            {
                Name = $"Name Store: {user.NameCompany}";
                Owner = auth == null ? $"Welcome: {user.NameOwner}" : $"Welcome: {auth}";
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

        #endregion METHODS

        #region COMMANDS

        public ICommand btnGitHub => new Command(async () => await Go_GitHub());
        public ICommand btnInstagram => new Command(async () => await Go_Instagram());
        public ICommand btnTwitter => new Command(async () => await Go_Twitter());
        public ICommand btnWeb => new Command(async () => await Go_My_Web());
        public ICommand btnLinkedin => new Command(async () => await Go_Linkedin());

        #endregion COMMANDS
    }
}