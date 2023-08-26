using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Encuestas.Models
{
    public class Detalle
    {
        public int IdDetalle { get; set; }
        public int IdEncuesta { get; set; }
        public string NombreCampo { get; set; }
        public string Titulo { get; set; }
        public string EsRequerido { get; set; }
        public string TipoCampo { get; set; }
        public string TipoCambioValor { get; set; }
    }
}