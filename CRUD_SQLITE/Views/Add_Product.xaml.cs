using CRUD_SQLITE.Models;
using CRUD_SQLITE.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CRUD_SQLITE.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Add_Product : ContentPage
    {
        private MProduct data;
        bool edit;
        int id;
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
            btnAddProduct.TextColor = Color.White;
            btnAddProduct.BackgroundColor = Color.FromHex("#FF8C00");
            btnAddProduct.Text = "Edit Product";
        }

        public Add_Product() => InitializeComponent();

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
                            Code = textCode.Text,
                            Brand = textCode.Text,
                            Description = textDescription.Text,
                            Price = Convert.ToDecimal(textPrice.Text),
                            Quantity = Convert.ToInt32(textQuantity.Text),
                        }
                         ,
                            id
                         );
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
                            Code = textCode.Text,
                            Brand = textCode.Text,
                            Description = textDescription.Text,
                            Price = Convert.ToDecimal(textPrice.Text),
                            Quantity = Convert.ToInt32(textQuantity.Text),
                        });
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