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
            lbl_titulo_celda.Text = "DATOS ASIGNATURA";

            //Label con valor dinámico CODIGO_ASIGNATURA
            Label lbl_CODIGO_ASIGNATURA = new Label();
            lbl_CODIGO_ASIGNATURA.SetBinding(Label.TextProperty, new Binding("CODIGO_ASIGNATURA"));

            //Label con valor dinámico NOMBRE_ASIGNATURA
            Label lbl_NOMBRE_ASIGNATURA = new Label();
            lbl_NOMBRE_ASIGNATURA.SetBinding(Label.TextProperty, new Binding("NOMBRE_ASIGNATURA"));
                        
            View = new StackLayout
            {
                Children = {
                    lbl_titulo_celda,
                    lbl_CODIGO_ASIGNATURA,
                    lbl_NOMBRE_ASIGNATURA
                }
            };
        }


    }
}
