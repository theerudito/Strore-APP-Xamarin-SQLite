using CRUD_SQLITE.Context;
using CRUD_SQLITE.Models;
using CRUD_SQLITE.Views;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace CRUD_SQLITE.ViewModels
{
    public class ReportViewModel : BaseViewModel
    {
        private DB.SQLite_Config connection = new DB.SQLite_Config();
        private DB_Context _dbContext = new DB_Context();
        public Command ReloadReports { get; }

        private string _searchTextReport;

        public string SearchTextReport
        {
            get => _searchTextReport;
            set => _searchTextReport = value;
        }

        #region CONSTRUCTOR

        public ReportViewModel(INavigation navigation)
        {
            Navigation = navigation;
            Get_All_Report();

            ReloadReports = new Command(async () => await Get_All_Report());
        }

        #endregion CONSTRUCTOR

        #region VARIABLES

        private ObservableCollection<MDetailsCart> _list_report;

        #endregion VARIABLES

        #region OBJECTS

        public ObservableCollection<MDetailsCart> List_Report
        {
            get { return _list_report; }
            set { _list_report = value; }
        }

        #endregion OBJECTS

        #region METHODS

        public async Task Get_All_Report()
        {
            IsBusy = true;

            try
            {
                var result = await _dbContext.DetailsCart.ToListAsync();
                List_Report = new ObservableCollection<MDetailsCart>(result);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public async Task GetOneReport()
        {
            //var searchingReport = _dbContext.DetailsCart
            //                    .Where(r => r.IdCart.ToString().StartsWith(SearchTextReport.Trim().ToUpper())).ToListAsync();

            //if (searchingReport.Count > 0)
            //{
            //    List_Report = new ObservableCollection<MReport>(searchingReport);
            //}
            //else
            //{
            //    await DisplayAlert("Error", "Not Exits Data", "ok");
            //}
            await DisplayAlert("Error", "Not Exits Data", "ok");
        }

        public async Task pickerDocumentReport()
        {
            await DisplayAlert("info", "search docu", "ok");
        }

        public async Task seachDateDocumentReport()
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
            await Navigation.PushAsync(new DetailsCart());
        }

        #endregion METHODS

        #region COMMANDS

        public ICommand btnSearchDocumentCommand => new Command(async () => await GetOneReport());
        public ICommand btnSearchDateDocumentCommand => new Command(async () => await seachDateDocumentReport());
        public ICommand btnLeftReportCommand => new Command(async () => await leftReport());
        public ICommand btnRightReportCommand => new Command(async () => await rightReport());
        public ICommand btnShowReportCommand => new Command<MDetailsCart>(async (r) => await seeReport(r));

        #endregion COMMANDS
    }
}