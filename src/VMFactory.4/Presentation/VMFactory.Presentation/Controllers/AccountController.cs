using Microsoft.Web.WebPages.OAuth;
using System.Transactions;
using System.Web.Mvc;
using VMFactory.Presentation.Filters;
using WebMatrix.WebData;

namespace VMFactory.Presentation.Controllers
{
    [Authorize]
    [InitializeSimpleMembership]
    public class AccountController : VMFactoryBaseController
    {
        //
        // POST: /Account/Login

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login() { return View(); } 
        //
        // POST: /Account/LogOff

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff() { WebSecurity.Logout();  return RedirectToAction("Index", "Home"); }

        //
        // POST: /Account/Disassociate

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Disassociate(string provider, string providerUserId) { string ownerAccount = OAuthWebSecurity.GetUserName(provider, providerUserId); ManageMessageId? message = null;  if (ownerAccount == User.Identity.Name) { using (var scope = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = IsolationLevel.Serializable })) { bool hasLocalAccount = OAuthWebSecurity.HasLocalAccount(WebSecurity.GetUserId(User.Identity.Name)); if (hasLocalAccount || OAuthWebSecurity.GetAccountsFromUserName(User.Identity.Name).Count > 1) { OAuthWebSecurity.DeleteAccount(provider, providerUserId); scope.Complete(); message = ManageMessageId.RemoveLoginSuccess; } } } return RedirectToAction("Manage", new { Message = message }); } 
        //
        // GET: /Account/Manage

        public ActionResult Manage(ManageMessageId? message) { ViewBag.StatusMessage = message == ManageMessageId.ChangePasswordSuccess ? "Your password has been changed." : message == ManageMessageId.SetPasswordSuccess ? "Your password has been set." : message == ManageMessageId.RemoveLoginSuccess ? "The external login was removed." : ""; ViewBag.HasLocalPassword = OAuthWebSecurity.HasLocalAccount(WebSecurity.GetUserId(User.Identity.Name)); ViewBag.ReturnUrl = Url.Action("Manage"); return View(); }

        #region Helpers
        private ActionResult RedirectToLocal(string returnUrl) { if (Url.IsLocalUrl(returnUrl)) { return Redirect(returnUrl); } else { return RedirectToAction("Index", "Home"); } }

        public enum ManageMessageId { ChangePasswordSuccess, SetPasswordSuccess, RemoveLoginSuccess, }

        #endregion
    }
}
