using CRUD_SQLITE.Models;
using CRUD_SQLITE.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CRUD_SQLITE.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Shopping : ContentPage
    {
        ProductViewModel product = new ProductViewModel();

        public ObservableCollection<MProduct> Products { get; set; }

        // crear un array




        public Shopping()
        {
            InitializeComponent();
            cargarDataGrid();
        }

        public async void cargarDataGrid()
        {
            var result = await product.GetAllProduct();

            if (result != null)
            {
                var data = mylistViewProduct.ItemsSource = result;
            }
        }
        CartViewModel cart = new CartViewModel();
        private async void addCart_Clicked(object sender, EventArgs e)
        {
            if (mylistViewProduct.SelectedItem == null)
            {
                await DisplayAlert("Alert", "Select a product", "OK");
            }
            else
            {

                await DisplayAlert("Alert", "Product Added", "OK");

            }



        }

        private void goCart_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Cart());
        }

        private void prewProduct_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Alert", "preview product", "OK");
        }

        private void nextProduct_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Alert", "next product", "OK");
        }
    }
}