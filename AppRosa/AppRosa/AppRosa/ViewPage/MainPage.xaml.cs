using AppRosa.Interface;
using AppRosa.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace AppRosa
{
    public partial class MainPage : ContentPage
    {
        AppRosaInterface iml = null;
        UsuarioModel usuarioModelLocal = null;
        string locationString = null;

        public MainPage(AppRosaInterface ilm, UsuarioModel usuarioModel)
        {
            InitializeComponent();
            usuarioModelLocal = usuarioModel;
        }
        void btnLogoutClick(object sender, EventArgs e)
        {
            iml.ShowLogout();
        }

        void btnEnviarUbicacionClick(object sender, EventArgs e)
        {
            findLocation();

            //Agregar el metodo que envie la ubicacion ala base de datos
        }

        void btnAgregarContactoClick(object sender, EventArgs e)
        {
            iml.showAgregarContactoPage(usuarioModelLocal);
        }

        void btnContactosClick(object sender, EventArgs e)
        {
            iml.showContactosPage(usuarioModelLocal);
        }

        void btnBajaContactoClick(object sender, EventArgs e)
        {
            iml.ShowDeleteContactoPage(usuarioModelLocal);
        }

        async void findLocation()
        {
            var request = new GeolocationRequest(GeolocationAccuracy.Medium);
            var location = await Geolocation.GetLocationAsync(request);

            if (location != null)
            {
                locationString = ($"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}");
            }
        }
    }
}
    // #870A30   #EC8FD0    #D43790    #F2C5E0
    //Burgundy   Magenta     Pink      HotPink
