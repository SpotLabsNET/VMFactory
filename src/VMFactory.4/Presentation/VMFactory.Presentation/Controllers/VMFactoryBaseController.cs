using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Web.Mvc;
using VMFactory.Presentation.Models;


namespace VMFactory.Presentation.Controllers
{
    public class VMFactoryBaseController : Controller
    {

        protected VMFactoryBaseController() { IsRegistered(); }

        protected string GetCurrentUserNameIdentifier()
        {

#if DEBUG
            if (!System.Diagnostics.Debugger.IsAttached) System.Diagnostics.Debugger.Break();
#endif

            ClaimsIdentity ci = Thread.CurrentPrincipal.Identity as ClaimsIdentity;
            string currentUserNameIdentifier = "";

            if (ci != null) { Claim claimUserNameIdentifier = ci.Claims.FirstOrDefault(s => 0 == string.Compare(s.Type, @"http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier")); if (null != claimUserNameIdentifier) currentUserNameIdentifier = claimUserNameIdentifier.Value; };

            return currentUserNameIdentifier;
        }

        //public static bool IsRegistered()
        public bool IsRegistered() { string userNameIdentifier = GetCurrentUserNameIdentifier();  if (!string.IsNullOrEmpty(userNameIdentifier)) { using (var db = new UsersContext()) { var userProfiles = from i in db.UserProfiles where i.NameIdentifier == userNameIdentifier select i;  if (userProfiles.Count() > 0) { ViewBag.Name = userProfiles.First().UserName; ViewBag.EMail = userProfiles.First().EMail; return true; } } } return false; } 


    }
}
