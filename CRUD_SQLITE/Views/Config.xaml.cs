using CRUD_SQLITE.Models;
using CRUD_SQLITE.ViewModels;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CRUD_SQLITE.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Config : ContentPage
    {
        CompanyViewModel company = new CompanyViewModel();
        public Config()
        {
            InitializeComponent();
            FrameCode.IsVisible = false;
        }
        private void btnEditCompany_Clicked(object sender, EventArgs e)
        {
            FrameCode.IsVisible = true;
        }

        private async void btncreateCompany_Clicked(object sender, EventArgs e)
        {
            await company.createCompanyAsync(new Company
            {
                Name = textNameCompany.Text,
                Owner = textOwner.Text,
                Direction = textDirection.Text,
                Email = textEmail.Text,
                Phone = Convert.ToInt32(textPhone.Text),
                RUC = Convert.ToInt32(textRUC.Text),
                NumDocument = Convert.ToInt32(textNumDocument.Text),
                Serie1 = Convert.ToInt32(textSerie1.Text),
                Serie2 = Convert.ToInt32(textSerie2.Text),
                DB = textDB.Text,
                Document = textDocument.Text,
                Iva = Convert.ToDecimal(textIva.Text),
                Current = textCurrent.Text,
                //Code = textCode.Text

            });
            await DisplayAlert("Success", "Company created sussesfully", "OK");
            await Navigation.PushAsync(new Home());
            ResetInput();
        }


        public void ResetInput()
        {
            // textLogo
            //textNameCompany
            //textOwner
            //textDirection
            //textEmail
            //textRUC
            //textPhone
            //textNumDocument
            //textSerie1
            //textSerie2
            //textDB
            //textDocument
            //textIva
            //textCurrent
            //textCode

            textNameCompany.Text = "";
            textOwner.Text = "";
            textDirection.Text = "";
            textEmail.Text = "";
            textRUC.Text = "";
            textPhone.Text = "";
            textNumDocument.Text = "";
            textSerie1.Text = "";
            textSerie2.Text = "";
            textDB.Text = "";
            textDocument.Text = "";
            textIva.Text = "";
            textCurrent.Text = "";
            textCode.Text = "";
        }
    }

}