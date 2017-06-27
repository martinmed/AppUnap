using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;

using Xamarin.Forms;

namespace AppUnap
{
	public class PLogin : ContentPage
	{
		public PLogin ()
		{
            //Imagen con logo
            Image img_logo = new Image();
            img_logo.Source = "png_logounap.png";
                
            //Label con titulo
            Label lbl_titulo = new Label();
            lbl_titulo.Text = "Ingrese datos";

            //Entry para capturar email
            Entry ent_email = new Entry();
            ent_email.Placeholder = "Ingrese email";

            //Entry para capturar clave
            Entry ent_clave = new Entry();
            ent_clave.Placeholder = "Ingrese clave";
            ent_clave.IsPassword = true;

            //Button para ejecutar una accion
            Button btn_login = new Button();
            btn_login.Text = "Ingresar";
            btn_login.Clicked += async (sender, e) =>
            {
                String email = ent_email.Text;
                String clave = ent_clave.Text;

                //capturamos la respuesta del servidor
                var respuesta = validarAcceso(email, clave);
                //obtenemos los datos
                var datosResultados = JObject.Parse(respuesta);

                //se extrae la respuesta del servidor indicando si se logra o no la autenticacion
                String r = datosResultados["ENTRA"].ToString();

                //efectuamos una comparacion
                if (r.Equals("SI"))
                {
                    //TODO: guardar credenciales en el dispositivo
                    //redireccionamos a pprincipal
                    await Navigation.PushModalAsync(new PPrincipal());
                }
                else
                {
                    //mostrar un mensaje indicando que las credenciales no son validas
                    await DisplayAlert("LOGIN", "Usuario o clave incorrecta", "OK");
                }



                };

            Content = new StackLayout {
				Children = {
                    //se instancian los objetos creados en orden
					img_logo,
                    lbl_titulo,
                    ent_email,
                    ent_clave,
                    btn_login
				}
			};
		}

        string validarAcceso(string email, string clave)
        {
            WebClient clienteWeb = new WebClient();
            Uri uri = new Uri("http://209.208.28.88/servicios/demo-validar-usuario3.php");
            NameValueCollection parametros = new NameValueCollection();
            parametros.Add("p_email", email);
            parametros.Add("p_clave", clave);

            byte[] respuestaByte = clienteWeb.UploadValues(uri, "POST", parametros);
            string respuestaString = Encoding.UTF8.GetString(respuestaByte);

            return respuestaString;
        }
    }
}