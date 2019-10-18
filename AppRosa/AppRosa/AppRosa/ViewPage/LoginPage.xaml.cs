
using AppRosa.Interface;
using AppRosa.Model;
using AppRosa.Util;
using System;
using System.Collections.Generic;
using System.Net.Http;
using Xamarin.Forms;

namespace AppRosa
{
    public partial class LoginPage : ContentPage
    {
        AppRosaInterface iml = null;
        public LoginPage(AppRosaInterface ilm)
        {
            InitializeComponent();
            iml = ilm;
        }
        void btnLoginClick(Object sender, EventArgs e)
        {
            if (userName.Text == null || password.Text == null)
            {
                DisplayAlert("Alert", "Comprueba que los datos introducidos sean los correctos", "OK");
            }
            else
            {
                ConsultaUsuarioPassword(userName.Text, password.Text);
            }
        }

        public async void ConsultaUsuarioPassword(String UserName, String Password)
        {
            HttpClient cliente = new HttpClient();
            string url = (string.Format(Constante.loginUrl + UserName.Replace(" ", "") + "/" + Password.Replace(" ", "")));
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