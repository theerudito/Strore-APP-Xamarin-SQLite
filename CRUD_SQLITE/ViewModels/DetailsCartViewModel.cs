using MyStore.Context;
using MyStore.Models;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MyStore.ViewModels
{
    public class DetailsCartViewModel : BaseViewModel
    {
        private DB_Context _dbContext = new DB_Context();
        private MDetailsCart myReport { get; set; }
        private ObservableCollection<MCart> _list_Product;

        public ObservableCollection<MCart> List_Products
        {
            get { return _list_Product; }
            set
            {
                SetValue(ref _list_Product, value);
                OnpropertyChanged();
            }
        }

        public DetailsCartViewModel(INavigation navigation)
        {
            Navigation = navigation;
        }

        #region METHODS

        public async Task generatePDF()
        {
            await DisplayAlert("info", "generando pdf", "ok");
        }

        public async Task sharedDocument()
        {
            await DisplayAlert("info", "compartir", "ok");
        }

        #endregion METHODS

        #region COMMANDS

        public ICommand btnSharedCommand => new Command(async () => await sharedDocument());
        public ICommand btnGeneratePDFCommand => new Command(async () => await generatePDF());

        #endregion COMMANDS
    }
}