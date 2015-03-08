namespace SimpleIdentity.Web.Controllers
{
    using SimpleIdentity.Services.Contracts;
    using SimpleIdentity.Services.Exceptions;
    using SimpleIdentity.Web.ViewModels;
    using System.Web.Mvc;
    using System.Linq;
    public class AccountController : BaseController
    {
        private IAccountService accountService;

        public AccountController(IAccountService accountService)
        {
            this.accountService = accountService;
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserViewModel user)
        {
            if (!this.ModelState.IsValid)
            {
                return this.StringifyModelStateErrors(this.ModelState);
            }

            try
            {
                this.accountService.LoginUser(user.UserName, user.Password);
            }
            catch (GeneralAccountException ex)
            {
                return new HttpStatusCodeResult(302, ex.Message);
            }

            return this.RedirectToUrl("WelcomeScreen", new { UserName = user.UserName});
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignUp(UserViewModel user)
        {
            if (!this.ModelState.IsValid)
            {
                return this.StringifyModelStateErrors(this.ModelState);
            }

            try
            {
                this.accountService.AddUser(user.UserName, user.Password);
            }
            catch (GeneralAccountException ex)
            {
                return new HttpStatusCodeResult(302, ex.Message);
            }

            return this.RedirectToUrl("Login");
        }

        public ActionResult WelcomeScreen(LoginViewModel user)
        {
            return View(user);
        }

        private ActionResult RedirectToUrl(string action)
        {
            return Json(new { URL = Url.Action(action) });
        }

        private ActionResult RedirectToUrl(string action, object urlParams)
        {
            return Json(new { URL = Url.Action(action, urlParams) });
        }
    }
}