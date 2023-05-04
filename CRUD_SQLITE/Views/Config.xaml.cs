using MyStore.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyStore.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Config : ContentPage
    {
        public Config()
        {
            var buttonChange = buttonUpdate;
            InitializeComponent();
            BindingContext = new CompanyViewModel(Navigation);
        }
    }
}