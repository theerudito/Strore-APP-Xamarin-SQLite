﻿using CRUD_SQLITE.Models;
using CRUD_SQLITE.Services;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using CRUD_SQLITE.Views;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace CRUD_SQLITE.ViewModels
{
    public class ClientViewModel : BaseViewModel, IClient
    {
        DB.SQLite_Config connection = new DB.SQLite_Config();

        public int DNI { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Direction { get; set; }
        public int Phone { get; set; }
        public string Email { get; set; }
        public string City { get; set; }



        public ICommand btnSaveClient { get; set; }
        public ICommand btnGoNewClient { get; set; }
        public ICommand btnDeleteClient { get; set; }
        public ICommand btnUpdateClient { get; set; }

        public ObservableCollection<MClient> client { get; set; } = new ObservableCollection<MClient>();


        public ClientViewModel(/*INavigation navigation*/)
        {
            GetAllClientAsync();


            btnSaveClient = new Command<MClient>(Create);
            btnGoNewClient = new Command(goCreate);
            btnUpdateClient = new Command<MClient>(Update);
            btnDeleteClient = new Command<MClient>(Delete);
            //btnUpdateClient = new Command<MClient>(Update);
            OnPropertyChanged(nameof(MClient));
        }

        public Task<MClient> createClientAsync(MClient client)
        {
            var db = connection.openConnection();
            var sql = "INSERT INTO Client (FirstName, LastName, Direction, Phone, Email, City, DNI) " +
                    "VALUES ('" + FirstName + "', '" + LastName + "', '" + Direction + "', '" + Phone + "', '" + Email + "', '" + City + "', '" + DNI + "')";

            db.Execute(sql);

            return Task.FromResult(client);
        }

        public Task<bool> deleteClientAsync(int id)
        {
            var db = connection.openConnection();
            var sql = "DELETE FROM Client WHERE Id = " + id;
            db.Execute(sql);
            return Task.FromResult(true);
        }
        public async Task<IEnumerable<MClient>> GetAllClientAsync()
        {

            var db = connection.openConnection();
            var sql = "SELECT * FROM Client";
            var result = db.Query<MClient>(sql);
            foreach (var item in result)
            {
                client.Add(item);
            }

            return result;
        }

        public Task<MClient> GetOneClientAsync(int id)
        {
            throw new NotImplementedException();
        }
        public Task<bool> updateClientAsync(MClient client, int id)
        {
            var db = connection.openConnection();

            var sql = "UPDATE Client SET FirstName = '" + client.FirstName + "', " +
                "LastName = '" + client.LastName + "', " +
                "Direction = '" + client.Direction + "', " +
                "Phone = '" + client.Phone + "', " +
                "Email = '" + client.Email + "', " +
                "DNI = '" + client.DNI + "', " +
                "City = '" + client.City + "' " + "WHERE Id = " + id;
            db.Execute(sql);

            return Task.FromResult(true);
        }


        // COMMANDS
        public void goCreate()
        {
            var navigationPage = new NavigationPage(new Add_Client());
            Application.Current.MainPage = navigationPage;

        }

        public void Create(MClient client)
        {
            createClientAsync(client);
            OnPropertyChanged(nameof(MClient));

            // navegacion
            Application.Current.MainPage.Navigation.PopAsync();
        }

        // UPDATE CLIENT
        private void Update(MClient client)
        {
            updateClientAsync(client, client.Id);
        }

        //DELETE CLIENT
        private void Delete(MClient client)
        {
            deleteClientAsync(client.Id);
        }
    }
}
