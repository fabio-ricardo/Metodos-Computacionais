﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using WebApplication1.Models;
using WebApplication1.Funcao;
using System.Diagnostics;
using PolyLib;

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

        public double ZerarFuncao(FormulaInputZeroFuncaoModel input)
        {
            //Faz reflection para executar a fórmula que o usuário escolheu
            Funcao = FuncaoHelper.Clean(input.Funcao);
            Type classe = Type.GetType("WebApplication1.Metodos.MetodosHub");
            MethodInfo metodoCalculo = classe.GetMethod(input.Metodo.ToString());
            return (double)metodoCalculo.Invoke(this, new object[] { input });
        }

        public string InterpolarPontos(InterpolacaoModel input)
        {
            //Faz reflection para executar a fórmula que o usuário escolheu
            Type classe = Type.GetType("WebApplication1.Metodos.MetodosHub");
            MethodInfo metodoCalculo = classe.GetMethod(input.Metodo.ToString());
            return (string)metodoCalculo.Invoke(this, new object[] { input });
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
                    resultAtual += F(input.A + i * h);
                }
                resultAtual = (h / 2) * (input.A + 2 * resultAtual + input.B);
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
                resultAtual = (h / 3) * (input.A + resultAtual + input.B);
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
                resultAtual = (3 * h / 8) * (input.A + resultAtual + input.B);
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
                resultAtual = (2 * h / 45) * (7 * input.A + resultAtual + 7 * input.B);
            } while ((resultAtual - resultAnterior) > input.Erro);

            return resultAtual;
        }

        public double Bisseccao(FormulaInputZeroFuncaoModel input)
        {
            double x, fa, fb, a, b;
            a = input.A;
            b = (double)input.B;
            do
            {
                fa = F(a);
                fb = F(b);
                if (fa == 0) return a;
                if (fb == 0) return b;
                x = (a + b) / 2;
                a = ((x > 0 && a > 0) || (x < 0 && a < 0)) ? x : a;
                b = ((x > 0 && b > 0) || (b < 0 && b < 0)) ? x : b;
            } while (Math.Abs(F(x)) > input.Erro);
            return x;
        }

        public double Posicao_Falsa(FormulaInputZeroFuncaoModel input)
        {
            double x, fa, fb, a, b;
            a = input.A;
            b = (double)input.B;
            do
            {
                fa = F(a);
                fb = F(b);
                if (fa == 0) return a;
                if (fb == 0) return b;
                x = (a * fb - b * fa) / ((fb - fa) > 0 ? (fb - fa) : 1);
                a = ((x > 0 && a > 0) || (x < 0 && a < 0)) ? x : a;
                b = ((x > 0 && b > 0) || (b < 0 && b < 0)) ? x : b;
            } while (Math.Abs(F(x)) > input.Erro);
            return x;
        }


        public double Newton_Ralphson(FormulaInputZeroFuncaoModel input)
        {
            string derivada = FuncaoHelper.Clean(input.Derivada);
            double x, f, x0, flinha;
            x0 = input.A;
            int LIMITE = 10000;
            do
            {
                f = F(x0);
                flinha = F_linha(x0, derivada);
                if (f == 0) return x0;
                x = x0 - (f / (flinha > 0 ? flinha : 1));
                x0 = x;
                LIMITE--;
            } while (Math.Abs(F(x)) > input.Erro && LIMITE > 0);
            return x;
        }


        public double Secante(FormulaInputZeroFuncaoModel input)
        {
            double x, fx0, fx1, x0, x1;
            x0 = input.A;
            x1 = (double)input.B;
            int LIMITE = 10000;
            do
            {
                fx0 = F(x0);
                fx1 = F(x1);
                if (fx0 == 0) return x0;
                if (fx1 == 0) return x1;
                x = (x0 * fx1 - x1 * fx0) / ((fx1 - fx0) > 0 ? (fx1 - fx0) : 1);
                x0 = x1;
                x1 = x;
                LIMITE--;
            } while (Math.Abs(F(x)) > input.Erro && LIMITE > 0);
            return x;
        }



        public string Lagrange(InterpolacaoModel input)
        {
            var n = input.Pontos.Length / 2;
            var funcao = "P"+n.ToString()+"(x)= ";
            string[] L = new string[n];
            for (int i = 0; i < input.Pontos.Length; i+=2)
            {
                var den = 1.0;
                var num = new Polynomial(1.0);
                for (int j = 0; j < input.Pontos.Length; j+=2)
                {
                    if (i != j)
                    {
                        num *= new Polynomial(0, 1.0) - new Polynomial(double.Parse(input.Pontos[j]));
                        den *= (float.Parse(input.Pontos[i]) - float.Parse(input.Pontos[j]));
                    }
                }
                L[i/2] = "L"+(i/2).ToString()+"(x) = (" + num.ToString() + ")/(" + den.ToString() +")";
                funcao += input.Pontos[i+1]+"*L"+ (i / 2).ToString() + "(x) + ";
            }
            funcao = funcao.Remove(funcao.Length - 2);
      
            foreach (var item in L)
            {
                funcao += item + "\n";
            }
            return funcao;

        }

        public string Spline(InterpolacaoModel input)
        {
            var result = "";
            for (int i = 2; i < input.Pontos.Length; i += 2)
            {
                var num = (new Polynomial(double.Parse(input.Pontos[i - 1])) *
                    (new Polynomial(double.Parse(input.Pontos[i])) - new Polynomial(0, 1.0))
                    + new Polynomial(double.Parse(input.Pontos[i + 1])) * 
                    (new Polynomial(0, 1.0) - new Polynomial(double.Parse(input.Pontos[i - 2])))).ToString();

                var den = (double.Parse(input.Pontos[i]) - double.Parse(input.Pontos[i - 2]))
                    .ToString();

                result += "S" + (i / 2).ToString() + "(x) = ("+ num +")/("+ den + ")\n";
            }
            return result;
        }

      
        public string Newton(InterpolacaoModel input)
        {
            var n = input.Pontos.Length / 2;
            var f_start = "P"+n.ToString()+"(x) = ";
           
            var vet = new List<int>();
            var mult = new Polynomial(1.0);
            vet.Add(0);
            var funcao = new Polynomial(DiferencaDividida(vet, input.Pontos));
            for (int i = 0; i < input.Pontos.Length-2; i+=2)
            {
                vet.Add(i + 2);
                mult *= (new Polynomial(0, 1.0) - new Polynomial(double.Parse(input.Pontos[i])));
                funcao += new Polynomial((float)Math.Round(DiferencaDividida(vet, input.Pontos) * 100f) / 100f) * mult;
            }

            return funcao.ToString();
        }

        public double DiferencaDividida(IEnumerable<int> v, string[] pontos)
        {
            if (v.Count() <= 1)
            {
                return double.Parse(pontos[v.ElementAt(0)+1]);
            }

            return (DiferencaDividida((v.Count() == 2 ? new List<int> { v.ElementAt(1) } : v.Skip(1).Take(v.Count() -1)), pontos) 
                  - DiferencaDividida((v.Count() == 2 ? new List<int> { v.ElementAt(0) } : v.Take(v.Count() - 1)), pontos))
                / (double.Parse(pontos[v.Last()]) - double.Parse(pontos[v.First()]));

        }

        public string Trigonometrica(InterpolacaoModel input)
        {
            var n = input.Pontos.Length / 2;
            float[] xk = new float[n];
            var result = "";
            var m = Math.Floor((decimal)n/2);
            for (int i = 0; i < n; i++)
            {
                xk[i] = (float) (i * 2.0 * Math.PI) / n;

            }

            string[] As = new string[(int)m+1];
            string[] Bs = new string[(int)m+1];
            for (int i = 0; i <= m; i++)
            {
                var sumA = 0.0;
                var sumB = 0.0;
                for (int j = 0; j < n; j++)
                {
                    sumA += float.Parse(input.Pontos[2 * j + 1]) * Math.Cos(i * xk[j]);
                    sumB += float.Parse(input.Pontos[2 * j + 1]) * Math.Sin(i * xk[j]);
                }
                sumA = 2.0/n * sumA;
                sumB = 2.0/n * sumB;

                As[i] = ((float)Math.Round(sumA * 100f) / 100f).ToString();
                Bs[i] = ((float)Math.Round(sumB * 100f) / 100f).ToString();
            }

            var imax = m % 2 == 0 ? m - 1 : m;
            for (int i = 1; i <= imax; i++)
            {
                result += " (" + As[i] + "*Cos(" + i.ToString() + "*x) + " + Bs[i] + "*Sen(" + i.ToString() + "*x)) +";
            }
            result = (double.Parse(As[0]) / 2).ToString() + " + [" + result.Remove(result.Length-1)+"]";
            if (m % 2 == 0)
            {
                result = result + " + "+(double.Parse(As[(int)m]) / 2).ToString() + "*Cos("+ m.ToString() +"*x)";
            }
            return "f(x) = "+result;
        }

        public double F(double x)
        {
            var r = FuncaoHelper.Calculate(Funcao, x);
            return r == null ? throw new Exception() : (double)r;
        }

        public double F_linha(double x, string derivada)
        {
            var r = FuncaoHelper.Calculate(derivada, x);
            return r == null ? throw new Exception() : (double)r;
        }
    }
}

