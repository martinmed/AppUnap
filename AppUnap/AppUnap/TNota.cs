using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;


namespace AppUnap
{
    public class TNota : ViewCell
    {
        public TNota()
        {
            
            


            //Label con valor dinámico id_nota
            Label lbl_id_nota = new Label();
            lbl_id_nota.SetBinding(Label.TextProperty, new Binding("DESCRIPCION_EVALUACION"));
            lbl_id_nota.TextColor = Color.White;
            lbl_id_nota.HorizontalOptions = LayoutOptions.CenterAndExpand;

            Label lbl_nota = new Label();
            lbl_nota.SetBinding(Label.TextProperty, new Binding("NOTA"));
            lbl_nota.FontAttributes = FontAttributes.Bold;
            lbl_nota.TextColor = Color.White;
            lbl_nota.HorizontalOptions = LayoutOptions.EndAndExpand;
            lbl_nota.BackgroundColor = Color.FromHex("#034E7C");
            





            View = new StackLayout
            {
                BackgroundColor = Color.FromHex("#034E7C"),
                Children = {

                    new StackLayout
                    {
                        Padding = new Thickness(0, 0, 10,0),
                        BackgroundColor = Color.FromHex("#034E7C"),
                        Orientation = StackOrientation.Horizontal,
                        Children =
                        {
                        
                        lbl_id_nota,
                        lbl_nota
                        },

                    },                   
                    
                }
            };
        }
    }
}
