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
            LoadDataGridUsers();


        }

        public async void LoadDataGridUsers()
        {

            DB.SQLite_Config connection = new DB.SQLite_Config();

            var db = connection.openConnection();

            var sql = "SELECT * FROM Auth";

            var result = db.Query<Models.Auth>(sql);

            viewUser.ItemsSource = result;
        }
    }
}