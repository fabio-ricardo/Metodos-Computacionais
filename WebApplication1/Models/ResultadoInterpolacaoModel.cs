using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class ResultadoInterpolacaoModel
    {
        public InterpolacaoModel InterpolacaoInput { get; set; }
        public string Resultado { get; set; }

    }
}