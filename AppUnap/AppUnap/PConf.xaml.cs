using Plugin.Media;
using Plugin.Media.Abstractions;
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
        public PConf()
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

            Image fotoPerfil = new Image();

            Button btnFotoPerfil = new Button();
            //if(no se encuentra foto en la BD)
            //{
            btnFotoPerfil.Image = "imagenpordefecto.png";
            //}
            //else
            //{
            //    btnFotoPerfil.Image = "...";
            //}
            btnFotoPerfil.HorizontalOptions = LayoutOptions.Center;
            btnFotoPerfil.ContentLayout = new ButtonContentLayout(ImagePosition.Right, 0);
            btnFotoPerfil.BackgroundColor = Color.FromHex("#99A8C4");
            btnFotoPerfil.HeightRequest = 100;
            btnFotoPerfil.WidthRequest = 100;
            btnFotoPerfil.Clicked += async (sender, e) =>
            {
                var almacenamiento = new StoreCameraMediaOptions()
                {
                    SaveToAlbum = true,
                    Name = "perfilUnap.jpg",
                };
                var foto = await CrossMedia.Current.TakePhotoAsync(almacenamiento);
                fotoPerfil.Source = ImageSource.FromStream(() =>
                  {
                      var stream = foto.GetStream();
                      foto.Dispose();

                      return stream;
                  });
            };
            //manejar el almacenamiento de la foto en la DB 

            ////////
            //establecer la imagen del boton con la fuente desde la DB
            //btnFotoPerfil.Image = ImageSource
            //////

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
            btnGuardar.BackgroundColor = Color.FromHex("#046DAB");
            btnGuardar.TextColor = Color.FromHex("#FFFFFF");
            btnGuardar.Clicked += async (sender, e) =>
            {
                //guardar en DB
            };

            Button btnCerrarSesion = new Button();
            btnCerrarSesion.Text = "Cerrar Sesion";
            btnCerrarSesion.HorizontalOptions = LayoutOptions.Center;
            btnCerrarSesion.BackgroundColor = Color.White;
            btnCerrarSesion.BackgroundColor = Color.FromHex("#046DAB");
            btnCerrarSesion.TextColor = Color.FromHex("#FFFFFF");
            btnGuardar.Clicked += async (sender, e) =>
            {
                //cerrar sesion
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
                            btnFotoPerfil,
                        }
                    },
                        entEmail,
                        entCelular,
                        btnGuardar,
                        btnCerrarSesion
                },
            };
        }
    }
}
