using AppRosa.Interface;
using AppRosa.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppRosa.ViewPage
{
    public partial class DeleteContactoPage : ContentPage
    {
        AppRosaInterface iml = null;
        UsuarioModel usuarioModelLocal = null;

        public DeleteContactoPage(AppRosaInterface ilm, UsuarioModel usuarioModel)
        {
            InitializeComponent();
            usuarioModelLocal = usuarioModel;

        }
    }
}