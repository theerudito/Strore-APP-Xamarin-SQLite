﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            FrameCode.IsVisible = false;
        }
        private void btnEditCompany_Clicked(object sender, EventArgs e)
        {

            FrameCode.IsVisible = true;
        }
    }
}