using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppClima.Models
{
    public class Weather
    {
        public Coordenadas coordenadas { get; set; }
        public WeatherRef[] weather { get; set; }
        public string bases { get; set;}
        public Main main { get; set; }
        public int visibiliy { get; set; }
        public Wind wind { get; set; }
        public Clouds clouds { get; set; }
        public int dt { get; set; }
        public Sys sys { get; set; }
        public int timeZone { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public int cod { get; set; }

        public class Coordenadas
        {
            public decimal lon { get; set; }
            public decimal lat { get; set; }
        }

        public class WeatherRef
        {
            public int id { get; set; }
            public string main { get; set; }
            public string description { get; set; }
            public string icon { get; set; }
        }

        public class Main
        {
            public decimal temp { get; set; }
            public decimal feels_like { get; set; }
            public decimal temp_min { get; set; }
            public decimal temp_max { get; set; }
            public int pressure { get; set; }
            public int humidity { get; set; }
        }

        public class Wind
        {
            public decimal speed { get; set; }
            public int deg { get; set; }
        }

        public class Clouds
        {
            public int all { get; set; }
        }

        public class Sys
        {
            public int type { get; set; }
            public int id { get; set; }
            public decimal message { get; set; }
            public string country { get; set; }
            public int sunrise { get; set; }
            public int sunset { get; set; }
        }
    }
}
