using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class ResultadoModel
    {
        public FormulaInputModel FormulaInput { get; set; }
        public double Resultado { get; set; }

    }
}