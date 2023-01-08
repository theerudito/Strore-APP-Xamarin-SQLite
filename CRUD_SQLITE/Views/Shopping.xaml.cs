using CRUD_SQLITE.Models;
using CRUD_SQLITE.ViewModels;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CRUD_SQLITE.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Shopping : ContentPage
    {
        //ProductViewModel product = new ProductViewModel();

        public Shopping()
        {
            InitializeComponent();
            BindingContext = new ProductViewModel(Navigation);


        }




        CartViewModel cart = new CartViewModel();
        private async void addCart_Clicked(object sender, EventArgs e)
        {

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