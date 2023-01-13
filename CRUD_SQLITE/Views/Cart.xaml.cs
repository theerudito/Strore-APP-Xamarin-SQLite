
using CRUD_SQLITE.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CRUD_SQLITE.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Cart : ContentPage
    {
        public Cart()
        {
            InitializeComponent();
            BindingContext = new CartViewModel(Navigation);
            //textDateCart.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }

        public void resetCart()
        {
            //var cart = new Cart();
            //cart.NameProduct = "";
            //cart.Code = "";
            //cart.Brand = "";
            //cart.Description = "";
            //cart.vUnitary = 0;
            //cart.Quantity = 0;
            //cart.vTotal = 0;
            //cart.FirstName = "";
            //cart.LastName = "";
            //cart.DNI = 0;
            //cart.Direction = "";
            //cart.Email = "";
            //cart.Phone = 0;
            //cart.Total = 0;
            //cart.Date = "";
            //cart.Hour = "";


            //textNameProduct.Text = cart.NameProduct;
            //Code.Text = cart.Code;
            //textBrand.Text = cart.Brand;
            //textDescription.Text = cart.Description;
            //textValueUnitary.Text = cart.vUnitary.ToString();
            //textQuantity.Text = cart.Quantity.ToString();
            //textValuevTotal.Text = cart.vTotal.ToString();
            //textFirstName.Text = cart.FirstName;
            //textLastName.Text = cart.LastName;
            //textDNI.Text = cart.DNI.ToString();
            //textDirection.Text = cart.Direction;
            //textEmail.Text = cart.Email;
            //textPhone.Text = cart.Phone.ToString();
            //textTotal.Text = cart.Total.ToString();
            //textDate.Text = cart.Date;
            //textHour.Text = cart.Hour;
        }

        public void resetInput()
        {
            //  textNameProductCart.Text = "";
            //  textDescriptionProductCart.Text = "";
            //  textBrandProductCart.Text = "";
            //  textCodeProductCart.Text = "";

            textQuantityProductCart.Text = "";
            textValueUnitaryProductCart.Text = "";
            textValuevTotalProductCart.Text = "";

            //textDNICart.Text = "";
            //textPhoneCart.Text = "";
            //textFirstNameCart.Text = "";
            //textLastNameCart.Text = "";
            //textEmailCart.Text = "";
            //textDirectionCart.Text = "";

            //textDirectionCart.Text = "";
            //textEmailCart.Text = "";
            //textPhoneCart.Text = "";

            //  textDateCart.Text = "";
            //  textHourCart.Text = "";

            //   textNumDocumentCart.Text = "";
            //  textSerie2Cart.Text = "";
            //   textSerie1Cart.Text = "";
            //  textTypeDocumentCart.Text = "";


            //  textSubtotalCart.Text = "";
            //  textDescuentoCart.Text = "";
            //  textIva12Cart.Text = "";
            // textTypeDocumentCart.Text = "";
            //  textIva0Cart.Text = "";
            //  textTotalCartCart.Text = "";


        }

    }
}


