using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public enum ZeroFuncaoEnum
    {
        [Display(Name = "Bissecção")]
        Bisseccao = 1,

        [Display(Name = "Posição Falsa")]
        Posicao_Falsa = 2,

        [Display(Name = "Newton-Ralphson")]
        Newton_Ralphson = 3,

        [Display(Name = "Secante")]
        Secante = 4

    }
}