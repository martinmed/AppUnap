using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using static Xamarin.Forms.Button;
using static Xamarin.Forms.Button.ButtonContentLayout;

namespace AppUnap
{
    public class PPrincipal : ContentPage
    {
        public PPrincipal()
        {
            /*FGANGA Obtiene los datos desde el accountstore*/

            var datosUsuario = Xamarin.Auth.AccountStore.Create().FindAccountsForService(Application.Current.ToString()).FirstOrDefault();
            //TODO: asignar nombre de usuario a esta variable
            string nombre= datosUsuario.Properties["Dnombre"];
            string apellido = datosUsuario.Properties["Dapellido"];
            //////////////

            Button btnNotas= new Button();
            btnNotas.Image = "notas.png";
            btnNotas.Text = "Calificaciones";
            btnNotas.HorizontalOptions = LayoutOptions.CenterAndExpand;
            btnNotas.ContentLayout = new ButtonContentLayout(ImagePosition.Top, 0);
            btnNotas.BackgroundColor = Color.FromHex("#046DAB");
            btnNotas.TextColor = Color.White;
            
            btnNotas.Clicked += async (sender, e) =>
            {
                await Navigation.PushModalAsync(new PAsignatura());
            };

                ListView lv1 = new ListView(); 

            Button btnAulaVirtual = new Button();
            btnAulaVirtual.Image = "aulavirtual.png";
            btnAulaVirtual.Text = "Aula Virtual";
            btnAulaVirtual.HorizontalOptions = LayoutOptions.CenterAndExpand;
            btnAulaVirtual.ContentLayout = new ButtonContentLayout(ImagePosition.Top, 0);
            btnAulaVirtual.BackgroundColor = Color.FromHex("#046DAB");
            btnAulaVirtual.TextColor = Color.White;
            btnAulaVirtual.Clicked += (sender, e) =>
            {
                Device.OpenUri(new Uri("http://www.unap.cl/campus_online/"));
            };


            Image imgLogo = new Image();
            imgLogo.Source = "png_logounap.png";

            Label lblBienvenido = new Label();
            lblBienvenido.Text = "Bienvenido " + nombre +" "+apellido;
            lblBienvenido.TextColor = Color.White;
            lblBienvenido.HorizontalTextAlignment = TextAlignment.Center;
            lblBienvenido.FontSize = 25;
            lblBienvenido.FontAttributes = FontAttributes.Bold;

            Button btnConfiguracion = new Button();
            btnConfiguracion.Image = "engranaje.png";
            btnConfiguracion.HorizontalOptions = LayoutOptions.Center;
            btnConfiguracion.ContentLayout = new ButtonContentLayout(ImagePosition.Right, 0);
            btnConfiguracion.BackgroundColor = Color.FromHex("#046DAB");
            btnConfiguracion.Scale=0.4;
            btnConfiguracion.Clicked += async (sender, e) =>
            {
                await Navigation.PushModalAsync(new PConf());
            };



            Content = new StackLayout
            {
                //"#046DAB"=azul claro #034E7C azul oscuro
                BackgroundColor = Color.FromHex("#046DAB"),
                Padding = new Thickness(0, 10, 0, 0),
                VerticalOptions = LayoutOptions.FillAndExpand,
                Children =
                {
                imgLogo,
                lblBienvenido,

                     new StackLayout
                {
                    Padding = new Thickness (0, 10, 0, 0),
                    Orientation = StackOrientation.Horizontal,
                    Children =
                    {
                        btnNotas,
                        btnAulaVirtual,
                    }
                },
                     new AbsoluteLayout
                     {                        
                        VerticalOptions = LayoutOptions.End,
                        HorizontalOptions=LayoutOptions.CenterAndExpand,

                         Children =
                         {
                             btnConfiguracion,
                         }
                     }
                     
                
                }
            
        
            };
        }
    }
}