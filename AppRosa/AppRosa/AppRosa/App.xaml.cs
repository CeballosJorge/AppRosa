using AppRosa.Interface;
using AppRosa.Model;
using AppRosa.ViewPage;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppRosa
{
    public partial class App : Application, AppRosaInterface
    {
        static AppRosaInterface appRosaInterface;
        public static int val;
        public App()
        {
            InitializeComponent();
            Current = this;
            UsuarioModel modelUsuarioLocal = new UsuarioModel();
            MainPage = new MainPage(this, modelUsuarioLocal);

//             MainPage = new LoginPage(this);
        }

        public void ShowMainPage(UsuarioModel modelUsuarioLocal)
        {
            MainPage = new MainPage(this, modelUsuarioLocal);
        }

        public void showAgregarContactoPage(UsuarioModel modelUsuarioLocal)
        {
            MainPage = new AddContacto(this, modelUsuarioLocal);
        }

        public void showContactosPage(UsuarioModel modelUsuarioLocal)
        {
            MainPage = new ShowContactos(this, modelUsuarioLocal);
        }

        public void ShowDeleteContactoPage(UsuarioModel modelUsuarioLocal)
        {
            MainPage = new DeleteContactoPage(this, modelUsuarioLocal);
        }

        public void ShowLogout()
        {
            MainPage = new LoginPage(this);
        }
    }
}
