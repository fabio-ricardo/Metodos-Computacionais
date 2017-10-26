using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class FormulaInputModel
    {
        [Required]
        [Display(Name = "Método para Cálculo")]
        public MetodoEnum Metodo { get; set; }

        [Required]
        [Display(Name = "Função")]
        public string Funcao { get; set; }

        [Required]
        [Display(Name = "Intervalo A")]
        public int A { get; set; }

        [Required]
        [Display(Name = "Intervalo B")]
        public int B { get; set; }

    }
}