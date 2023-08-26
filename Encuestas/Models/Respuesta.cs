using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Encuestas.Models
{
    public class Respuesta
    {
        public int IdRespuesta { get; set; }
        public int IdEncuesta { get; set; } 
        public int IdDetalle { get; set; } 
        public string Valor { get; set; }
        public string Pregunta { get; set; }
    }
}