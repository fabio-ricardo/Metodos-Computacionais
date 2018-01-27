using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public enum InterpolacaoEnum
    {
        [Display(Name = "Forma de Lagrange")]
        Lagrange = 1,

        [Display(Name = "Forma de Newton")]
        Newton = 2,

        [Display(Name = "Spline Linear")]
        Spline = 3,

        [Display(Name = "Interpolação Trigonométrica")]
        Trigonometrica = 4

    }
}