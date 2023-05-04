using MyStore.Models;
using MyStore.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyStore.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Cart : ContentPage
    {
        public Cart()
        {
            InitializeComponent();
            BindingContext = new CartViewModel(Navigation);
        }

        public Cart(MProduct product)
        {
            BindingContext = new CartViewModel(product);
        }
    }
}