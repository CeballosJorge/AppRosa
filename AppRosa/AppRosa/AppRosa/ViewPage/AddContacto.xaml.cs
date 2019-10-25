using AppRosa.Interface;
using AppRosa.Model;
using AppRosa.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppRosa.ViewPage
{
    public partial class AddContacto : ContentPage
    {
        AppRosaInterface iml = null;
        UsuarioModel usuarioModelLocal = null;
        public AddContacto(AppRosaInterface ilm, UsuarioModel usuarioModel)
        {
            InitializeComponent();
            iml = ilm;
            usuarioModelLocal = usuarioModel;

        }
        void btnGuardarClick(Object sender, EventArgs e)
        {
            if (nombre.Text == null || telefono.Text == null)
            {
                DisplayAlert("Alert", "Comprueba que los datos introducidos sean los correctos", "OK");
            }
            else
            {
                ConsultaUsuarioPassword(nombre.Text, telefono.Text);
            }
        }
        void btnRegresarClick(object sender, EventArgs e)
        {
            iml.ShowMainPage(usuarioModelLocal);
        }
        public async void ConsultaUsuarioPassword(String nombre, String telefono)
        {
            HttpClient cliente = new HttpClient();
            string url = (string.Format(Constante.loginUrl + nombre + "/" + telefono.Replace(" ", "")));
            var resultado = await cliente.GetAsync(url);
            if (resultado.IsSuccessStatusCode)
            {
                var json = resultado.Content.ReadAsStringAsync().Result;
                List<UsuarioModel> modelUsuario = Newtonsoft.Json.JsonConvert.DeserializeObject<List<UsuarioModel>>(json);

                if (modelUsuario[0].Result == 1)
                {
                    iml.ShowMainPage(modelUsuario[0]);
                }
                else
                {
                    await DisplayAlert("Alert", "No se encontro el usuario ingresado", "OK");
                }
            }
            else
            {
                await DisplayAlert("Alert", "Hay un problema con la conexion", "OK");
                iml.ShowLogout();
            }
        }
    }
}