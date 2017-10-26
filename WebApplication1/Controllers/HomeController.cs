﻿using System;
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
            var result = new ResultadoModel()
            {
                FormulaInput = model
            };
            result.Resultado = new MetodosHub().EfetuarCalculo(model);
            TempData["re"] = result;
            return RedirectToAction("Resultado");
        }

        public ActionResult Resultado()
        {
            return View( (ResultadoModel) TempData["re"]);
        }

    }
}