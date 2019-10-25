using AppRosa.Interface;
using AppRosa.Model;
using AppRosa.Util;
using AppRosa.ViewModel;
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
    public partial class ShowContactos : ContentPage
    {
        AppRosaInterface iml = null;
        UsuarioModel usuarioModelLocal = null;
        ListUsuarioModel listUsuarioModel = new ListUsuarioModel();

        public ShowContactos(AppRosaInterface ilm, UsuarioModel usuarioModel)
        {
            InitializeComponent();
            iml = ilm;
            usuarioModelLocal = usuarioModel;
            List<Label> listLabel = new List<Label>();

            ConsultarListaDetalle();

            foreach (UsuarioModel usuario in listUsuarioModel.Table)
            {
                Button buttonContacto = new Button();

                //Label label = new Label();
                buttonContacto.Text = usuario.NombreUsuario;
                buttonContacto.VerticalOptions = LayoutOptions.Center;
                buttonContacto.TextColor = Color.Red;
                buttonContacto.FontAttributes = FontAttributes.Bold;
                buttonContacto.WidthRequest = 350;

                LayoutDataForm.Children.Add(buttonContacto);

                StackLayout mistacklayout = this.Content.FindByName<StackLayout>("LayoutDataForm");
                mistacklayout.Children.Add(buttonContacto);
            }
            Button buttonAgregarContacto = new Button();
            buttonAgregarContacto.Text = "Agregar Contacto";
            buttonAgregarContacto.Clicked += AgregarContactoClick;
            buttonAgregarContacto.HorizontalOptions = LayoutOptions.Center;
            buttonAgregarContacto.BackgroundColor = Color.FromHex("#EC8FD0");

            Button buttonMainPage = new Button();
            buttonMainPage.Text = "Regresar";
            buttonMainPage.Clicked += btnReturnClick;
            buttonMainPage.HorizontalOptions = LayoutOptions.Center;
            buttonMainPage.BackgroundColor = Color.FromHex("#EC8FD0");
        }
        void AgregarContactoClick(object sender, EventArgs e)
        {
            iml.showAgregarContactoPage(usuarioModelLocal);
        }
        void btnReturnClick(object sender, EventArgs e)
        {
            iml.ShowMainPage(usuarioModelLocal);
        }
        async void ConsultarListaDetalle()
        {
            HttpClient cliente = new HttpClient();
            string url = (string.Format(Constante.usuarioUrl));
            var resultado = await cliente.GetAsync(url);
            if (resultado.IsSuccessStatusCode)
            {
                var json = resultado.Content.ReadAsStringAsync().Result;
                listUsuarioModel = Newtonsoft.Json.JsonConvert.DeserializeObject<ListUsuarioModel>(json);
            }
            else
            {
                await DisplayAlert("Alert", "Error de red", "OK");
                iml.ShowMainPage(usuarioModelLocal);
            }
        }
    }
}