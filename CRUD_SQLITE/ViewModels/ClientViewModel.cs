using Microsoft.EntityFrameworkCore;
using MyStore.Context;
using MyStore.Models;
using MyStore.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MyStore.ViewModels
{
    public class ClientViewModel : BaseViewModel
    {
        private DB_Context _dbContext = new DB_Context();
        public Command ReloadClients { get; }

        #region VARIABLES

        private ObservableCollection<MClient> _List_client;
        public bool _goEditing = true;
        private string _searchTextClient;

        #endregion VARIABLES

        #region CONSTRUCTOR

        public ClientViewModel(INavigation navigation)
        {
            Navigation = navigation;
            GetAllClientAsync();

            ReloadClients = new Command(async () => await GetAllClientAsync());
        }

        #endregion CONSTRUCTOR

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

        public string SearchTextClient
        {
            get => _searchTextClient;
            set => _searchTextClient = value;
        }

        #endregion OBJECTS

        #region METHODS

        public async Task GetAllClientAsync()
        {
            IsBusy = true;
            try
            {
                InitialValues.CreateDataInitial();
                var result = await _dbContext.Client.ToListAsync();
                List_Clients = new ObservableCollection<MClient>(result);
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

        public async Task getOnClient()
        {
            List<MClient> clients = new List<MClient>();

            var searchingClient = await _dbContext.Client
                                .Where(c => c.FirstName.StartsWith(SearchTextClient.Trim().ToUpper())
                                    || c.LastName.StartsWith(SearchTextClient.Trim().ToUpper())
                                    || c.DNI.StartsWith(SearchTextClient.Trim().ToUpper())).ToListAsync();

            if (searchingClient.Count > 0)
            {
                foreach (var client in searchingClient)
                {
                    var list = new MClient
                    {
                        IdClient = client.IdClient,
                        DNI = client.DNI,
                        FirstName = client.FirstName,
                        LastName = client.LastName,
                        Direction = client.Direction,
                        City = client.City,
                        Email = client.Email,
                        Phone = client.Phone,
                    };

                    clients.Add(list);
                }
                List_Clients = new ObservableCollection<MClient>(clients);
            }
            else
            {
                await DisplayAlert("Error", "Not Exits Client", "ok");
            }
        }

        public async Task go_Update_Client(MClient client)
        {
            await Navigation.PushAsync(new Add_Client(client, _goEditing));
        }

        public async Task go_New_Client(MClient client)
        {
            await Navigation.PushAsync(new Add_Client(client, _goEditing));
        }

        public async Task deleteClientAsync(MClient client)
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
                }
            }
        }

        #endregion METHODS

        #region COMMANDS

        public ICommand btnSearchClientCommand => new Command(async () => await getOnClient());
        public ICommand btnDeleteClient => new Command<MClient>(async (cli) => await deleteClientAsync(cli));
        public ICommand btnGoNewClient => new Command<MClient>(async (cli) => await go_New_Client(cli));
        public ICommand btnGoUpdateClient => new Command<MClient>(async (cli) => await go_Update_Client(cli));
        public ICommand btnLeftClient => new Command(async () => await DisplayAlert("info", "prew", "ok"));
        public ICommand btnRightClient => new Command(async () => await DisplayAlert("info", "next", "ok"));

        #endregion COMMANDS
    }
}