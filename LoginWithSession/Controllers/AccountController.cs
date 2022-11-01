using LoginWithSession.Services;
using Microsoft.AspNetCore.Mvc;

namespace LoginWithSession.Controllers
{
    [Route("account")]
    public class AccountController : Controller
    {
        private IAccountService account;

        public AccountController(IAccountService account)
        {
            this.account = account;
        }

        [Route("")]
        [Route("~/")]
        [Route("Index")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("login")]
        public IActionResult login(string username , string password)
        {
            var acc = account.login(username, password);
            if (acc != null)
            {
                HttpContext.Session.SetString("username", acc.UserName);
                return RedirectToAction("dashboard");
            }
            else
            {
                ViewBag.msg = "Invalid Login UserName Or Password is UnCorrect";
                return View("Index");
            }

           
        }
        [Route("dashboard")]
        public IActionResult dashboard()
        {
            if (HttpContext.Session.GetString("username") == null)
                RedirectToAction("Index");

            ViewBag.username = HttpContext.Session.GetString("username");
            return View("dashboard");
        }


        [Route("logout")]
        public IActionResult logout()
        {

            HttpContext.Session.Remove("username");
            return RedirectToAction("index");
        }
    }
}
