using CRUD_SQLITE.Models;
using CRUD_SQLITE.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.Xaml;

namespace CRUD_SQLITE.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Add_Client : ContentPage
    {
        private MClient data;
        bool edit;
        int id;
        public Add_Client(Dictionary<string, string> data, bool isEdit)
        {
            InitializeComponent();
            edit = isEdit;
            id = int.Parse(data["Id"]);
            textDNI.Text = data["DNI"];
            textFirstName.Text = data["FirstName"];
            textLastName.Text = data["LastName"];
            textDirection.Text = data["Direction"];
            textPhone.Text = data["Phone"];
            textEmail.Text = data["Email"];
            textCity.Text = data["City"];
            btnAddClient.TextColor = Color.White;
            btnAddClient.BackgroundColor = Color.FromHex("#FF8C00");
            btnAddClient.Text = "Edit Client";

        }

        public Add_Client() => InitializeComponent();


        private async void addClient_Clicked(object sender, EventArgs e)
        {
            ClientViewModel newClient = new ClientViewModel();



            if (edit == true)
            {

                if (validateInput() == true)
                {
                    await newClient.updateClientAsync(new MClient
                    {
                        DNI = Convert.ToInt32(textDNI.Text),
                        FirstName = textFirstName.Text,
                        LastName = textLastName.Text,
                        Direction = textDirection.Text,
                        Phone = Convert.ToInt32(textPhone.Text),
                        Email = textEmail.Text,
                        City = textCity.Text,
                    }
                    ,
                        id
                    );
                    await DisplayAlert("Success", "Client Updated", "OK");
                    await Navigation.PushAsync(new Client());
                    ResetInput();
                }
            }
            else
            {
                if (validateInput() == true)
                {
                    await newClient.createClientAsync(new MClient
                    {
                        DNI = Convert.ToInt32(textDNI.Text),
                        FirstName = textFirstName.Text,
                        LastName = textLastName.Text,
                        Direction = textDirection.Text,
                        Phone = Convert.ToInt32(textPhone.Text),
                        Email = textEmail.Text,
                        City = textCity.Text,
                    }
                );
                    await DisplayAlert("Success", "Client Added", "OK");
                    await Navigation.PushAsync(new Client());
                    ResetInput();
                }
            }
        }
        public void ResetInput()
        {
            textFirstName.Text = "";
            textLastName.Text = "";
            textDirection.Text = "";
            textPhone.Text = "";
            textEmail.Text = "";
            textCity.Text = "";
            textDNI.Text = "";
        }


        public bool validateInput()
        {
            bool validate = true;
            if (string.IsNullOrEmpty(textFirstName.Text))
            {
                DisplayAlert("Alert", "Please enter the First Name", "OK");
                validate = false;
            }
            else if (string.IsNullOrEmpty(textLastName.Text))
            {
                DisplayAlert("Alert", "Please enter the Last Name", "OK");
                validate = false;
            }
            else if (string.IsNullOrEmpty(textDirection.Text))
            {
                DisplayAlert("Alert", "Please enter the Direction", "OK");
                validate = false;
            }
            else if (string.IsNullOrEmpty(textPhone.Text))
            {
                DisplayAlert("Alert", "Please enter the description", "OK");
                validate = false;
            }
            else if (string.IsNullOrEmpty(textEmail.Text))
            {

                DisplayAlert("Alert", "Please enter the price", "OK");
                validate = false;
            }
            else if (string.IsNullOrEmpty(textCity.Text))
            {
                DisplayAlert("Alert", "Please enter the City", "OK");
                validate = false;
            }
            else if (string.IsNullOrEmpty(textDNI.Text))
            {
                DisplayAlert("Alert", "Please enter the CI", "OK");
                validate = false;
            }
            else
            {
                validate = true;
            }
            return validate;
        }


    }
}