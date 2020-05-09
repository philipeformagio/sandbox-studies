using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MinhaDemoMVC.Models
{
    public class Carro
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Modelo é obrigatório"), StringLength(100, MinimumLength = 3)]
        public string Modelo { get; set; }

        [Required(ErrorMessage = "O campo Modelo é obrigatório"), StringLength(100, MinimumLength = 3)]
        public string Construtora { get; set; }

        [Range(1, 1000, ErrorMessage = "Valor de 1 a 1000")]
        public decimal Preco { get; set; }
    }
}
