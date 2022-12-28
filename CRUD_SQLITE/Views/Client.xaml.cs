using CRUD_SQLITE.Models;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using CRUD_SQLITE.ViewModels;
using System.Collections.Generic;

namespace CRUD_SQLITE.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Client : ContentPage
    {

        ClientViewModel client = new ClientViewModel();

        public Client()
        {
            InitializeComponent();
            cargarDataGridClient();
        }

        public async void cargarDataGridClient()
        {
            var result = await client.GetAllClientAsync();
            myClients.ItemsSource = result;
        }

        private void openNewCLient_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Add_Client());
        }

        private async void deleteClient_Clicked(object sender, EventArgs e)
        {

            if (myClients.SelectedItem == null)
            {
                await DisplayAlert("Alert", "Select a client", "OK");
            }
            else
            {
                var question = await DisplayAlert("Alert", "Are you sure to delete this client?", "Yes", "No");

                if (question == true)
                {
                    var item = (MClient)myClients.SelectedItem;
                    var id = item.Id;
                    await client.deleteClientAsync(id);
                    await DisplayAlert("Alert", "Client Deleted", "OK");
                    cargarDataGridClient();
                }
            }
        }

        private void updateClient_Clicked(object sender, EventArgs e)
        {
            bool isEdit = true;
            if (myClients.SelectedItem == null)
            {
                DisplayAlert("Alert", "Select a client", "OK");
            }
            else
            {
                var item = (MClient)myClients.SelectedItem;
                var data = new Dictionary<string, string>
            {
                { "Id", item.Id.ToString()},
                { "FirstName", item.FirstName },
                { "LastName", item.LastName },
                { "Direction", item.Direction },
                { "Phone", item.Phone.ToString() },
                { "Email", item.Email },
                { "City", item.City },
            };

                Navigation.PushAsync(new Add_Client(data, isEdit));

            }
        }
    }
}