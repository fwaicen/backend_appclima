using System;
using System.Collections.Generic;

#nullable disable

namespace AppClima.Models
{
    public partial class Ciudad
    {
        public int CiudadId { get; set; }
        public string CiudadNombre { get; set; }
        public string PaisCodigo { get; set; }

        public string PaisNombre { get; set; }

    }
}
