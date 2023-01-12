using CRUD_SQLITE.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
namespace CRUD_SQLITE.Views
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