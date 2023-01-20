

using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace CRUD_SQLITE.ViewModels
{
    public class ReportViewModel : BaseViewModel
    {
        string numDocument;
        public ReportViewModel(INavigation navigation)
        {
            Navigation = navigation;
        }



        #region METHODS
        public async Task pickerDocumentReport()
        {
            await DisplayAlert("info", "search docu", "ok");
        }
        public async Task seachDocumentReport()
        {
            await DisplayAlert("info", "compartir", "ok");
        }
        public async Task leftReport()
        {
            await DisplayAlert("info", "left", "ok");
        }
        public async Task rightReport()
        {
            await DisplayAlert("info", "right", "ok");
        }
        #endregion



        #region COMMANDS
        public ICommand btnLeftReport => new Command(async () => await leftReport());
        public ICommand btnRightReport => new Command(async () => await rightReport());
        public ICommand btnSearchDocumentCommand => new Command(async () => await seachDocumentReport());
        public ICommand btnGeneratePDFCommand => new Command(async () => await pickerDocumentReport());
        #endregion
    }
}
