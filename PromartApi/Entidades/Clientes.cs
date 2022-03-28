using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PromartApi.Entidades
{
    public class Clientes
    {
        public int? Id { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int Edad { get; set; }
    }
}
