using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Metodos;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult CalculoIntegral()
        {
            return View();
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CalculoIntegral(FormulaInputModel model)
        {
            if (ModelState.IsValid && model.Metodo != 0)
            {
                var result = new ResultadoModel()
                {
                    FormulaInput = model
                };
                result.Resultado = new MetodosHub().EfetuarCalculo(model);
                //Workaround por conta de problema na passagem de model contendo model
                TempData["re"] = result;
                return RedirectToAction("Resultado");
            }
            return View("CalculoIntegral", model);
        }

        public ActionResult Resultado()
        {
            return View((ResultadoModel)TempData["re"]);
        }

        public ActionResult ResultadoZeroFuncao()
        {
            return View((ResultadoZeroFuncaoModel)TempData["re"]);
        }
        public ActionResult ZeroFuncao()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ZeroFuncao(FormulaInputZeroFuncaoModel model)
        {
            if (ModelState.IsValid && model.Metodo != 0
                && (model.Metodo != ZeroFuncaoEnum.Newton_Ralphson || 
                (model.B == null && !string.IsNullOrEmpty(model.Derivada))))
            {
                var result = new ResultadoZeroFuncaoModel()
                {
                    FormulaInput = model
                };
                result.Resultado = new MetodosHub().ZerarFuncao(model);
                //Workaround por conta de problema na passagem de model contendo model
                TempData["re"] = result;
                return RedirectToAction("ResultadoZeroFuncao");
            }
            return View("ZeroFuncao", model);
        }

        public ActionResult ResultadoInterpolacao()
        {
            return View((ResultadoInterpolacaoModel)TempData["re"]);
        }
        public ActionResult Interpolacao()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Interpolacao(InterpolacaoModel model)
        {
            if (ModelState.IsValid &&  model.Metodo != 0)
            {
                model.Pontos = model.PontosString.Replace(" ", "").Replace("(","").Replace(")","").Split(',');

                var result = new ResultadoInterpolacaoModel()
                {
                    InterpolacaoInput = model
                };
                result.Resultado = new MetodosHub().InterpolarPontos(model);
                //Workaround por conta de problema na passagem de model contendo model
                TempData["re"] = result;
                return RedirectToAction("ResultadoInterpolacao");
            }
            return View("Interpolacao", model);
        }

    }
}