using System;
using System.IdentityModel.Services;
using System.Text;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using VMFactory.Api.Core.Configuration;

namespace VMFactory.Presentation
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start() { AreaRegistration.RegisterAllAreas();  WebApiConfig.Register(GlobalConfiguration.Configuration); FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters); RouteConfig.RegisterRoutes(RouteTable.Routes); BundleConfig.RegisterBundles(BundleTable.Bundles); AuthConfig.RegisterAuth();  } 
            /// <summary>
        /// Retrieves the address that was used in the browser for accessing 
        /// the web application, and injects it as WREPLY parameter in the
        /// request to the STS
        /// Reference: http://msdn.microsoft.com/en-us/library/ee517293.aspx - WS-Federated Authentication Module Overview
        ///          : http://msdn.microsoft.com/en-us/library/microsoft.identitymodel.protocols.wsfederation.signinrequestmessage_members.aspx - SignInRequestMessage Members
        ///          : http://www.leastprivilege.com/GenevaIntegrationIntoASPNET.aspx - Geneva integration into ASP.NET
        ///          : http://www.leastprivilege.com/GenevaHTTPModulesClaimsPrincipalHttpModule.aspx - Geneva HTTP Modules: ClaimsPrincipalHttpModule
        /// </summary>      
        void WSFederationAuthenticationModule_RedirectingToIdentityProvider(object sender, RedirectingToIdentityProviderEventArgs e) { HttpRequest request = HttpContext.Current.Request; Uri requestUrl = request.Url; StringBuilder wreply = new StringBuilder();  wreply.Append(requestUrl.Scheme); wreply.Append("://");  String host = request.Headers["Host"]; host = host.Replace("127.0.0.1", "localhost"); host = host.Replace("127.0.0.2", "localhost"); wreply.Append(host); e.SignInRequestMessage.Realm = wreply.ToString().EndsWith("/") ? wreply.ToString() : wreply.ToString() + "/"; e.SignInRequestMessage.Reply = wreply.ToString().EndsWith("/") ? wreply.ToString() : wreply.ToString() + "/"; }



        void Application_BeginRequest(object sender, EventArgs e) { if (DefaultConfigurationStore.Current.MaintenanceMode != DefaultConfigurationStore.MaintenanceModes.Off) { switch (DefaultConfigurationStore.Current.MaintenanceMode) { case DefaultConfigurationStore.MaintenanceModes.On: HttpContext.Current.RewritePath("maintenance.aspx"); break; case DefaultConfigurationStore.MaintenanceModes.Auto: break;  }  } }         
    }
}