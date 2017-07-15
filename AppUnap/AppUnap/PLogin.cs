using System;
using System.Net;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Newtonsoft.Json.Linq;
using Xamarin.Auth;
using Com.OneSignal;
using Xamarin.Forms.Xaml;

namespace AppUnap
{
    public class PLogin : ContentPage
	{

        public PLogin()
        {




            //			var cantidadCuenta = AccountStore.Create().FindAccountsForService(Application.Current.ToString()).Count();
            //            if (cantidadCuenta == 0)
            //            {
            //                Navigation.PushModalAsync(new PLogin());
            //            }
            //            else
            //            {
            //                Navigation.PushModalAsync(new PPrincipal());
            //            }


            //Imagen con logo
            Image img_logo = new Image();
            img_logo.Source = "png_logounap.png";
            

            //Label con titulo
            Label lbl_titulo = new Label();
            lbl_titulo.Text = "INGRESE DATOS";
            lbl_titulo.TextColor = Xamarin.Forms.Color.White;
            lbl_titulo.VerticalOptions = LayoutOptions.FillAndExpand;
            lbl_titulo.HorizontalOptions = LayoutOptions.Center;
            lbl_titulo.FontAttributes=FontAttributes.Bold;
            

            //Entry para capturar email
            Entry ent_email = new Entry();
            ent_email.Placeholder = "Ingrese email";
            ent_email.TextColor = Xamarin.Forms.Color.White;
            ent_email.PlaceholderColor = Xamarin.Forms.Color.White;
            ent_email.VerticalOptions = LayoutOptions.FillAndExpand;


            //Entry para capturar clave
            Entry ent_clave = new Entry();
            ent_clave.Placeholder = "Ingrese clave";
            ent_clave.IsPassword = true;
            ent_clave.PlaceholderColor = Xamarin.Forms.Color.White;
            ent_clave.TextColor = Xamarin.Forms.Color.White;
            ent_clave.VerticalOptions = LayoutOptions.FillAndExpand;

            //Button para ejecutar una accion
            Button btn_login = new Button();
            btn_login.BackgroundColor = Xamarin.Forms.Color.FromHex("#046DAB");
            btn_login.TextColor = Xamarin.Forms.Color.White;
            btn_login.Text = "Ingresar";
            btn_login.VerticalOptions = LayoutOptions.FillAndExpand;
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
                    /*FGANGA obtiene los datos del usuario que inició sesión */
                    var respuestaDatosUsuario = obtenerDatosUsuario(email);

                    var datosResultadoUsuario = JArray.Parse(respuestaDatosUsuario);
					//Obtenemos Los datos de usuario desde la respuesta del servidor
                    int p_rut               = Convert.ToInt32(datosResultadoUsuario[0]["RUT"].ToString());
                    string p_nombre         = datosResultadoUsuario[0]["NOMBRE"].ToString();
					string p_apellido       = datosResultadoUsuario[0]["APELLIDO"].ToString();
                    string p_url_foto       = datosResultadoUsuario[0]["URL_FOTO"].ToString();
                    int p_id_carrera        = Convert.ToInt32(datosResultadoUsuario[0]["ID_CARRERA"].ToString());
                    string p_nombre_carrera = datosResultadoUsuario[0]["NOMBRE_CARRERA"].ToString();
					int p_id_sede           = Convert.ToInt32(datosResultadoUsuario[0]["ID_SEDE"].ToString());
					string p_nombre_sede    = datosResultadoUsuario[0]["NOMBRE_SEDE"].ToString();
                    

                    Account cuentaUsuario = new Account(email, CuentaUsuario.Dictionary(email,p_rut,p_nombre,p_apellido,p_url_foto,p_id_carrera,p_nombre_carrera,p_id_sede,p_nombre_sede));

                    AccountStore.Create().Save(cuentaUsuario, App.Current.ToString());

                    OneSignal.Current.StartInit("476618db-f2f3-4fb7-940f-530bee13e428").EndInit();

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

                BackgroundColor = Xamarin.Forms.Color.FromHex("#046DAB"),
            Children = {
                    //se instancian los objetos creados en orden
					img_logo,
                    new StackLayout
                    {
                        Padding = new Thickness (0, 20, 0, 0),
                        Children =
                        {
                            lbl_titulo,
                            ent_email,
                            ent_clave,
                            btn_login
                        }
                    },
                    
				}
			};
		}

        string validarAcceso(string email,string clave)
        {
            WebClient clienteWeb = new WebClient();
            Uri uri = new Uri("http://209.208.28.88/serviciosremotos/autentificacion.php");
            NameValueCollection parametros = new NameValueCollection();
            parametros.Add("p_email", email);
            parametros.Add("p_clave", clave);
            
            byte[] respuestaByte = clienteWeb.UploadValues(uri, "POST", parametros);
            string respuestaString = Encoding.UTF8.GetString(respuestaByte);

            return respuestaString;
        }

        string obtenerDatosUsuario(string email)
        {
            WebClient cliente = new WebClient();
            Uri uri = new Uri("http://209.208.28.88/serviciosremotos/datos-alumno.php");
            NameValueCollection parametros = new NameValueCollection();
            parametros.Add("p_email", email);
          
            byte[] responseBytes = cliente.UploadValues(uri, "POST", parametros);
            string responseString = Encoding.UTF8.GetString(responseBytes);
            return responseString;
        }
		
    }
    internal class CuentaUsuario
    {
            /*FGANGA Incorpora nuevos datos de usuario*/            
        public static IDictionary<string, string> Dictionary(string email, int rut, string nombre, string apellido, string url_foto,int id_carrera,string nombre_carrera,int id_sede,string nombre_sede)
        {
            IDictionary<string, string> d = new Dictionary<string, string>();
            d.Add("Demail", email);
            d.Add("Drut", rut.ToString());
            d.Add("Dnombre",nombre);
            d.Add("Dapellido", apellido);
            d.Add("Durlfoto", url_foto);
            d.Add("Did_carrera",id_carrera.ToString());
            d.Add("Dnombre_carrera", nombre_carrera);
            d.Add("Did_sede", id_sede.ToString());
            d.Add("Dnombre_sede", nombre_sede);
                  
            
            return d;
        }
    }
}