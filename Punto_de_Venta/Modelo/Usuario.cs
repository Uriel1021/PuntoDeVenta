using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Punto_de_Venta.Modelo
{
    internal class Usuario
    {
        private int usuarioId;
        private string user;
        private string contrasenia;


        public int UsuarioId
        {
            get { return usuarioId; }
            set { usuarioId = value; }
        }

        public string User
        {
            get { return user; }
            set { user = value; }
        }

        public string Contrasenia
        {
            get { return contrasenia; }
            set { contrasenia = value; }
        }
    }
}
