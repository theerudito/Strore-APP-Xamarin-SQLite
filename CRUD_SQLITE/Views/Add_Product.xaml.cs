using CRUD_SQLITE.Models;
using CRUD_SQLITE.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System;


namespace CRUD_SQLITE.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Add_Product : ContentPage
    {
        public Add_Product()
        {
            InitializeComponent();
            BindingContext = new ProductViewModel(Navigation);
        }






        //private async void createProduct_Clicked(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        ProductViewModel productViewModel = new ProductViewModel(Navigation);

        //        if (edit == true)
        //        {
        //            if (validateInput() == true)
        //            {
        //                await productViewModel.UpdateProduct(new MProduct
        //                {
        //                    Name = textName.Text,
        //                    Code = Convert.ToInt32(textCode.Text),
        //                    Brand = textBrand.Text,
        //                    Description = textDescription.Text,
        //                    Price = Convert.ToDecimal(textPrice.Text),
        //                    Quantity = Convert.ToInt32(textQuantity.Text),
        //                    imgProduct = uploadImage.ToArray(),
        //                }
        //                 ,
        //                    id
        //                 ); ;
        //                Shopping shopping = new Shopping();
        //                //shopping.cargarDataGrid();
        //                await DisplayAlert("Success", "Product Updated", "OK");
        //                await Navigation.PushAsync(new Product());
        //                ResetInput();
        //            }
        //        }
        //        else
        //        {
        //            if (validateInput() == true)
        //            {
        //                await productViewModel.CreateProduct(new MProduct
        //                {
        //                    Name = textName.Text,
        //                    Code = Convert.ToInt32(textCode.Text),
        //                    Brand = textBrand.Text,
        //                    Description = textDescription.Text,
        //                    Price = Convert.ToDecimal(textPrice.Text),
        //                    Quantity = Convert.ToInt32(textQuantity.Text),
        //                    imgProduct = uploadImage.ToArray(),
        //                });
        //                Shopping shopping = new Shopping();
        //                //shopping.cargarDataGrid();
        //                await DisplayAlert("Success", "Product created", "OK");
        //                await Navigation.PushAsync(new Product());
        //                ResetInput();
        //            }

        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        await DisplayAlert("Error", ex.Message, "OK");
        //    }
        //}

        //public bool validateInput()
        //{
        //    bool validate = true;
        //    if (string.IsNullOrEmpty(textName.Text))
        //    {
        //        DisplayAlert("Alert", "Please enter the name", "OK");
        //        validate = false;
        //    }
        //    else if (string.IsNullOrEmpty(textName.Text))
        //    {
        //        DisplayAlert("Alert", "Please enter the name", "OK");
        //        validate = false;
        //    }
        //    else if (string.IsNullOrEmpty(textBrand.Text))
        //    {
        //        DisplayAlert("Alert", "Please enter the brand", "OK");
        //        validate = false;
        //    }
        //    else if (string.IsNullOrEmpty(textDescription.Text))
        //    {
        //        DisplayAlert("Alert", "Please enter the description", "OK");
        //        validate = false;
        //    }
        //    else if (string.IsNullOrEmpty(textPrice.Text))
        //    {

        //        DisplayAlert("Alert", "Please enter the price", "OK");
        //        validate = false;
        //    }
        //    else if (string.IsNullOrEmpty(textQuantity.Text))
        //    {
        //        DisplayAlert("Alert", "Please enter the quantity", "OK");
        //        validate = false;
        //    }
        //    else
        //    {
        //        validate = true;
        //    }
        //    return validate;
        //}

        //public void ResetInput()
        //{
        //    textName.Text = "";
        //    textCode.Text = "";
        //    textBrand.Text = "";
        //    textDescription.Text = "";
        //    textPrice.Text = "";
        //    textQuantity.Text = "";
        //}
    }
}