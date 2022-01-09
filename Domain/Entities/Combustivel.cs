using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Combustivel
    {
        public ulong Id { get; set; }
        public Posto Posto { get; set; }
        public TipoCombustivel TipoCombustivel { get; set; }
        public decimal PrecoLitro { get; set; }
    }
}
