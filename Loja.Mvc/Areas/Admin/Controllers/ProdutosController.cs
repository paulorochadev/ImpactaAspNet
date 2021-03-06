﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Loja.Dominio;
using Loja.Repositorios.SqlServer;
//---
using Loja.Mvc.Mapeamento;
using Loja.Mvc.Areas.Admin.Models;
using System.Security.Claims;


namespace Loja.Mvc.Areas.Admin.Controllers
{
    [Authorize]
    public class ProdutosController : Controller
    {
        private readonly LojaDbContext db = new LojaDbContext();

        private readonly ProdutoMapeamento map = new ProdutoMapeamento();

        // GET: Admin/Produtos
        [AllowAnonymous]
        public ActionResult Index()
        {
            //throw new Exception("Teste");

            //var produto = db.Produtos.Include(p => p.Imagem);

            return View(map.Mapear(db.Produtos.ToList()));
        }

        [AllowAnonymous]
        // GET: Admin/Produtos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = db.Produtos.Find(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(map.Mapear(produto));
        }

        // GET: Admin/Produtos/Create
        public ActionResult Create()
        {
            //ViewBag.Id = new SelectList(db.ProdutoImagem, "ProdutoId", "ContentType");
            return View(map.Mapear(new Produto(), db.Categorias.ToList()));
        }

        // POST: Admin/Produtos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProdutoViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var produto = map.Mapear(viewModel, db);

                db.Produtos.Add(produto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id = new SelectList(db.ProdutoImagem, "ProdutoId", "ContentType", viewModel.Id);
            return View(viewModel);
        }

        // GET: Admin/Produtos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (!((ClaimsIdentity)User.Identity).HasClaim(c => c.Type == "Produtos" && c.Value.Contains("|Edit|")))
            {
                return RedirectToAction("Logim", "Account", new { area = "" });
            }

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = db.Produtos.Find(id);

            if (produto == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id = new SelectList(db.ProdutoImagem, "ProdutoId", "ContentType", produto.Id);

            return View(map.Mapear(produto, db.Categorias.ToList()));
        }

        // POST: Admin/Produtos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Preco,Estoque,Ativo")] Produto produto)
        {
            if (!((ClaimsIdentity)User.Identity).HasClaim(c => c.Type == "Produtos" && c.Value.Contains("|Edit|")))
            {
                return RedirectToAction("Logim", "Account", new { area = ""});
            }

            if (ModelState.IsValid)
            {
                db.Entry(produto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id = new SelectList(db.ProdutoImagem, "ProdutoId", "ContentType", produto.Id);
            return View(map.Mapear(produto, db.Categorias.ToList()));
        }

        // GET: Admin/Produtos/Delete/5
        [Authorize(Roles = "Master")]
        [Authorize(Roles = "Gerente, Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = db.Produtos.Find(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(map.Mapear(produto));
        }

        // POST: Admin/Produtos/Delete/5
        [Authorize(Roles = "Master")]
        [Authorize(Roles = "Gerente, Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Produto produto = db.Produtos.Find(id);
            db.Produtos.Remove(produto);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [ActionName("Categoria")]
        public ActionResult ObterProdutoPorCategoria(int categoriaId)
        {
            var produtos = db.Produtos
                .Where(p => p.Categoria.Id == categoriaId)
                .Select(p => new { p.Nome, p.Preco, p.Estoque})
                .ToList();

            return Json(produtos, JsonRequestBehavior.AllowGet);
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
