using CRUD_SQLITE.Views;
using Xamarin.Forms;

namespace CRUD_SQLITE
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(Auth), typeof(Auth));
            Routing.RegisterRoute(nameof(Client), typeof(Client));
            Routing.RegisterRoute(nameof(Shopping), typeof(Shopping));
            Routing.RegisterRoute(nameof(Client), typeof(Client));
            Routing.RegisterRoute(nameof(Product), typeof(Product));
            Routing.RegisterRoute(nameof(Reports), typeof(Reports));
            Routing.RegisterRoute(nameof(Config), typeof(Config));
            Routing.RegisterRoute(nameof(Users), typeof(Users));
        }
    }
}
