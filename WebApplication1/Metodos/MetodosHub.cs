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
            return (double)metodoCalculo.Invoke(this, new object[] { input });
        }

        public double Trapezio(FormulaInputModel input)
        {
            //n=1
            var h = (input.B - input.A);
            var result = h / 2 * (f(input.A) + f(input.B));
            return result;
        }

        public double Simpson(FormulaInputModel input)
        {
            //n=2
            var h = (input.B - input.A )/ 2;
            var x1 = input.A + h;
            var result = h/3 * (f(input.A) + 4*f(x1) + f(input.B));
            return result;
        }

        public double Simpson_3_8(FormulaInputModel input)
        {
            //n=3   
            var h = (input.B - input.A) / 3;
            var x1 = input.A + h;
            var x2 = input.A + 2*h;
            var result = 3*h/8 * (f(input.A) + 3*f(x1) + 3*f(x2) + f(input.B));
            return result;
        }

        public double Newton_Cotes(FormulaInputModel input)
        {
            //n=4 
            var h = (input.B - input.A) / 4;
            var x1 = input.A + h;
            var x2 = input.A + 2 * h;
            var x3 = input.A + 3 * h;
            var result = 2*h/45 * (7*f(input.A) + 32*f(x1) + 12*f(x2) + 32*f(x3) + 7*f(input.B));
            return result;
        }

        public double f(float x)
        {
            return Math.Cos(x);
        }
    }
}