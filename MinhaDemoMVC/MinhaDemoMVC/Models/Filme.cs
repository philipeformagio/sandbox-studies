using Microsoft.CodeAnalysis.Operations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MinhaDemoMVC.Models
{
    public class Filme
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Titulo é obrigatório.")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "O titulo precisa ter entre 3 ou 60 caracteres.")]
        public string Titulo { get; set; }

        public DateTime DataLacamento { get; set; }

        public string Genero { get; set; }

        public decimal Valor { get; set; }

        public int Avaliacao { get; set; }
    }
}
