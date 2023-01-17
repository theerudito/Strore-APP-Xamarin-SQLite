using CRUD_SQLITE.Models;
using CRUD_SQLITE.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CRUD_SQLITE.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Add_Product : ContentPage
    {
        public Add_Product(MProduct product, bool _goEditingProduct)
        {
            InitializeComponent();
            BindingContext = new AddProductViewModel(Navigation, product, _goEditingProduct);
        }
    }
}