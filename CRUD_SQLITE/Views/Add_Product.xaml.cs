using CRUD_SQLITE.Models;
using CRUD_SQLITE.ViewModels;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using System.Threading.Tasks;
using System.Linq;
using CRUD_SQLITE.Services;
using System.IO;

namespace CRUD_SQLITE.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Add_Product : ContentPage
    {
        private MProduct data;
        bool edit;
        int id;
        byte[] imgProduct;

        public Add_Product(Dictionary<string, string> data, bool isEdit)
        {

            edit = isEdit;
            InitializeComponent();
            id = int.Parse(data["Id"]);
            textName.Text = data["Name"];
            textDescription.Text = data["Description"];
            textPrice.Text = data["Price"];
            textQuantity.Text = data["Quantity"];
            textCode.Text = data["Code"];
            textBrand.Text = data["Brand"];
            picProduct.Source = data["imgProduct"];
            btnAddProduct.TextColor = Color.White;
            btnAddProduct.BackgroundColor = Color.FromHex("#FF8C00");
            btnAddProduct.Text = "Edit Product";
        }

        public Add_Product() => InitializeComponent();

        private async void openGalery_Clicked(object sender, EventArgs e)
        {

            //DisplayAlert("Alert", "Please wait while we open the gallery", "OK");


            // abrir la galeria 

            var photo = await MediaPicker.PickPhotoAsync();

            if (photo != null)
            {
                picProduct.Source = ImageSource.FromStream(() =>
                {
                    var stream = photo.OpenReadAsync().Result;


                    return stream;
                });
            }

            using (var memoryStream = new MemoryStream())
            {
                photo.OpenReadAsync().Result.CopyTo(memoryStream);
                imgProduct = memoryStream.ToArray();
            }

        }


        private async void createProduct_Clicked(object sender, EventArgs e)
        {
            try
            {
                ProductViewModel productViewModel = new ProductViewModel();

                if (edit == true)
                {
                    if (validateInput() == true)
                    {
                        await productViewModel.UpdateProduct(new MProduct
                        {
                            Name = textName.Text,
                            Code = Convert.ToInt32(textCode.Text),
                            Brand = textBrand.Text,
                            Description = textDescription.Text,
                            Price = Convert.ToDecimal(textPrice.Text),
                            Quantity = Convert.ToInt32(textQuantity.Text),
                            imgProduct = imgProduct,


                        }
                         ,
                            id
                         );
                        Shopping shopping = new Shopping();
                        shopping.cargarDataGrid();
                        await DisplayAlert("Success", "Product Updated", "OK");
                        await Navigation.PushAsync(new Product());
                        ResetInput();
                    }
                }
                else
                {
                    if (validateInput() == true)
                    {
                        await productViewModel.CreateProduct(new MProduct
                        {
                            Name = textName.Text,
                            Code = Convert.ToInt32(textCode.Text),
                            Brand = textBrand.Text,
                            Description = textDescription.Text,
                            Price = Convert.ToDecimal(textPrice.Text),
                            Quantity = Convert.ToInt32(textQuantity.Text),
                            imgProduct = imgProduct,
                        });
                        Shopping shopping = new Shopping();
                        shopping.cargarDataGrid();
                        await DisplayAlert("Success", "Product created", "OK");
                        await Navigation.PushAsync(new Product());
                        ResetInput();
                    }

                }

            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "OK");
            }
        }

        public bool validateInput()
        {
            bool validate = true;
            if (string.IsNullOrEmpty(textName.Text))
            {
                DisplayAlert("Alert", "Please enter the name", "OK");
                validate = false;
            }
            else if (string.IsNullOrEmpty(textName.Text))
            {
                DisplayAlert("Alert", "Please enter the name", "OK");
                validate = false;
            }
            else if (string.IsNullOrEmpty(textBrand.Text))
            {
                DisplayAlert("Alert", "Please enter the brand", "OK");
                validate = false;
            }
            else if (string.IsNullOrEmpty(textDescription.Text))
            {
                DisplayAlert("Alert", "Please enter the description", "OK");
                validate = false;
            }
            else if (string.IsNullOrEmpty(textPrice.Text))
            {

                DisplayAlert("Alert", "Please enter the price", "OK");
                validate = false;
            }
            else if (string.IsNullOrEmpty(textQuantity.Text))
            {
                DisplayAlert("Alert", "Please enter the quantity", "OK");
                validate = false;
            }
            else
            {
                validate = true;
            }
            return validate;
        }

        public void ResetInput()
        {
            textName.Text = "";
            textCode.Text = "";
            textBrand.Text = "";
            textDescription.Text = "";
            textPrice.Text = "";
            textQuantity.Text = "";
        }
    }
}