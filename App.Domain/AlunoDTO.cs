using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace App.Domain
{
    public class AlunoDTO
    {
        public int id { get; set; }

        [Required(ErrorMessage = "*Campo nome preenchimento obrigatório*")]
        [StringLength(50, ErrorMessage = "Mínimo de caracteres são 3 e o máximo são 50", MinimumLength = 3)]
        public string nome { get; set; }

        public string sobrenome { get; set; }

        public string telefone { get; set; }

        [Required(ErrorMessage = "*Campo Ra preenchimento obrigatório*")]
        [Range(1, 1000, ErrorMessage = "Cadastro de RA deve ser entre 1 e 10000")]
        public int? ra { get; set; }
    }
}