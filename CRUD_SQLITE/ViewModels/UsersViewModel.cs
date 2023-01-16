using CRUD_SQLITE.Models;
using CRUD_SQLITE.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace CRUD_SQLITE.ViewModels
{
    internal class UsersViewModel : BaseViewModel, IAuth
    {
        DB.SQLite_Config connection = new DB.SQLite_Config();

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


        public Task<IEnumerable<MAuth>> GetAllUsersAsync()
        {
            var db = connection.openConnection();

            var getUsers = "SELECT * FROM Auth";

            var result = db.Query<MAuth>(getUsers);

            List_Users = new ObservableCollection<MAuth>(result);

            return Task.FromResult<IEnumerable<MAuth>>(result);
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
            var db = connection.openConnection();
            var deleteUser = "DELETE FROM AUTH WHERE Id =" + auth.Id;

            db.Execute(deleteUser);
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
