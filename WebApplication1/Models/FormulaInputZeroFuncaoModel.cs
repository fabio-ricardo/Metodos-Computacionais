using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class FormulaInputZeroFuncaoModel
    {
        [Required]
        [Display(Name = "Método para Cálculo")]
        public ZeroFuncaoEnum Metodo { get; set; }

        [Required]
        [Display(Name = "Função")]
        public string Funcao { get; set; }

        [Display(Name = "Derivada")]
        public string Derivada { get; set; }

        [Required]
        [Display(Name = "Intervalo A")]
        public float A { get; set; }

        [Display(Name = "Intervalo B")]
        public float? B { get; set; }
        [Required]
        public double Erro { get; set; }

    }
}