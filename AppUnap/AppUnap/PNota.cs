using System;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;
using Xamarin.Forms;
using System.Linq;
using System.Diagnostics;

namespace AppUnap
{
    public class PNota : ContentPage
    {
        private CAsignatura objetoAsignatura;
        ListView lvw_nota = new ListView();
        private List<CNota> listaNota;
        String resultadosConsulta;


        public PNota(String asignaturaSeleccionada)
        {
            

            Title = "Notas";
            //Deserializamos para obtener los datos de la asignatura seleccionada en listview y enviada al constructor de esta clave como String
            //El objeto de la clase Asignatura contiene los datos de la Asignatura seleccionada anteriormente
            objetoAsignatura = JsonConvert.DeserializeObject<CAsignatura>(asignaturaSeleccionada);

            //Id de la Asignatura para consultar el método remoto
            
            var datosUsuario = Xamarin.Auth.AccountStore.Create().FindAccountsForService(Application.Current.ToString()).FirstOrDefault();

            //Etiqueta superior
            Label lbl_titulo = new Label();
            lbl_titulo.Text = "Notas de la asignatura ";
           


            int id_curso = objetoAsignatura.ID_CURSO;
            //Carga Notas de la asignatura 
            cargaNotaAsignatura(int.Parse(datosUsuario.Properties["Drut"]),id_curso);
            //Atributos de ListView Asignatura
            lvw_nota.VerticalOptions = LayoutOptions.FillAndExpand;
            lvw_nota.ItemTemplate = new DataTemplate(typeof(TNota));
            lvw_nota.VerticalOptions = LayoutOptions.StartAndExpand;
          

            Content = new StackLayout
            {
                Children = {
                    lbl_titulo,
                    lvw_nota

                }

            };
            
        }
       //Carga de datos de notas de la asignatura
        private async void cargaNotaAsignatura(int rut,int id_curso)
        {

            lvw_nota.IsRefreshing = true;
            try
            {

                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://209.208.28.88");
                string url = string.Format("/serviciosremotos/evaluaciones-asignaturas-alumno.php?p_rut="+rut+"&p_id_curso="+id_curso);
                

                var response = await client.GetAsync(url);
                resultadosConsulta = response.Content.ReadAsStringAsync().Result;
                

            }
            catch (Exception e)
            {
                await DisplayAlert("Error", "No hay conexion , Intente mas tarde", "Aceptar");

                //cargaNotaAsignatura(CODIGO_ASIGNATURA);
                //return;
            }
            listaNota = JsonConvert.DeserializeObject<List<CNota>>(resultadosConsulta);
            lvw_nota.ItemsSource = listaNota;
            lvw_nota.RowHeight = 100;
            lvw_nota.HeightRequest = 900;
            lvw_nota.EndRefresh();
            // lvw_nota.IsRefreshing = false;
        }

    }
}