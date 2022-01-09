using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Posto
    {
        public ulong Id { get; set; }
        [Required, MaxLength(96)]
        public string Nome { get; set; }
        public List<Combustivel> Combustivel { get; set; }
        [Required]
        public double Latitude { get; set; }
        [Required]
        public double Longitude { get; set; }
    }
}
