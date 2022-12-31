using CRUD_SQLITE.Models;
using CRUD_SQLITE.ViewModels;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static SQLite.SQLite3;

namespace CRUD_SQLITE.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Config : ContentPage
    {
        CompanyViewModel company = new CompanyViewModel();
        bool editCompany;

        public Config()
        {
            InitializeComponent();
            //FrameCode.IsVisible = false;
            btnSaveCompany.IsEnabled = false;
            getCompany();
        }
        CodeViewModel code = new CodeViewModel();
        private async void btnEditCompany_Clicked(object sender, EventArgs e)
        {
            //FrameCode.IsVisible = true;
            //await Task.Delay(5000);
            //FrameCode.IsVisible = false;

            if (validateInputCode() == true)
            {
                var mycode = Convert.ToInt32(textCode.Text);
                var result = await code.getCodeAsync(mycode);
                if (result.CodeAdmin.ToString() == mycode.ToString())
                {
                    await DisplayAlert("Correcto", "Código correcto", "OK");
                    btnSaveCompany.TextColor = Color.White;
                    btnSaveCompany.BackgroundColor = Color.Orange;
                    btnSaveCompany.Text = "Edit Company";
                    btnSaveCompany.IsEnabled = true;
                    editCompany = true;
                }
                else
                {
                    await DisplayAlert("Error", "El codigo no es correcto", "OK");
                    btnSaveCompany.IsEnabled = false;
                    editCompany = false;
                }
            }
        }

        public bool validateInputCode()
        {
            bool validate = true;
            if (string.IsNullOrEmpty(textCode.Text))
            {
                DisplayAlert("Alert", "the code is required", "OK");
                validate = false;
            }
            else
            {
                validate = true;
            }
            return validate;
        }

        private async void btncreateCompany_Clicked(object sender, EventArgs e)
        {
            var RUC = 1234567890;
            if (editCompany == true)
            {
                if (validateInput() == true)
                {
                    await company.updateCompanyAsync(new Company
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
                    },
                    RUC
                    );
                    await DisplayAlert("Success", "Company edited sussesfully", "OK");
                    getCompany();
                    //await Navigation.PushAsync(new Home());
                    //ResetInput();
                }
            }
            else
            {
                if (validateInput() == true)
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
                    });
                    await DisplayAlert("Success", "Company created sussesfully", "OK");
                    await Navigation.PushAsync(new Home());
                    //ResetInput();
                }
            }
        }

        bool existeCompany;
        public async void getCompany()
        {
            CompanyViewModel comp = new CompanyViewModel();
            var RUC = 1234567890;
            // hacer una consulta si existe la compania manda los imput sino no 


            if (existeCompany == true)
            {
                var result = await comp.getCompanyAsync(RUC, existeCompany);
                textNameCompany.Text = result.Name;
                textOwner.Text = result.Owner;
                textDirection.Text = result.Direction;
                textEmail.Text = result.Email;
                textRUC.Text = result.RUC.ToString();
                textPhone.Text = result.Phone.ToString();
                textNumDocument.Text = result.NumDocument.ToString();
                textSerie1.Text = result.Serie1.ToString();
                textSerie2.Text = result.Serie2.ToString();
                textDB.Text = result.DB;
                textDocument.Text = result.Document;
                textIva.Text = result.Iva.ToString();
                textCurrent.Text = result.Current;
                //textCode.Text = result.Name;
                btnSaveCompany.IsEnabled = false;
            }
            else
            {
                // no exixte la company

                await DisplayAlert("Success", "no exixte la company", "OK");
                btnSaveCompany.IsEnabled = true;
            }

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

        public bool validateInput()
        {
            bool validate = true;
            if (string.IsNullOrEmpty(textNameCompany.Text))
            {
                DisplayAlert("Alert", "Please enter the Name Company", "OK");
                validate = false;
            }
            else if (string.IsNullOrEmpty(textOwner.Text))
            {
                DisplayAlert("Alert", "Please enter the Name Owner", "OK");
                validate = false;
            }
            else if (string.IsNullOrEmpty(textDirection.Text))
            {
                DisplayAlert("Alert", "Please enter the Direction", "OK");
                validate = false;
            }
            else if (string.IsNullOrEmpty(textPhone.Text))
            {
                DisplayAlert("Alert", "Please enter the Phone", "OK");
                validate = false;
            }
            else if (string.IsNullOrEmpty(textEmail.Text))
            {

                DisplayAlert("Alert", "Please enter the Email", "OK");
                validate = false;
            }
            else if (string.IsNullOrEmpty(textNumDocument.Text))
            {
                DisplayAlert("Alert", "Please enter the NumDocument", "OK");
                validate = false;
            }
            else if (string.IsNullOrEmpty(textSerie1.Text))
            {
                DisplayAlert("Alert", "Please enter the Serie1", "OK");
                validate = false;
            }
            else if (string.IsNullOrEmpty(textSerie2.Text))
            {
                DisplayAlert("Alert", "Please enter the Serie2", "OK");
                validate = false;
            }
            else if (string.IsNullOrEmpty(textDB.Text))
            {

                DisplayAlert("Alert", "Please enter the Name BD", "OK");
                validate = false;
            }
            else if (string.IsNullOrEmpty(textDocument.Text))
            {
                DisplayAlert("Alert", "Please enter the Type Document", "OK");
                validate = false;
            }
            else if (string.IsNullOrEmpty(textIva.Text))
            {
                DisplayAlert("Alert", "Please enter the IVA", "OK");
                validate = false;
            }
            else if (string.IsNullOrEmpty(textCurrent.Text))
            {
                DisplayAlert("Alert", "Please enter the Current", "OK");
                validate = false;
            }

            else
            {
                validate = true;
            }
            return validate;
        }
    }

}