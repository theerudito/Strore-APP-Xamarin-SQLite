using CRUD_SQLITE.Models;
using CRUD_SQLITE.Views;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace CRUD_SQLITE.ViewModels
{
    public class ReportViewModel : BaseViewModel
    {
        DB.SQLite_Config connection = new DB.SQLite_Config();



        #region CONSTRUCTOR
        public ReportViewModel(INavigation navigation)
        {
            Navigation = navigation;
            Get_All_Report();
        }
        #endregion


        #region VARIABLES
        ObservableCollection<MDetailsCart> _list_report;
        #endregion

        #region OBJECTS
        public ObservableCollection<MDetailsCart> List_Report
        {
            get { return _list_report; }
            set { SetValue(ref _list_report, value); }
        }
        #endregion

        #region METHODS
        public async Task Get_All_Report()
        {
            var db = connection.openConnection();

            //var getReport = "SELECT * FROM MDetailCart";

            var getReport = "select * from MDetailCart join MClient on MDetailCart.IdDetailCart = MClient.IdClient join MProduct on MDetailCart.IdDetailCart = MProduct.IdProduct";

            var listReport = db.Query<MDetailsCart>(getReport);

            List_Report = new ObservableCollection<MDetailsCart>(listReport);

        }
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

        public async Task seeReport(MDetailsCart report)
        {
            await Navigation.PushAsync(new DetailsCart(report));
        }
        #endregion



        #region COMMANDS
        public ICommand btnLeftReportCommand => new Command(async () => await leftReport());
        public ICommand btnRightReportCommand => new Command(async () => await rightReport());
        public ICommand btnSearchDocumentCommand => new Command(async () => await seachDocumentReport());
        public ICommand btnShowReportCommand => new Command<MDetailsCart>(async (r) => await seeReport(r));
        #endregion
    }
}
