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
                mylistViewProduct.ItemsSource = result;
            }

        }

        private void addCart_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Alert", "Producto agregado al carrito", "OK");
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