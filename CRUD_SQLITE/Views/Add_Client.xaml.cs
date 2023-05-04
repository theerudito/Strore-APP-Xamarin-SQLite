using MyStore.Models;
using MyStore.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyStore.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Add_Client : ContentPage
    {
        public Add_Client(MClient client, bool _goEditing)
        {
            InitializeComponent();
            BindingContext = new AddClientViewModel(Navigation, client, _goEditing);
        }
    }
}