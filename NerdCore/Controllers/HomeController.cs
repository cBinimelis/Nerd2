using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NerdCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace NerdCore.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Usuario objUser)
        {
            if (ModelState.IsValid)
            {
                using (NerdCoreContext db = new NerdCoreContext())
                {
                    var obj = db.Usuario.Where(a => a.Nick.Equals(objUser.Nick) && a.Password.Equals(objUser.Password)).FirstOrDefault();
                    if (obj != null)
                    {
                        string id = obj.IdUsuario.ToString();
                        HttpContext.Session.SetString("user_ID", id);
                        HttpContext.Session.SetString("username", obj.Nick);
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ViewBag.Message ="Ha habido un problema en el inicio de sesión";
                    }
                }
            }
            return View(objUser);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
