using CRUD_SQLITE.Models;
using CRUD_SQLITE.Views;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace CRUD_SQLITE.ViewModels
{
    public class ClientViewModel : BaseViewModel
    {
        DB.SQLite_Config connection = new DB.SQLite_Config();

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
        public Task<IEnumerable<MClient>> GetAllClientAsync()
        {
            var db = connection.openConnection();

            var sql = "SELECT * FROM MClient";

            var result = db.Query<MClient>(sql);

            List_Clients = new ObservableCollection<MClient>(result);

            return Task.FromResult<IEnumerable<MClient>>(result);
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
            var db = connection.openConnection();

            var deleteClient = "DELETE FROM MClient WHERE IdClient = " + client.IdClient;

            db.Execute(deleteClient);

            OnpropertyChanged();

            return await Task.FromResult<bool>(true);
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


//public async void Insert()
//{

//}

//public async void Delete()
//{

//}

//public async void GET()
//{

//}

//public async void Update()
//{

//}

//public async void goUpDate()
//{

//}

//public async void goNewClient()
//{

//}


//public async void prew()
//{

//}

//public async void next()
//{

//}




//DB.SQLite_Config connection = new DB.SQLite_Config();
//#region VARIABLES
//public int _textDNI;
//public string _textFirstName;
//public string _textLastName;
//public string _textDirection;
//public int _textPhone;
//public string _textEmail;
//public string _textCity;
//#endregion



//#region CONSTROCTOR
//public ClientViewModel(INavigation navigation)
//{

//    Navigation = navigation;
//}
//#endregion



//#region OBJECTS
//public int TextDNI
//{
//    get { return _textDNI; }
//    set
//    {
//        SetValue(ref _textDNI, value);
//        //OnPropertyChanged();
//    }
//}
//public string textFirstName
//{
//    get { return _textFirstName; }
//    set
//    {
//        SetValue(ref _textFirstName, value);
//        //OnPropertyChanged();
//    }
//}
//public string textLastName
//{
//    get { return _textLastName; }
//    set
//    {
//        SetValue(ref _textLastName, value);
//        //OnPropertyChanged();
//    }
//}
//public string textDirection
//{
//    get { return _textDirection; }
//    set
//    {
//        SetValue(ref _textDirection, value);
//        //OnPropertyChanged();
//    }
//}
//public int textPhone
//{
//    get { return _textPhone; }
//    set
//    {
//        SetValue(ref _textPhone, value);
//        //OnPropertyChanged();
//    }
//}
//public string textEmail
//{
//    get { return _textEmail; }
//    set
//    {
//        SetValue(ref _textEmail, value);
//        //OnPropertyChanged();
//    }
//}
//public string textCity
//{
//    get { return _textCity; }
//    set
//    {
//        SetValue(ref _textCity, value);
//        //OnPropertyChanged();
//    }
//}
//#endregion

//#region METHODS
//public async Task Get_All_Client()
//{

//}

//public async Task Insert_Client()
//{

//}

//public async Task Delete_Client()
//{

//}

//public async Task GET_ALL_Clients()
//{

//}

//public async Task Update_Client()
//{

//}


//public async Task go_Update_Client()
//{

//}

//public async Task go_New_Client()
//{

//}
//#endregion


//#region COMMANDS
//public ICommand btnSaveClient => new Command(async () => await Insert_Client());
//public ICommand btnDeleteClient => new Command(async () => await Delete_Client());
//public ICommand btnGoNewClient => new Command(async () => await go_Update_Client());
//public ICommand btnUpdateClient => new Command(async () => await go_New_Client());
//#endregion
