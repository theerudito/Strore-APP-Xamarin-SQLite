using CRUD_SQLITE.Models;
using CRUD_SQLITE.Views;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace CRUD_SQLITE.ViewModels
{
    public class DetailsCartViewModel : BaseViewModel
    {
        private MDetailsCart myReport { get; set; }
        public DetailsCartViewModel(INavigation navigation, MDetailsCart report)
        {
            Navigation = navigation;
            myReport = report;
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
        #endregion


        #region COMMANDS
        public ICommand btnSharedCommand => new Command(async () => await sharedDocument());
        public ICommand btnGeneratePDFCommand => new Command(async () => await generatePDF());
        #endregion
    }
}
