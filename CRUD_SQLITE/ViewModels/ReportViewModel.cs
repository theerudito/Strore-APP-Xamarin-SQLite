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
        ObservableCollection<MCart> _list_report;
        #endregion

        #region OBJECTS
        public ObservableCollection<MCart> List_Report
        {
            get { return this._list_report; }
            set { SetValue(ref this._list_report, value); }
        }
        #endregion

        #region METHODS
        public async Task Get_All_Report()
        {
            var db = connection.openConnection();

            var getReport = "SELECT * FROM Cart";

            var listReport = db.Query<MCart>(getReport);

            List_Report = new ObservableCollection<MCart>(listReport);

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

        public async Task seeReport(MCart report)
        {
            await Navigation.PushAsync(new DetailsCart(report));
        }
        #endregion



        #region COMMANDS
        public ICommand btnLeftReportCommand => new Command(async () => await leftReport());
        public ICommand btnRightReportCommand => new Command(async () => await rightReport());
        public ICommand btnSearchDocumentCommand => new Command(async () => await seachDocumentReport());
        public ICommand btnShowReportCommand => new Command<MCart>(async (r) => await seeReport(r));
        #endregion
    }
}
