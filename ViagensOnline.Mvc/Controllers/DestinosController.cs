using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ViagensOnline.Dominio;
using ViagensOnline.Repositorios.SqlServer;
//---
using ViagensOnline.Mvc.Models;
using System.IO;

namespace ViagensOnline.Mvc.Controllers
{
    public class DestinosController : Controller
    {
        private ViagensOnlineDbContext db = new ViagensOnlineDbContext();

        //ToDo: Inserir no WEB CONFIG
        private readonly string caminhoImagensDestinos = "/Content/Imagens/Destinos";


        // GET: Destinos
        public ActionResult Index()
        {
            return View(Mapear(db.Destinos.ToList()));
        }

        private List<DestinoViewModel> Mapear(List<Destino> destinos)
        {
            var viewModels = new List<DestinoViewModel>();

            foreach (var destino in destinos)
            {
                viewModels.Add(Mapear(destino));
            }

            return viewModels;
        }

        private DestinoViewModel Mapear(Destino destino)
        {
            var viewModel = new DestinoViewModel();

            viewModel.CaminhoImagem = Path.Combine(caminhoImagensDestinos, destino.NomeImagem);
            viewModel.Id = destino.Id;
            viewModel.Nome = destino.Nome;
            viewModel.Pais = destino.Pais;
            viewModel.Cidade = destino.Cidade;
            
            return viewModel;
        }

        // GET: Destinos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Destino destino = db.Destinos.Find(id);
            if (destino == null)
            {
                return HttpNotFound();
            }
            return View(destino);
        }

        // GET: Destinos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Destinos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,Pais,Cidade,NomeImagem")] Destino destino)
        {
            if (ModelState.IsValid)
            {
                db.Destinos.Add(destino);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(destino);
        }

        // GET: Destinos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Destino destino = db.Destinos.Find(id);
            if (destino == null)
            {
                return HttpNotFound();
            }
            return View(destino);
        }

        // POST: Destinos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Pais,Cidade,NomeImagem")] Destino destino)
        {
            if (ModelState.IsValid)
            {
                db.Entry(destino).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(destino);
        }

        // GET: Destinos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Destino destino = db.Destinos.Find(id);
            if (destino == null)
            {
                return HttpNotFound();
            }
            return View(destino);
        }

        // POST: Destinos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Destino destino = db.Destinos.Find(id);
            db.Destinos.Remove(destino);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
