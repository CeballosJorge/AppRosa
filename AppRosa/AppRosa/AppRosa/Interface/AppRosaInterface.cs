using AppRosa.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppRosa.Interface
{
    public interface AppRosaInterface
    {
        void ShowMainPage(UsuarioModel modelUsuarioLocal);
        void ShowLogout();
        void showAgregarContactoPage(UsuarioModel modelUsuarioLocal);
        void showContactosPage(UsuarioModel modelUsuarioLocal); 
        void ShowDeleteContactoPage(UsuarioModel modelUsuarioLocal);
    }
}
