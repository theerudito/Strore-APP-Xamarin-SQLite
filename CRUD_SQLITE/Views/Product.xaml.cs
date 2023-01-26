using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using CRUD_SQLITE.ViewModels;

namespace CRUD_SQLITE.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Product : ContentPage
    {
        public Product()
        {
            InitializeComponent();
            BindingContext = new ProductViewModel(Navigation);
        }
    }
}