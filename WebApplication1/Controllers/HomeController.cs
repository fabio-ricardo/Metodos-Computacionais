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
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(FormulaInputModel model)
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
            return View("Index", model);
        }

        public ActionResult Resultado()
        {
            return View((ResultadoModel) TempData["re"]);
        }

    }
}