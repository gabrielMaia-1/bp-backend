using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Models
{
    public class PostoDto
    {
        public int? Id { get; set; }
        [Required(ErrorMessage = "Nome é obrigatório.")]
        [MinLength(3, ErrorMessage = "Nome não pode ser menor que 3 caracteres")]
        [MaxLength(96, ErrorMessage = "Nome não pode ser maior que 96 caracteres")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Latitude é obrigatório.")]
        public double Latitude { get; set; }
        [Required(ErrorMessage = "Longitude é obrigatório.")]
        public double Longitude { get; set; }
        public List<CombustivelDto> Combustivel { get; set; }
    }
}
