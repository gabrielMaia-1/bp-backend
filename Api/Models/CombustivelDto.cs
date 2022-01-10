using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Models
{
    public class CombustivelDto
    {
        public int? Id { get; set; }
        [Required(ErrorMessage = "idPosto é obrigatório")]
        public PostoDto Posto { get; set; }
        [Required(ErrorMessage = "tipo é obrigatório")]
        public TipoCombustivelDto Tipo { get; set; }
        [Range(0.0, 9999.0)]
        [Required(ErrorMessage = "preco é obrigatório")]
        public decimal Preco { get; set; }
    }
}
