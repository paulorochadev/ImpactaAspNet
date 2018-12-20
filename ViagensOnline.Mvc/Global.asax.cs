﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
//---
using System.Web.Helpers;
using System.Security.Claims;

namespace ViagensOnline.Mvc
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // Utilização de COOKIE
            AntiForgeryConfig.UniqueClaimTypeIdentifier = ClaimTypes.NameIdentifier;


// Diretiva de Pré Processamento
#if DEBUG
            BundleTable.EnableOptimizations = false;

#else
            BundleTable.EnableOptimizations = true;

#endif
        }
    }
}
