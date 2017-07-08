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
            Button btn1= new Button();
            btn1.Image = "notas.png";
            btn1.Text = "Calificaciones";
            btn1.HorizontalOptions = LayoutOptions.CenterAndExpand;
            btn1.ContentLayout = new ButtonContentLayout(ImagePosition.Top, 0);
            btn1.BackgroundColor = Color.White;

            Button btn2 = new Button();
            btn2.Image = "aulavirtual.png";
            btn2.Text = "Aula Virtual";
            btn2.HorizontalOptions = LayoutOptions.CenterAndExpand;
            btn2.ContentLayout = new ButtonContentLayout(ImagePosition.Top, 0);
            btn2.BackgroundColor = Color.White;

            Image imgLogo = new Image();
            imgLogo.Source = "png_logounap.png";

            Content = new StackLayout
            {
                Padding = new Thickness(0, 50, 0, 0),
                VerticalOptions = LayoutOptions.StartAndExpand,
                Children =
                {
                    imgLogo,

                     new StackLayout
                {
                    Padding = new Thickness (0, 50, 0, 0),
                    Orientation = StackOrientation.Horizontal,
                    Children =
                    {
                        btn1,
                        btn2,
                    }
                },
                
                }
            
        
            };
        }
    }
}