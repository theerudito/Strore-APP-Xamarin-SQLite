
using CRUD_SQLITE.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CRUD_SQLITE.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Config : ContentPage
    {
        public Config()
        {
            var buttonCHange = buttonUpdate;
            InitializeComponent();
            BindingContext = new CompanyViewModel(Navigation, buttonCHange);
        }
    }
}