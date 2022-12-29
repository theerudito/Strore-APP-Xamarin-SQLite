using CRUD_SQLITE.ViewModels;
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
    public partial class Auth : ContentPage
    {
        public Auth()
        {
            InitializeComponent();
            register.IsVisible = false;
        }


        private void Login_Clicked(object sender, EventArgs e)
        {
            AuthViewModel auth = new AuthViewModel();

            if (auth.Login(textEmailLogin.Text, textPasswordLogin.Text) == true)
            {
                Navigation.PushAsync(new Home());
            }
            else
            {
                DisplayAlert("Error", "Email or Password is incorrect", "Ok");
            }

        }

        private void Register_Clicked(object sender, EventArgs e)
        {
            AuthViewModel auth = new AuthViewModel();


            if (auth.Register(textNameRegister.Text, textEmailRegister.Text, textPasswordRegister.Text) == true)
            {
                DisplayAlert("Success", "User Registered", "Ok");
                Navigation.PushAsync(new Home());
            }
            else
            {
                DisplayAlert("Error", "Email already exists", "Ok");
                Navigation.PushAsync(new Home());
            }


        }


        private void showLogin_Clicked(object sender, EventArgs e)
        {
            register.IsVisible = false;
            login.IsVisible = true;
        }

        private void showRegister_Clicked(object sender, EventArgs e)
        {
            login.IsVisible = false;
            register.IsVisible = true;
        }

        public void ResetInput()
        {
            textEmailLogin.Text = "";
            textPasswordLogin.Text = "";
            textNameRegister.Text = "";
            textEmailRegister.Text = "";
            textPasswordRegister.Text = "";
        }

    }

}