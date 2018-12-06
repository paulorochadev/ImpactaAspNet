using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//---
using System.IO;
using AspNetVS2017.Capitulo03.Portifolio.Models;

namespace AspNetVS2017.Capitulo03.Portifolio.Controllers
{
    public class PortfolioController : Controller
    {
        // GET: Portfolio
        public ActionResult Index()
        {
            const string diretorioImagens = "/Content/Imagens/Portfolio";

            var caminhos = Directory.EnumerateFiles(Server.MapPath(diretorioImagens));

            var viewModel = new PortfolioViewModel();

            foreach (var caminho in caminhos)
            {
                viewModel.CaminhoImagens.Add($"{diretorioImagens}/{Path.GetFileName(caminho)}");
            }

            return View(viewModel);
        }
    }
}