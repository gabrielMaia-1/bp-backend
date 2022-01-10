using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Combustivel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public Posto Posto { get; set; }
        [Required]
        public TipoCombustivel TipoCombustivel { get; set; }
        [Required]
        [Range(0.0,9999.0)]
        public decimal PrecoLitro { get; set; }
    }
}
