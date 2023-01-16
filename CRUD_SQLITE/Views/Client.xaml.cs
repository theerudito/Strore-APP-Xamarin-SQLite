using CRUD_SQLITE.Models;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using CRUD_SQLITE.ViewModels;
using System.Collections.Generic;

namespace CRUD_SQLITE.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Client : ContentPage
    {
        public Client()
        {
            InitializeComponent();
            BindingContext = new ClientViewModel(Navigation);
        }
    }
}