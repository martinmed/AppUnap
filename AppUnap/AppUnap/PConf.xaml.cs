using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static Xamarin.Forms.Button;
using static Xamarin.Forms.Button.ButtonContentLayout;

namespace AppUnap
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PConf : ContentPage
	{
		public PConf ()
		{
            Image imgLogo = new Image();
            imgLogo.Source = "png_logounap.png";
            imgLogo.WidthRequest = 100;
            imgLogo.HeightRequest = 100;

            Label lblTitulo = new Label();
            lblTitulo.Text = "Mis Datos Personales";
            lblTitulo.TextColor = Color.FromHex("#046DAB");
            lblTitulo.HorizontalTextAlignment = TextAlignment.Center;
            lblTitulo.FontSize = 25;
            lblTitulo.FontAttributes = FontAttributes.Bold;
            lblTitulo.VerticalTextAlignment = TextAlignment.Center;

            Button fotoPerfil = new Button();
            fotoPerfil.Image = "imagenpordefecto.png";
            fotoPerfil.HorizontalOptions = LayoutOptions.Center;
            fotoPerfil.ContentLayout = new ButtonContentLayout(ImagePosition.Right, 0);
            fotoPerfil.BackgroundColor = Color.White;
            fotoPerfil.HeightRequest = 100;
            fotoPerfil.WidthRequest = 100;
            fotoPerfil.Clicked += async (sender, e) =>
            {
                //Manejar camara
            };

                Label lblNombre = new Label();
            lblNombre.Text = "Nombre Apellido Apellido";
            lblNombre.TextColor = Color.FromHex("#046DAB");
            lblNombre.HorizontalTextAlignment = TextAlignment.Center;
            lblNombre.FontSize = 22;
            lblNombre.FontAttributes = FontAttributes.Bold;
            lblNombre.VerticalTextAlignment = TextAlignment.Center;

            Label lblRut = new Label();
            lblRut.Text = "12.345.678-9";
            lblRut.TextColor = Color.FromHex("#046DAB");
            lblRut.HorizontalTextAlignment = TextAlignment.Center;
            lblRut.FontSize = 22;
            lblRut.FontAttributes = FontAttributes.Bold;
            lblRut.VerticalTextAlignment = TextAlignment.Center;

            Entry entEmail = new Entry();
            entEmail.Placeholder = "direccion@email.com";
            
            Entry entCelular = new Entry();
            entCelular.Placeholder = "+56 9 987654321";

            Button btnGuardar = new Button();
            btnGuardar.Text = "Guardar";
            btnGuardar.HorizontalOptions = LayoutOptions.Center;
            btnGuardar.BackgroundColor = Color.White;
            //btnGuardar.HeightRequest = 100;
            //btnGuardar.WidthRequest = 100;
            btnGuardar.BackgroundColor = Color.FromHex("#046DAB");
            btnGuardar.TextColor = Color.FromHex("#FFFFFF");
            btnGuardar.Clicked += async (sender, e) =>
            {
                //guardar en DB
            };

                Content = new StackLayout
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                Children =
                {
                    new StackLayout
                    {
                        Padding = new Thickness (0, 10, 0, 0),
                        Orientation = StackOrientation.Horizontal,
                        Children =
                        {
                            imgLogo,lblTitulo,
                        }
                    },                        
                    new StackLayout
                    {
                        Padding = new Thickness (0, 10, 0, 0),
                        Orientation = StackOrientation.Horizontal,
                        Children =
                        {
                            new StackLayout
                            {
                                Orientation = StackOrientation.Vertical,
                                HorizontalOptions=LayoutOptions.Center,
                                VerticalOptions=LayoutOptions.Center,
                                    Children =
                                        {
                                            lblNombre,
                                            lblRut
                                        }
                            },
                            fotoPerfil,
                        }
                    },
                        entEmail,
                        entCelular,
                        btnGuardar,
                },
            };
        }
    }
}
