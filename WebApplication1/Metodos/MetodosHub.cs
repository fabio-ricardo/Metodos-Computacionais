using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using WebApplication1.Models;
using System.CodeDom.Compiler;
using Microsoft.CSharp;
using WebApplication1.Funcao;

namespace WebApplication1.Metodos
{
    public class MetodosHub
    {
        private string Funcao { get; set; }
        public double EfetuarCalculo(FormulaInputModel input)
        {
            //Faz reflection para executar a fórmula que o usuário escolheu
            Funcao = FuncaoHelper.Clean(input.Funcao);
            Type classe = Type.GetType("WebApplication1.Metodos.MetodosHub");
            MethodInfo metodoCalculo = classe.GetMethod(input.Metodo.ToString());
            return (double)metodoCalculo.Invoke(this, new object[] { input });
        }

        public double Trapezio(FormulaInputModel input)
        {
            var n = 0;
            float h = 0;
            double resultAnterior = 0;
            double resultAtual = 0;
            do
            {
                n++;
                h = (input.B - input.A) / n;
                resultAnterior = resultAtual;
                resultAtual = 0;
                for (int i = 1; i < n; i++)
                {
                    resultAtual +=  F(input.A + i * h);
                }
                resultAtual = (h/2) * (input.A + 2*resultAtual + input.B);
            } while ((resultAtual - resultAnterior) > input.Erro);

            return resultAtual;
        }

        public double Simpson(FormulaInputModel input)
        {
            var n = 1;
            float h = 0;
            double resultAnterior = 0;
            double resultAtual = 0;
            do
            {
                n++;
                h = (input.B - input.A) / n;
                resultAnterior = resultAtual;
                resultAtual = 0;
                for (int i = 1; i < n; i++)
                {
                    resultAtual += F(input.A + i * h) * (i % 2 == 0 ? 2 : 4);
                }
                resultAtual = (h/3) * (input.A + resultAtual + input.B);
            } while ((resultAtual - resultAnterior) > input.Erro);

            return resultAtual;
        }

        public double Simpson_3_8(FormulaInputModel input)
        {
            var n = 2;
            float h = 0;
            double resultAnterior = 0;
            double resultAtual = 0;
            do
            {
                n++;
                h = (input.B - input.A) / n;
                resultAnterior = resultAtual;
                resultAtual = 0;
                for (int i = 1; i < n; i++)
                {
                    resultAtual += F(input.A + i * h) * (i % 3 == 0 ? 2 : 3);
                }
                resultAtual = (3*h/8) * (input.A + resultAtual + input.B);
            } while ((resultAtual - resultAnterior) > input.Erro);

            return resultAtual;
        }

        public double Newton_Cotes(FormulaInputModel input)
        {
            //var result = 2 * h / 45 * (7 * f(input.A) + 32 * f(x1) + 12 * f(x2) + 32 * f(x3) + 7 * f(input.B));
            var n = 3;
            float h = 0;
            double resultAnterior = 0;
            double resultAtual = 0;
            do
            {
                n++;
                h = (input.B - input.A) / n;
                resultAnterior = resultAtual;
                resultAtual = 0;
                for (int i = 1; i < n; i++)
                {
                    resultAtual += F(input.A + i * h) * (i % 2 == 0 ? 32 : 12);
                }
                resultAtual = (2*h/45) * (7 * input.A + resultAtual + 7 * input.B);
            } while ((resultAtual - resultAnterior) > input.Erro);

            return resultAtual;
        }

        public double F(double x)
        {
            var r = FuncaoHelper.Calculate(Funcao, x);
            return r == null? throw new Exception(): (double) r;
        }
    }
}

