using CRUD_SQLITE.Models;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using CRUD_SQLITE.Views;
using System.Windows.Input;
using Xamarin.Forms;

namespace CRUD_SQLITE.ViewModels
{
    public class ProductViewModel : BaseViewModel
    {
        DB.SQLite_Config connection = new DB.SQLite_Config();

        #region VARIABLES
        ObservableCollection<MProduct> _List_product;
        public bool _goEditingProduct = true;
        #endregion

        #region OBJECTS
        public ObservableCollection<MProduct> List_Product { get; set; }
        #endregion

        #region CONSTRUCTOR
        public ProductViewModel(INavigation navigation)
        {
            Navigation = navigation;
            GET_ALL_Products();
        }
        #endregion

        #region METHODS
        public async Task Delete_Product(MProduct product)
        {
            var db = connection.openConnection();
            var sql = "DELETE FROM MProduct WHERE IdProduct = " + product.IdProduct;
            db.Execute(sql);

            await Navigation.PopAsync();
        }
        public async Task GET_ALL_Products()
        {
            var db = connection.openConnection();
            var sql = "SELECT * FROM MProduct";
            var result = db.Query<MProduct>(sql);

            List_Product = new ObservableCollection<MProduct>(result);
        }
        public async Task goUpdate_Product(MProduct product)
        {
            await Navigation.PushAsync(new Add_Product(product, _goEditingProduct));
        }
        public async Task goNew_Product(MProduct product)
        {
            await Navigation.PushAsync(new Add_Product(product, _goEditingProduct));
        }
        #endregion

        #region COMMANDS   
        public ICommand btnDeleteProduct => new Command<MProduct>(async (prod) => await Delete_Product(prod));
        public ICommand btnGoNewProduct => new Command<MProduct>(async (prod) => await goNew_Product(prod));
        public ICommand btnGoUpdateProduct => new Command<MProduct>(async (prod) => await goUpdate_Product(prod));
        public ICommand btnLeftProduct => new Command(async () => await DisplayAlert("info", "left", "ok"));
        public ICommand btnRightProduct => new Command(async () => await DisplayAlert("info", "right", "ok"));
        #endregion
    }
}
