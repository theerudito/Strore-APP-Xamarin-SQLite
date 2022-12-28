using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CRUD_SQLITE.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Home : ContentPage
    {
        public Home()
        {
            InitializeComponent();
        }

        private void openMyGitHub(object sender, EventArgs e)
        {
            DisplayAlert("Alert", "This is an alert.", "OK");
            //Navigation.PushAsync(new Shopping());
        }
    }
}