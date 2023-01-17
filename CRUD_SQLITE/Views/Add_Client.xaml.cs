using CRUD_SQLITE.Models;
using CRUD_SQLITE.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CRUD_SQLITE.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Add_Client : ContentPage
    {
        public Add_Client(MClient client, bool _goEditing)
        {
            InitializeComponent();
            BindingContext = new AddClientViewModel(Navigation, client, _goEditing);
        }
        //public bool validateInput()
        //{
        //    bool validate = true;
        //    if (string.IsNullOrEmpty(textFirstName.Text))
        //    {
        //        DisplayAlert("Alert", "Please enter the First Name", "OK");
        //        validate = false;
        //    }
        //    else if (string.IsNullOrEmpty(textLastName.Text))
        //    {
        //        DisplayAlert("Alert", "Please enter the Last Name", "OK");
        //        validate = false;
        //    }
        //    else if (string.IsNullOrEmpty(textDirection.Text))
        //    {
        //        DisplayAlert("Alert", "Please enter the Direction", "OK");
        //        validate = false;
        //    }
        //    else if (string.IsNullOrEmpty(textPhone.Text))
        //    {
        //        DisplayAlert("Alert", "Please enter the description", "OK");
        //        validate = false;
        //    }
        //    else if (string.IsNullOrEmpty(textEmail.Text))
        //    {

        //        DisplayAlert("Alert", "Please enter the price", "OK");
        //        validate = false;
        //    }
        //    else if (string.IsNullOrEmpty(textCity.Text))
        //    {
        //        DisplayAlert("Alert", "Please enter the City", "OK");
        //        validate = false;
        //    }
        //    else if (string.IsNullOrEmpty(textDNI.Text))
        //    {
        //        DisplayAlert("Alert", "Please enter the CI", "OK");
        //        validate = false;
        //    }
        //    else
        //    {
        //        validate = true;
        //    }
        //    return validate;
        //}
    }
}