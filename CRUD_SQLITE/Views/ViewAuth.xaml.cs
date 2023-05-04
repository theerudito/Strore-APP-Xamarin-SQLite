using MyStore.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyStore.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ViewAuth : ContentPage
    {
        public ViewAuth()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            BindingContext = new AuthViewModel(Navigation, showRegister, showLogin);
        }
    }
}