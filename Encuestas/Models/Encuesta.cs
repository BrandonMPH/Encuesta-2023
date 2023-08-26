using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Encuestas.Models
{
    public class Encuesta
    {
        public int IdEncuesta { get; set; }
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
    }
}