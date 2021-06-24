using System;
using System.Collections.Generic;

#nullable disable

namespace AppClima.Models
{
    public partial class Pais
    {
        public Pais()
        {
            Ciudades = new HashSet<Ciudad>();
        }

        public string PaisCodigo { get; set; }
        public string PaisNombre { get; set; }

        public virtual ICollection<Ciudad> Ciudades { get; set; }
    }
}
