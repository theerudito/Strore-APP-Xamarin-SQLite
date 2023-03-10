using Android.Content;
using CRUD_SQLITE.Context;
using CRUD_SQLITE.DB;
using CRUD_SQLITE.Models;
using CRUD_SQLITE.Views;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace CRUD_SQLITE.ViewModels
{
    public class ClientViewModel : BaseViewModel
    {
        DB_Context _dbContext = new DB_Context();



        #region VARIABLES
        ObservableCollection<MClient> _List_client;
        public bool _goEditing = true;
        #endregion

        #region CONSTRUCTOR
        public ClientViewModel(INavigation navigation)
        {
            Navigation = navigation;
            GetAllClientAsync();
        }
        #endregion

        #region OBJECTS
        public ObservableCollection<MClient> List_Clients
        {
            get { return _List_client; }
            set
            {
                _List_client = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region METHODS
        public async Task<List<MClient>> GetAllClientAsync()
        {
            var result = await _dbContext.Client.ToListAsync();
            List_Clients = new ObservableCollection<MClient>(result);
            return result;
        }
        public async Task go_Update_Client(MClient client)
        {
            await Navigation.PushAsync(new Add_Client(client, _goEditing));
        }
        public async Task go_New_Client(MClient client)
        {
            await Navigation.PushAsync(new Add_Client(client, _goEditing));
        }
        public async Task<bool> deleteClientAsync(MClient client)
        {
            var result = await _dbContext.Client.FirstOrDefaultAsync(cli => cli.IdClient == client.IdClient);
            if (result != null)
            {
                // hacer una alerta de confirmacion
                if (await DisplayAlert("Delete Client", "Are you sure you want to delete this client?", "Yes", "No"))
                {
                    _dbContext.Client.Remove(result);
                    await _dbContext.SaveChangesAsync();
                    await GetAllClientAsync();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }
        #endregion

        #region COMMANDS
        public ICommand btnDeleteClient => new Command<MClient>(async (cli) => await deleteClientAsync(cli));
        public ICommand btnGoNewClient => new Command<MClient>(async (cli) => await go_New_Client(cli));
        public ICommand btnGoUpdateClient => new Command<MClient>(async (cli) => await go_Update_Client(cli));
        public ICommand btnLeftClient => new Command(async () => await DisplayAlert("info", "prew", "ok"));
        public ICommand btnRightClient => new Command(async () => await DisplayAlert("info", "next", "ok"));
        #endregion

    }
}

