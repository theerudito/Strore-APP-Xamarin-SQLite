using CRUD_SQLITE.Models;
using CRUD_SQLITE.Views;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace CRUD_SQLITE.ViewModels
{
    internal class AddClientViewModel : BaseViewModel
    {
        DB.SQLite_Config connection = new DB.SQLite_Config();


        #region VARIABLES
        public MClient _client { get; set; }
        public bool _Editing;
        public string _Save;
        public string _textDNI;
        public string _textFirstName;
        public string _textLastName;
        public string _textDirection;
        public string _textPhone;
        public string _textEmail;
        public string _textCity;
        #endregion



        #region CONSTUCTOR
        public AddClientViewModel(INavigation navigation, MClient client, bool _goEditing)
        {
            if (client != null)
            {
                _client = client;
                _Editing = _goEditing;
                Save = "EDIT CLIENT";
            }
            else
            {
                _client = new MClient();
                _Editing = false;
                Save = "SAVE CLIENT";
            }

            Navigation = navigation;
            obtenerData();
        }
        #endregion



        #region OBJECTS
        public string Save
        {
            get { return _Save; }
            set
            {
                SetValue(ref _Save, value);
            }
        }
        public string TextDNI
        {
            get { return _textDNI; }
            set
            {
                SetValue(ref _textDNI, value);
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
        public string TextPhone
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
        public void obtenerData()
        {
            TextDNI = Convert.ToString(_client.DNI);
            TextFirstName = _client.FirstName;
            TextLastName = _client.LastName;
            TextDirection = _client.Direction;
            TextPhone = Convert.ToString(_client.Phone);
            TextEmail = _client.Email;
            TextCity = _client.City;
        }
        public async Task<MClient> createClientAsync(MClient client)
        {
            var db = connection.openConnection();

            var addClient = "INSERT INTO MClient " +
               "(DNI, FirstName, LastName, Direction, Phone, Email, City) " +
               "VALUES (" + TextDNI + ", " +
               "'" + TextFirstName + "', " +
               "'" + TextLastName + "', " +
               "'" + TextDirection + "', " +
               "" + TextPhone + ", " +
               "'" + TextEmail + "', " +
               "'" + TextCity + "')";

            db.Execute(addClient);
            await Navigation.PushAsync(new Client());

            return await Task.FromResult<MClient>(client);

        }
        public async Task<MClient> editClientAsync(MClient client)
        {
            var db = connection.openConnection();
            var editClient = "UPDATE MClient SET " +
                "DNI = " + TextDNI + ", " +
                "FirstName = '" + TextFirstName + "', " +
                "LastName = '" + TextLastName + "', " +
                "Direction = '" + TextDirection + "', " +
                "Phone = " + TextPhone + ", " +
                "Email = '" + TextEmail + "', " +
                "City = '" + TextCity + "' " +
                "WHERE IdClient = " + _client.Id;

            db.Execute(editClient);

            await Navigation.PushAsync(new Client());

            return await Task.FromResult<MClient>(client);
        }
        public async Task<MClient> createOrEditClientAsync(MClient client)
        {
            if (_Editing)
            {
                return await editClientAsync(client);
            }
            else
            {
                return await createClientAsync(client);
            }
        }
        #endregion



        #region COMMANDS
        public ICommand btnSaveClient => new Command<MClient>(async (cli) => await createOrEditClientAsync(cli));
        #endregion

    }
}
