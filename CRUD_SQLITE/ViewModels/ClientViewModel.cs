using CRUD_SQLITE.Models;
using CRUD_SQLITE.ViewModels;
using CRUD_SQLITE.Views;
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
        public int _textDNI;
        public string _textFirstName;
        public string _textLastName;
        public string _textDirection;
        public int _textPhone;
        public string _textEmail;
        public string _textCity;
        #endregion

        #region CONSTRUCTOR
        public ClientViewModel(INavigation navigation)
        {

            Navigation = navigation;
            GET_ALL_Clients();
        }
        #endregion

        #region OBJECTS
        public ObservableCollection<MClient> List_Clients
        {
            get { return _List_client; }
            set
            {
                SetValue(ref _List_client, value);
                OnpropertyChanged();
            }
        }
        public int TextDNI
        {
            get { return _textDNI; }
            set
            {
                SetValue(ref _textDNI, value);
                //OnPropertyChanged();
            }
        }
        public string TextFirstName
        {
            get { return _textFirstName; }
            set
            {
                SetValue(ref _textFirstName, value);
                //OnPropertyChanged();
            }
        }
        public string TextLastName
        {
            get { return _textLastName; }
            set
            {
                SetValue(ref _textLastName, value);
                //OnPropertyChanged();
            }
        }
        public string TextDirection
        {
            get { return _textDirection; }
            set
            {
                SetValue(ref _textDirection, value);
                //OnPropertyChanged();
            }
        }
        public int TextPhone
        {
            get { return _textPhone; }
            set
            {
                SetValue(ref _textPhone, value);
                //OnPropertyChanged();
            }
        }
        public string TextEmail
        {
            get { return _textEmail; }
            set
            {
                SetValue(ref _textEmail, value);
                //OnPropertyChanged();
            }
        }
        public string TextCity
        {
            get { return _textCity; }
            set
            {
                SetValue(ref _textCity, value);
                //OnPropertyChanged();
            }
        }
        #endregion

        #region METHODS
        public async Task Insert_Client()
        {
            var db = connection.openConnection();
            //DNI, FirstName, LastName, Direction, Phone, Email, City
            var sql = "INSERT INTO Client (DNI, FirstName, LastName, Direction, Phone, Email, City) " +
                "VALUES (" + TextDNI + ", '" + TextFirstName + "', '" + TextLastName + "', '" + TextDirection + "', " +
                "" + TextPhone + ", '" + TextEmail + "', '" + TextCity + "')";
            db.Execute(sql);

            await Navigation.PushAsync(new Client());
        }

        public async Task Delete_Client(MClient client)
        {
            var db = connection.openConnection();
            var sql = "delete from client where id = " + client.Id;

            db.Execute(sql);
        }

        public async Task GET_ALL_Clients()
        {
            var db = connection.openConnection();
            var sql = "SELECT * FROM Client";
            var result = db.Query<MClient>(sql);

            List_Clients = new ObservableCollection<MClient>(result);

        }

        public async Task Update_Client()
        {

        }


        public async Task go_Update_Client()
        {
            await Navigation.PushAsync(new Add_Client());
        }
        #endregion


        #region COMMANDS
        public ICommand btnSaveClient => new Command(async () => await Insert_Client());
        public ICommand btnDeleteClient => new Command<MClient>(async (cli) => await Delete_Client(cli));
        public ICommand btnGoNewClient => new Command(async () => await go_Update_Client());
        public ICommand btnUpdateClient => new Command(async () => await Navigation.PushAsync(new Add_Client()));
        public ICommand btnLeftClient => new Command(async () => await DisplayAlert("info", "prew", "ok"));
        public ICommand btnRightClient => new Command(async () => await DisplayAlert("info", "next", "ok"));
        #endregion



        //public Task<MClient> createClientAsync(MClient client)
        //{
        //    var db = connection.openConnection();
        //    var sql = "INSERT INTO Client (FirstName, LastName, Direction, Phone, Email, City, DNI) " +
        //            "VALUES ('" + textFirstName + "', '" + textLastName + "', '" + textDirection + "', '" + textPhone + "', '" + textEmail + "', '" + textCity + "', '" + textDNI + "')";

        //    db.Execute(sql);

        //    return Task.FromResult(client);
        //}

        //public Task<bool> deleteClientAsync(int id)
        //{
        //    var db = connection.openConnection();
        //    var sql = "DELETE FROM Client WHERE Id = " + id;
        //    db.Execute(sql);
        //    return Task.FromResult(true);
        //}
        //public async Task<IEnumerable<MClient>> GetAllClientAsync()
        //{

        //    var db = connection.openConnection();
        //    var sql = "SELECT * FROM Client";
        //    var result = db.Query<MClient>(sql);
        //    foreach (var item in result)
        //    {
        //        client.Add(item);
        //    }

        //    return result;
        //}

        //public Task<MClient> GetOneClientAsync(int id)
        //{
        //    throw new NotImplementedException();
        //}
        //public Task<bool> updateClientAsync(MClient client, int id)
        //{
        //    var db = connection.openConnection();

        //    var sql = "UPDATE Client SET FirstName = '" + client.FirstName + "', " +
        //        "LastName = '" + client.LastName + "', " +
        //        "Direction = '" + client.Direction + "', " +
        //        "Phone = '" + client.Phone + "', " +
        //        "Email = '" + client.Email + "', " +
        //        "DNI = '" + client.DNI + "', " +
        //        "City = '" + client.City + "' " + "WHERE Id = " + id;
        //    db.Execute(sql);

        //    return Task.FromResult(true);
        //}



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
