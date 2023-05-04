using Microsoft.EntityFrameworkCore;
using MyStore.Context;
using MyStore.Models;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MyStore.ViewModels
{
    internal class UsersViewModel : BaseViewModel
    {
        private DB_Context _dbContext = new DB_Context();

        public Command ReloadUserCommand { get; }

        private ObservableCollection<MAuth> _List_Users;

        public UsersViewModel(INavigation navigation)
        {
            Navigation = navigation;

            Task.Run(async () => await GetAllUsersAsync());

            ReloadUserCommand = new Command(async () => await GetAllUsersAsync());
        }

        public ObservableCollection<MAuth> List_Users
        {
            get { return _List_Users; }
            set
            {
                _List_Users = value;
                OnPropertyChanged();
            }
        }

        public async Task GetAllUsersAsync()
        {
            IsBusy = true;

            try
            {
                var result = await _dbContext.Auth.ToListAsync();

                List_Users = new ObservableCollection<MAuth>(result);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = !IsBusy;
            }
        }

        public bool Login(string email, string password)
        {
            throw new NotImplementedException();
        }

        public bool Register(string name, string email, string password)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteUser(MAuth auth)
        {
            var result = await _dbContext.Auth.FirstOrDefaultAsync(user => user.IdAuth == auth.IdAuth);
            if (result != null)
            {
                if (await DisplayAlert("Delete User", "Are you sure you want to delete this user?", "Yes", "No"))
                {
                    _dbContext.Auth.Remove(result);
                    await _dbContext.SaveChangesAsync();
                    SecureStorage.RemoveAll();
                    await GetAllUsersAsync();
                }
            }
        }

        public async Task UpdateUser()
        {
            await DisplayAlert("infor", "Deleted", "Ok");
        }

        public async Task goUpdateUser()
        {
            await DisplayAlert("infor", "goUpdate", "Ok");
        }

        public ICommand btnGoUpdateCommand => new Command(async () => await goUpdateUser());
        public ICommand btnDeleteCommand => new Command<MAuth>(async (auth) => await DeleteUser(auth));
        public ICommand btnUpdateCommand => new Command(async () => await goUpdateUser());
    }
}