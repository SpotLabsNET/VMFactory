using System;
using System.Configuration;
using System.IdentityModel.Services;
using System.IdentityModel.Services.Configuration;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using VMFactory.Api.Core.Configuration;
using VMFactory.Presentation.Models;

namespace VMFactory.Presentation.Controllers
{
    public class HomeController : VMFactoryBaseController
    {
        [AllowAnonymous]
        public ActionResult Index() { ViewBag.Message = "Build your own VM on request."; ViewBag.IsRegistered = IsRegistered(); return View(); }

        [AllowAnonymous]
        public ActionResult About() { ViewBag.Message = "";  return View(); }

        [AllowAnonymous]
        public ActionResult Contact() { ViewBag.Message = "ALM Rangers' Virtual Machine Factory.";  return View(); }

        [Authorize] //[AllowAnonymous]
        public ActionResult Login() { if (IsRegistered()) return View("~/Views/Home/About.cshtml"); else return RedirectToAction("Register"); }

        [AllowAnonymous]
        public ActionResult Register() { return View(); }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterModel model) { string userNameIdentifier = GetCurrentUserNameIdentifier();  if (ModelState.IsValid) { try { using (var db = new UsersContext()) { if (DefaultConfigurationStore.Current.ValidateInvitationCodes || string.Compare(model.InvitationCode, model.EMail, true) != 0) { var invitationCodes = from i in db.InvitationCodes where i.Code == model.InvitationCode && i.UsedBy == null select i;  if (invitationCodes.Count() == 0) throw new Exception("the code does not exist!");  invitationCodes.First().UsedBy = userNameIdentifier; }  db.UserProfiles.Add(new UserProfile { EMail = model.EMail, UserName = model.Name, NameIdentifier = userNameIdentifier }); db.SaveChanges(); } return RedirectToAction("Index", "Home"); } catch (MembershipCreateUserException e) { ModelState.AddModelError("", ErrorCodeToString(e.StatusCode)); }                 catch (Exception e) { ModelState.AddModelError("", e.Message); } }  return View(model); } 
        [Authorize] //[AllowAnonymous]
        public void Logout() { Uri requestUrl = HttpContext.Request.Url;  FederationConfiguration config = FederatedAuthentication.FederationConfiguration;  string wtrealm = config.WsFederationConfiguration.Realm; var wreply = new StringBuilder();  wreply.Append(requestUrl.Scheme); wreply.Append("://");  String host = requestUrl.Host; host = host.Replace("127.0.0.1", "localhost"); host = host.Replace("127.0.0.2", "localhost"); wreply.Append(host);  if(! wreply.ToString().EndsWith("/")) wreply.Append("/"); string wsFederationEndpoint = ConfigurationManager.AppSettings["ida:Issuer"];  SignOutRequestMessage signoutRequestMessage = new SignOutRequestMessage(new Uri(wsFederationEndpoint));  signoutRequestMessage.Parameters.Add("wreply", wreply.ToString()); signoutRequestMessage.Parameters.Add("wtrealm", wreply.ToString());  FederatedAuthentication.SessionAuthenticationModule.SignOut();  Response.Redirect(signoutRequestMessage.WriteQueryString()); } 
        [AcceptVerbsAttribute(HttpVerbs.Get | HttpVerbs.Post)]
        [ExcludeFilter(typeof(AuthorizeAttribute))]
        [Authorize]
        public string Diagnostico() { ClaimsIdentity ci = Thread.CurrentPrincipal.Identity as ClaimsIdentity; string r = ""; if (ci != null) { r += "|AuthenticationType|" + ci.AuthenticationType + "<br/>"; var claimIdUsuario = ci.Claims.FirstOrDefault(s => 0 == string.Compare(s.Type, @"http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name/IdUsuario"));  if (ci.Claims.Count() > 0) { Claim claimTipoContribuyente = ci.Claims.FirstOrDefault<Claim>(s => 0 == String.Compare(s.Type, @"http://schemas.xmlsoap.org/ws/2005/05/identity/claims/tipocontribuyente/TipoContribuyente")); if (null != claimTipoContribuyente && !String.IsNullOrWhiteSpace(claimTipoContribuyente.Value)) r += "|TipoContribuyente|" + claimTipoContribuyente.Value + "<br/>";  Claim claimRole = ci.Claims.FirstOrDefault<Claim>(s => 0 == String.Compare(s.Type, @"urn:CFDI/2010/01/claims/RoleName")); if (null != claimRole && String.IsNullOrWhiteSpace(claimRole.Value)) r += "|RoleName|" + claimRole.Value + "<br/>";  foreach (Claim c in ci.Claims) r += "|Claim|" + c.Issuer + "|" + c.OriginalIssuer + "|" + c.Subject + ":" + c.Type + "-" + c.Value + "(" + c.ValueType + ")" + "<br/>"; } } return r; } 
        [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = true)]
        public class ExcludeFilterAttribute : ActionFilterAttribute
        {

            public ExcludeFilterAttribute(Type toExclude) { FilterToExclude = toExclude; }

            /// <summary>
            /// The type of filter that will be ignored.
            /// </summary>
            public Type FilterToExclude { get; private set; }
        }

        private static string ErrorCodeToString(MembershipCreateStatus createStatus)
        {
            // See http://go.microsoft.com/fwlink/?LinkID=177550 for
            // a full list of status codes.
            switch (createStatus) { case MembershipCreateStatus.DuplicateUserName: return "User name already exists. Please enter a different user name.";  case MembershipCreateStatus.DuplicateEmail: return "A user name for that e-mail address already exists. Please enter a different e-mail address.";  case MembershipCreateStatus.InvalidPassword: return "The password provided is invalid. Please enter a valid password value.";  case MembershipCreateStatus.InvalidEmail: return "The e-mail address provided is invalid. Please check the value and try again.";  case MembershipCreateStatus.InvalidAnswer: return "The password retrieval answer provided is invalid. Please check the value and try again.";  case MembershipCreateStatus.InvalidQuestion: return "The password retrieval question provided is invalid. Please check the value and try again.";  case MembershipCreateStatus.InvalidUserName: return "The user name provided is invalid. Please check the value and try again.";  case MembershipCreateStatus.ProviderError: return "The authentication provider returned an error. Please verify your entry and try again. If the problem persists, please contact your system administrator.";  case MembershipCreateStatus.UserRejected: return "The user creation request has been canceled. Please verify your entry and try again. If the problem persists, please contact your system administrator.";  default: return "An unknown error occurred. Please verify your entry and try again. If the problem persists, please contact your system administrator."; }
        }
    }
}
