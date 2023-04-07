using CRUD_SQLITE.Context;
using CRUD_SQLITE.Models;
using CRUD_SQLITE.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace CRUD_SQLITE.ViewModels
{
    internal class UsersViewModel : BaseViewModel, IAuth
    {
        DB_Context _dbContext = new DB_Context();

        ObservableCollection<MAuth> _List_Users;


        public UsersViewModel(INavigation navigation)
        {
            Navigation = navigation;
            GetAllUsersAsync();
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


        public async Task<IEnumerable<MAuth>> GetAllUsersAsync()
        {
            var result = await _dbContext.Auth.ToListAsync();

            List_Users = new ObservableCollection<MAuth>(result);

            return result;
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
