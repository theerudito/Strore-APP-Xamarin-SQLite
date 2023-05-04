using MyStore.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyStore.Views
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