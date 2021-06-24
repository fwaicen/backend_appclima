using System;
using System.Collections.Generic;

#nullable disable

namespace AppClima.Models
{
    public partial class Historico
    {
        public int Id { get; set; }
        public string PaisNombre { get; set; }
        public string CiudadNombre { get; set; }
        public decimal Clima { get; set; }
        public decimal SensacionTermica { get; set; }
        public string Icon { get; set; }
    }
}
