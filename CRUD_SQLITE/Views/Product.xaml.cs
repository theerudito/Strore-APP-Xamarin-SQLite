using CRUD_SQLITE.Models;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using CRUD_SQLITE.ViewModels;
using System.Collections.Generic;

namespace CRUD_SQLITE.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Product : ContentPage
    {
        ProductViewModel product = new ProductViewModel();


        public Product()
        {
            InitializeComponent();
            cargarDataGrid();
        }
        public async void cargarDataGrid()
        {
            var result = await product.GetAllProduct();
            mylistViewProduct.ItemsSource = result;
        }

        private void ImageButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Add_Product());
        }

        private async void deleteProduct_Clicked(object sender, EventArgs e)
        {

            if (mylistViewProduct.SelectedItem == null)
            {
                await DisplayAlert("Alert", "Select a product", "OK");
            }
            else
            {
                var question = await DisplayAlert("Alert", "Are you sure to delete this product?", "Yes", "No");

                if (question == true)
                {
                    var item = (MProduct)mylistViewProduct.SelectedItem;
                    var id = item.Id;
                    await product.DeleteProduct(id);
                    await DisplayAlert("Alert", "Product Deleted", "OK");
                    cargarDataGrid();
                }
            }
        }

        private void updateProduct_Clicked(object sender, EventArgs e)
        {

            if (mylistViewProduct.SelectedItem == null)
            {
                DisplayAlert("Alert", "Select a product", "OK");
            }
            else
            {
                var item = (MProduct)mylistViewProduct.SelectedItem;
                bool isEdit = true;
                var data = new Dictionary<string, string>
            {
                { "Id", item.Id.ToString()},
                { "Name", item.Name },
                { "Code", item.Code.ToString() },
                { "Brand", item.Brand },
                { "Description", item.Description },
                { "Price", item.Price.ToString() },
                { "Quantity", item.Quantity.ToString() },
                { "imgProduct", item.imgProduct.ToString() }

            };

                Navigation.PushAsync(new Add_Product(data, isEdit));
            }
        }
    }
}