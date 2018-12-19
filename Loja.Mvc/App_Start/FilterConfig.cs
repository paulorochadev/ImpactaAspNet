using System.Web;
using System.Web.Mvc;
//---
using Loja.Mvc.Filtros;


namespace Loja.Mvc
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            //filters.Add(new HandleErrorAttribute());

            filters.Add(new LogErrorFilter());

        }
    }
}
