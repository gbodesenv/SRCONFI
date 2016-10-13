using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SRCONFI.Projeto.Web.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(ViewModel.LoginViewModel loginViewModel)
        {            
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                if (string.IsNullOrEmpty(loginViewModel.Usuario))
                    ViewBag.UsuarioVazio = true;
                if (string.IsNullOrEmpty(loginViewModel.Senha))
                    ViewBag.SenhaVazio = true;
            }

            //if true
            return View("Index");
        }

    }
}