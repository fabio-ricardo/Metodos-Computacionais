using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public enum MetodoEnum
    {
        [Display(Name = "Regra do Trapézio Repetida")]
        Trapezio = 1,

        [Display(Name = "1/3 de Simpson Repetida")]
        Simpson = 2,

        [Display(Name = "3/8 de Simpson Repetida")]
        Simpson_3_8 = 3,

        [Display(Name = "Newton-Cotes para n = 4")]
        Newton_Cotes = 4

    }
}