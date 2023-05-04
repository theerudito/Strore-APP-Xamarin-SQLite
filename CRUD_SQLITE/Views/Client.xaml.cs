using MyStore.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyStore.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Client : ContentPage
    {
        public Client()
        {
            InitializeComponent();
            BindingContext = new ClientViewModel(Navigation);
        }
    }
}