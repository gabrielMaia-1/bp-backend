using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Models
{
    public class TipoCombustivelDto
    {
        public int? Id { get; set; }
        [Required(AllowEmptyStrings =false, ErrorMessage = "nome é obrigatório")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "aditivado é obrigatório")]
        public bool Aditivado { get; set; }
    }
}
