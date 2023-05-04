using MyStore.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyStore.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailsCart : ContentPage
    {
        public DetailsCart()
        {
            InitializeComponent();
            BindingContext = new DetailsCartViewModel(Navigation);
        }
    }
}