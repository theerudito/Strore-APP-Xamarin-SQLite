using CRUD_SQLITE.Models;
using CRUD_SQLITE.ViewModels;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CRUD_SQLITE.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Config : ContentPage
    {
        public Config()
        {
            InitializeComponent();
            BindingContext = new CompanyViewModel(Navigation);
        }
    }
}