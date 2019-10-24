using System;
using System.Collections.Generic;
using System.Text;

namespace AppRosa.Model
{
    public class UsuarioModel
    {
        public int Result { get; set; }
        public int ClaUsuario { get; set; }
        public string NombreUsuario {get;set;}
        public string TelefonoUsuario { get; set; }
        public string ApiKeyResult { get; set; }
        public DateTime CaducaResult { get; set; }

    }
}
