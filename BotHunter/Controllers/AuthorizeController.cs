using BotHunter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace BotHunter.Controllers
{
    public class AuthorizeController : Controller
    {
        DataRepository _DataRepository;
        public AuthorizeController(DataRepository dataRepository)
        {
            _DataRepository = dataRepository;
        }
        // TODO: сделать авторизацию
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserCredentials credentials)
        {
            Guid? bigNumber = TempData["BigNumber"] as Guid?;
            if (bigNumber != null && credentials.Login != null)
            {
                User user = _DataRepository.SysUsers.First(u => u.Login == credentials.Login);
                if (user != null)
                {
                    var sha = new SHA1CryptoServiceProvider();
                    var hash = sha.ComputeHash(Encoding.UTF8.GetBytes(user.Password + bigNumber));
                    var hashString = BitConverter.ToString(hash).Replace("-", "");
                    if (credentials.HashValue.Equals(hashString, StringComparison.OrdinalIgnoreCase))
                    {
                        FormsAuthentication.SetAuthCookie(credentials.Login, true);
                        HttpContext.Session["UserName"] = user.Name;

                        return RedirectToAction("Index", "Home");
                    }
                }
            }
            
                return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Logoff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }
    }
}