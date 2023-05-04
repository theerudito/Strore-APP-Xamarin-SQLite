using Microsoft.EntityFrameworkCore;
using MyStore.Context;
using MyStore.Models;
using MyStore.Views;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MyStore.ViewModels
{
    internal class AddClientViewModel : BaseViewModel
    {
        private DB_Context _dbContext = new DB_Context();

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

        #endregion VARIABLES

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

        #endregion CONSTUCTOR

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

        #endregion OBJECTS

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

        public async Task<MClient> createClientAsync()
        {
            var newClient = await _dbContext.Client.FirstOrDefaultAsync(cli => cli.DNI == TextDNI);
            if (newClient == null)
            {
                var client = new MClient
                {
                    DNI = TextDNI.ToUpper(),
                    FirstName = TextFirstName.ToUpper(),
                    LastName = TextLastName.ToUpper(),
                    Direction = TextDirection.ToUpper(),
                    Phone = TextPhone,
                    Email = TextEmail,
                    City = TextCity.ToUpper()
                };

                if (Validations() == true)
                {
                    _dbContext.Client.Add(client);
                    await _dbContext.SaveChangesAsync();
                    ResetField();
                    await Navigation.PushAsync(new Client());
                }

                return client;
            }
            else
            {
                await DisplayAlert("Error", "The client already exists", "OK");
                _Editing = true;
                Save = "EDIT CLIENT";
                TextDNI = newClient.DNI;
                TextFirstName = newClient.FirstName.ToUpper();
                TextLastName = newClient.LastName.ToUpper();
                TextDirection = newClient.Direction.ToUpper();
                TextPhone = newClient.Phone;
                TextEmail = newClient.Email;
                TextCity = newClient.City.ToUpper();
                return null;
            }
        }

        public async Task<MClient> editClientAsync()
        {
            _client.DNI = TextDNI;
            _client.FirstName = TextFirstName.ToUpper();
            _client.LastName = TextLastName.ToUpper();
            _client.Direction = TextDirection.ToUpper();
            _client.Phone = TextPhone;
            _client.Email = TextEmail;
            _client.City = TextCity.ToUpper();

            if (Validations() == true)
            {
                _dbContext.Client.Update(_client);
                await _dbContext.SaveChangesAsync();

                ResetField();

                await Navigation.PushAsync(new Client());
            }

            return _client;
        }

        public async Task<MClient> createOrEditClientAsync()
        {
            if (_Editing)
            {
                return await editClientAsync();
            }
            else
            {
                return await createClientAsync();
            }
        }

        public void ResetField()
        {
            TextDNI = "";
            TextFirstName = "";
            TextLastName = "";
            TextDirection = "";
            TextPhone = "";
            TextEmail = "";
            TextCity = "";
        }

        public bool Validations()
        {
            if (string.IsNullOrEmpty(TextDNI))
            {
                DisplayAlert("Error", "the DNI is requided", "Ok");
                return false;
            }
            else if (string.IsNullOrEmpty(TextFirstName))
            {
                DisplayAlert("Error", "the FirstName is requided", "Ok");
                return false;
            }
            else if (string.IsNullOrEmpty(TextLastName))
            {
                DisplayAlert("Error", "the LastName is requided", "Ok");
                return false;
            }
            else if (string.IsNullOrEmpty(TextDirection))
            {
                DisplayAlert("Error", "the Direction is requided", "Ok");
                return false;
            }
            else if (string.IsNullOrEmpty(TextPhone))
            {
                DisplayAlert("Error", "the Phone is requided", "Ok");
                return false;
            }
            else if (string.IsNullOrEmpty(TextEmail))
            {
                DisplayAlert("Error", "the Email is requided", "Ok");
                return false;
            }
            else if (string.IsNullOrEmpty(TextCity))
            {
                DisplayAlert("Error", "the City is requided", "Ok");
                return false;
            }
            else
            {
                return true;
            }
        }

        #endregion METHODS

        #region COMMANDS

        public ICommand btnSaveClient => new Command<MClient>(async (cli) => await createOrEditClientAsync());

        #endregion COMMANDS
    }
}