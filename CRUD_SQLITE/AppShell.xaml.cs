using CRUD_SQLITE.ViewModels;
using CRUD_SQLITE.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace CRUD_SQLITE
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(Home), typeof(Home));
            Routing.RegisterRoute(nameof(Shopping), typeof(Shopping));
            Routing.RegisterRoute(nameof(Client), typeof(Client));
            Routing.RegisterRoute(nameof(Product), typeof(Product));
            Routing.RegisterRoute(nameof(Auth), typeof(Auth));
            Routing.RegisterRoute(nameof(Reports), typeof(Reports));

        }
    }
}
