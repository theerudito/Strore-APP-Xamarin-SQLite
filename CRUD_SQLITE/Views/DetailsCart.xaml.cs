using CRUD_SQLITE.Models;
using CRUD_SQLITE.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CRUD_SQLITE.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailsCart : ContentPage
    {
        public DetailsCart(MCart report)
        {
            InitializeComponent();
            BindingContext = new DetailsCartViewModel(Navigation, report);
        }
    }
}