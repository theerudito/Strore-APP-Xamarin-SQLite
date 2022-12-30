using CRUD_SQLITE.Models;
using System.Net.Http;
using System.Net;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System;
using System.Collections.Generic;
using System.Linq;
using CRUD_SQLITE.DB;
using System.Xml.Linq;
using System.Collections.ObjectModel;
using System.Collections;
using System.Security.Cryptography;

namespace CRUD_SQLITE.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LlamadoAPI : ContentPage
    {

        public LlamadoAPI()
        {
            InitializeComponent();
            LlamarApiAsync();
            //usandoName();

            //usandoBinding();
        }

        public async Task LlamarApiAsync()
        {


            // OPCION 1
            var request = new HttpRequestMessage();
            request.RequestUri = new Uri("https://reqres.in/api/users?page=2");
            request.Method = HttpMethod.Get;
            request.Headers.Add("Accept", "application/json");
            var client = new HttpClient();
            HttpResponseMessage response = await client.SendAsync(request);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var content = await response.Content.ReadAsStringAsync();
                var json = Newtonsoft.Json.JsonConvert.DeserializeObject<API>(content);

                myData.ItemsSource = json.data;

            }

            // OPCION 2
            //var client = new HttpClient();
            //var response = await client.GetAsync("https://reqres.in/api/users?page=2");
            //if (response.StatusCode == HttpStatusCode.OK)
            //{
            //    var content = await response.Content.ReadAsStringAsync();
            //    var json = Newtonsoft.Json.JsonConvert.DeserializeObject<API>(content);
            //    dataAPI.ItemsSource = json.data;
            //}


            // JSON PLACEHOLDER
            //var client = new HttpClient();

            //var response = await client.GetAsync("https://jsonplaceholder.typicode.com/users");

            //if (response.StatusCode == HttpStatusCode.OK)
            //{
            //    var content = await response.Content.ReadAsStringAsync();

            //    var json = Newtonsoft.Json.JsonConvert.DeserializeObject<List<JSONPLACEHOLDER>>(content);

            //    dataAPI.ItemsSource = json;
            //}
        }

        public void usandoName()
        {
            //CollecionDATA.ItemsSource = new string[]
            //{
            //    "uno",
            //    "dos",
            //    "tres"
            //};
        }
        public void usandoBinding()
        {

        }
    }
}
