using System;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;
using Xamarin.Forms;
using System.Linq;

namespace AppUnap
{

	public class PAsignatura : ContentPage
    {
        //ListView para mostrar asignatura en la interfaz
        ListView lvw_asignatura = new ListView();
        //Lista con asignatura que se obtienen desde la consulta remota
        private List<CAsignatura> listaAsignatura;
        //Variable que almacena resultados desde el servidor
        String resultadosConsulta;

        public PAsignatura()
        {
            var datosUsuario = Xamarin.Auth.AccountStore.Create().FindAccountsForService(Application.Current.ToString()).FirstOrDefault();
            //Etiqueta superior
            Label lbl_titulo = new Label();
            lbl_titulo.Text = "Asignaturas";
            int rut = int.Parse(datosUsuario.Properties["Drut"]);
            //Carga Asignatura
            cargaAsignatura(rut);
            //Atributos de ListView Asignatura
            lvw_asignatura.VerticalOptions = LayoutOptions.FillAndExpand;
            lvw_asignatura.ItemTemplate = new DataTemplate(typeof(TAsignaturaCeldas));
            lvw_asignatura.VerticalOptions = LayoutOptions.StartAndExpand;

            //Al seleccionar una sede
            lvw_asignatura.ItemTapped += async (sender, e) =>
            {
                var datosAsignaturaSeleccionada = JsonConvert.SerializeObject(e.Item);

                //await Navigation.PushAsync(new PNota(datosAsignaturaSeleccionada));
                //((ListView)sender).SelectedItem = null;

            };


            Content = new StackLayout
            {
                Children = {
                    lbl_titulo,
                    lvw_asignatura
                }
            };

        }
        //Carga de datos de asignaturaint
        private async void cargaAsignatura(int rut)
        {
            lvw_asignatura.IsRefreshing = true;
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://209.208.28.88");//
                string url = string.Format("/serviciosremotos/asignaturas-alumno.php?p_rut=11200304");
                var response = await client.GetAsync(url);
                resultadosConsulta = response.Content.ReadAsStringAsync().Result;
            }
            catch (Exception)
            {
                await DisplayAlert("Error", "No hay conexion , Intente mas tarde", "Aceptar");

                cargaAsignatura(rut);
                return;
            }
            listaAsignatura = JsonConvert.DeserializeObject<List<CAsignatura>>(resultadosConsulta);
            lvw_asignatura.ItemsSource = listaAsignatura;
            lvw_asignatura.RowHeight = 100;
            lvw_asignatura.HeightRequest = 900;
            lvw_asignatura.EndRefresh();
            //lvw_asignatura.IsRefreshing = false;
        }
    }
}