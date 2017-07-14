using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace AppUnap
{
    public class TAsignaturaCeldas:ViewCell
    {
        public TAsignaturaCeldas()
        {
            //Label con valor estático
            Label lbl_titulo_celda = new Label();
            lbl_titulo_celda.Text = "CODIGO ASIGNATURA: ";
            lbl_titulo_celda.HorizontalTextAlignment = TextAlignment.Center;
            lbl_titulo_celda.TextColor = Color.White;

            //Label con valor dinámico CODIGO_ASIGNATURA
            Label lbl_CODIGO_ASIGNATURA = new Label();
            lbl_CODIGO_ASIGNATURA.SetBinding(Label.TextProperty, new Binding("CODIGO_ASIGNATURA"));
            lbl_CODIGO_ASIGNATURA.TextColor = Color.White;


            //Label con valor dinámico NOMBRE_ASIGNATURA
            Label lbl_NOMBRE_ASIGNATURA = new Label();
            lbl_NOMBRE_ASIGNATURA.SetBinding(Label.TextProperty, new Binding("NOMBRE_ASIGNATURA"));
            lbl_NOMBRE_ASIGNATURA.FontAttributes = FontAttributes.Bold;
            lbl_NOMBRE_ASIGNATURA.TextColor = Color.White;
            lbl_NOMBRE_ASIGNATURA.HorizontalTextAlignment = TextAlignment.Center;
            lbl_NOMBRE_ASIGNATURA.FontSize = 20;
            
            View = new StackLayout
            {
                
                BackgroundColor = Color.FromHex("#034E7C"),
                Children = { 
                    new StackLayout
                    {
                        Padding = new Thickness(0, 0, 0,15),
                        Orientation = StackOrientation.Horizontal,
                        Children =
                        {                        
                        lbl_titulo_celda,
                        lbl_CODIGO_ASIGNATURA,
                        },
                        
                    },
                    
                    lbl_NOMBRE_ASIGNATURA
                }
            };
        }


    }
}
