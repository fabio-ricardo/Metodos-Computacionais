using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class InterpolacaoModel
    {
        [Required]
        [Display(Name = "Método para Cálculo")]
        public InterpolacaoEnum Metodo { get; set; }

        [Required]
        [Display(Name = "Pontos")]
        public string PontosString { get; set; }

        public string[] Pontos{ get; set; }
    }
}