

using NCalc;

namespace WebApplication1.Funcao
{
    public static class FuncaoHelper
    {
        public static double? Calculate(string funcao, double x)
        {
            try
            {
                //Workaround pra quando as funções matemáticas contêm 'x' no nome
                Expression e = new Expression(funcao
                    .Replace("x", x.ToString())
                    .Replace("X", "x"));
                return (double)e.Evaluate();
            }
            catch
            {
                return null;
            }
        }
        public static string Clean(string f)
        {
            f = f.Replace("abs", "Abs");
            f = f.Replace("acos", "Acos");
            f = f.Replace("asin", "Asin");
            f = f.Replace("atan", "Atan");
            f = f.Replace("cos", "Cos");
            f = f.Replace("cosh", "Cosh");
            f = f.Replace("exp", "EXp");
            f = f.Replace("log", "Log");
            f = f.Replace("log10", "Log10");
            f = f.Replace("max", "MaX");
            f = f.Replace("ceiling", "Ceiling");
            f = f.Replace("floor", "Floor");
            f = f.Replace("min", "Min");
            f = f.Replace("pow", "Pow");
            f = f.Replace("round", "Round");
            f = f.Replace("sin", "Sin");
            f = f.Replace("sinh", "Sinh");
            f = f.Replace("sqrt", "Sqrt");
            f = f.Replace("tan", "Tan");
            f = f.Replace("tanh", "Tanh");
            f = f.Replace("truncate", "Truncate");
            return f;
        }


    }
}