using CRUD_SQLITE.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CRUD_SQLITE.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Users : ContentPage
    {
        public Users()
        {
            InitializeComponent();
            BindingContext = new UsersViewModel(Navigation);
        }
    }
}