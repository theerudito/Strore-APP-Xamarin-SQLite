using CRUD_SQLITE.Models;
using CRUD_SQLITE.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CRUD_SQLITE.Views
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


