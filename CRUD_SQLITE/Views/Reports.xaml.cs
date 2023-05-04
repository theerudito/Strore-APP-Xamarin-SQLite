using MyStore.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyStore.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Reports : ContentPage
    {
        public Reports()
        {
            InitializeComponent();
            BindingContext = new ReportViewModel(Navigation);
        }
    }
}