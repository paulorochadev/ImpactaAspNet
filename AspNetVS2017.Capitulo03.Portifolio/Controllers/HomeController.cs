using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//---
using AspNetVS2017.Capitulo03.Portifolio.Models;


namespace AspNetVS2017.Capitulo03.Portifolio.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Mensagem = "Entre em Contato";

            return View();
        }

        [HttpPost]
        public ActionResult Contact(ContatoViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            return View();
        }
    }
}