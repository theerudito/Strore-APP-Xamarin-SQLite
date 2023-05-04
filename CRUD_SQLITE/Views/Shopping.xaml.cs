using MyStore.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyStore.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Shopping : ContentPage
    {
        public Shopping()
        {
            InitializeComponent();
            BindingContext = new ShoppingViewModel(Navigation);
        }
    }
}