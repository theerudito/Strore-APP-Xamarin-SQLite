using MyStore.Models;
using MyStore.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyStore.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Add_Product : ContentPage
    {
        public Add_Product(MProduct product, bool _goEditingProduct)
        {
            InitializeComponent();
            BindingContext = new AddProductViewModel(Navigation, product, _goEditingProduct);
        }
    }
}