using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Encuestas.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string NombreUsuario { get; set; }
        public string Correo { get; set; }
        public string Clave { get; set; }
    }
}