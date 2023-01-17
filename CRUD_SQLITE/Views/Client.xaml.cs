﻿using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using CRUD_SQLITE.ViewModels;
using CRUD_SQLITE.Models;

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