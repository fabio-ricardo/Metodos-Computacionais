using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.Metodos
{
    public class MetodosHub
    {
      public double EfetuarCalculo(FormulaInputModel input)
        {
            Type classe = Type.GetType("WebApplication1.Metodos.MetodosHub");
            MethodInfo metodoCalculo = classe.GetMethod(input.Metodo.ToString());
           return (double) metodoCalculo.Invoke(this, new object[] { input});
        }

        public double Trapezio(FormulaInputModel input)
        {
            return 0;
        }

        public double Simpson(FormulaInputModel input)
        {
            return 0;
        }

        public double Simpson_3_8(FormulaInputModel input)
        {
            return 0d;
        }

        public double Newton_Cotes(FormulaInputModel input)
        {
            return 0;
        }

    }
}