using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//---
using Loja.Mvc.Models;
using System.Globalization;


namespace Loja.Mvc.Helpers
{
    public class CultureHelper
    {
        private const string LinguagemPadrao = "pt-BR";
        private string linguagemSelecionada = LinguagemPadrao;
        private List<string> linguagensSuportadas = new List<string> { "pt-BR", "en-US", "es"};

        public CultureHelper()
        {
            DefinirLinguagemPadrao();
            ObterRegionInfo();
        }

        public string NomeNativo { get; set; }
        public string Abreviacao { get; set; }

        public static CultureInfo ObterCultureInfo()
        {
            var linguagemSelecionada = HttpContext.Current.Request.Cookies[Cookie.LinguagemSelecionada];

            var linguagem = linguagemSelecionada?.Value ?? LinguagemPadrao;

            return CultureInfo.CreateSpecificCulture(linguagem);
        }
        
        private void ObterRegionInfo()
        {
            var cultura = CultureInfo.CreateSpecificCulture(linguagemSelecionada);
            var regiao = new RegionInfo(cultura.LCID);

            NomeNativo = regiao.NativeName;
            Abreviacao = regiao.TwoLetterISORegionName.ToLower();
        }

        private void DefinirLinguagemPadrao()
        {
            var request = HttpContext.Current.Request;

            if (request.Cookies[Cookie.LinguagemSelecionada] != null)
            {
                linguagemSelecionada = request.Cookies[Cookie.LinguagemSelecionada].Value;

                return;
            }

            if (request.UserLanguages !=null && linguagensSuportadas.Contains(request.UserLanguages[0]))
            {
                linguagemSelecionada = request.UserLanguages[0];
            }

            var cookie = new HttpCookie(Cookie.LinguagemSelecionada, linguagemSelecionada);

            cookie.Expires = DateTime.MaxValue;

            HttpContext.Current.Response.Cookies.Add(cookie);
        }
    }
}