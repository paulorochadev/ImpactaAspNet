using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//---
using AspNetVS2017.Capitulo03.Portifolio.Models;
using System.Data.SqlClient;
using System.Configuration;

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

            var stringConexao = ConfigurationManager.ConnectionStrings["portfolioSqlServer"].ConnectionString;

            using (var conexao = new SqlConnection(stringConexao))
            {
                conexao.Open();

                const string instrucao = @"
                            INSERT INTO [dbo].[Contato]
                                       ([Nome]
                                       ,[Email]
                                       ,[Mensagem])
                                 VALUES
                                       (@Nome
                                       ,@Email
                                       ,@Mensagem)
                            ";

                using (var comando = new SqlCommand(instrucao, conexao))
                {
                    comando.Parameters.AddWithValue("@Nome", viewModel.Nome);
                    comando.Parameters.AddWithValue("@Email", viewModel.Email);
                    comando.Parameters.AddWithValue("@Mensagem", viewModel.Mensagem);
                    
                    comando.ExecuteNonQuery();
                }
                
                //conexao.Close(); -- Não precisa usar o CLOSE quando utiliza o USING
            }

            ModelState.Clear();

            return View();
        }
    }
}