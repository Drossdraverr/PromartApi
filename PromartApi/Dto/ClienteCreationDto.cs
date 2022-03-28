using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PromartApi.Dto
{
    public class ClienteCreationDto
    {
        [Required]
        public string Nombres { get; set; }
        [Required]
        public string Apellidos { get; set; }
        [Required]
        public DateTime FechaNacimiento { get; set; }
        [Required]
        public int Edad { get; set; }
    }
}
