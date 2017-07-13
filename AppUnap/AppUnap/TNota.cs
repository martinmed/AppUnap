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
            //Label con valor estático
            Label lbl_titulo_celda = new Label();
            lbl_titulo_celda.Text = "DATOS NOTA";


            //Label con valor dinámico id_nota
            Label lbl_id_nota = new Label();
            lbl_id_nota.SetBinding(Label.TextProperty, new Binding("CODIGO_ASIGNATURA"));

            Label lbl_nota = new Label();
            lbl_nota.SetBinding(Label.TextProperty, new Binding("nota"));




            View = new StackLayout
            {
                Children = {
                    lbl_titulo_celda,
                    lbl_id_nota,
                    lbl_nota
                }
            };
        }
    }
}
