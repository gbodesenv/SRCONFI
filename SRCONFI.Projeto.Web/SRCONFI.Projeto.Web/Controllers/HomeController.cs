using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

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
            try
            {
                ViewBag.UsuarioInativo = false;

                if (ModelState.IsValid)
                {
                    Domain.Entity.Usuario usuario = new Domain.Entity.Usuario();
                    usuario.login = loginViewModel.Usuario;
                    usuario.senha = loginViewModel.Senha;
                    bool passTrue = new Business.LoginBusiness().AutenticarUsuario(usuario);

                    if (passTrue)
                        return RedirectToAction("Home", "Home");
                    else
                    {
                        ViewBag.UsuarioInvalido = true;
                        return View("Index");
                    }
                }
                else
                {
                    if (string.IsNullOrEmpty(loginViewModel.Usuario))
                        ViewBag.UsuarioVazio = true;
                    if (string.IsNullOrEmpty(loginViewModel.Senha))
                        ViewBag.SenhaVazio = true;
                }


                return View("Index");
            }
            catch (System.Exception e)
            {
                var retorno = new
                {
                    mensagem = e.Message.ToString(),//"Ocorreu algum erro ao inserir Usuário!",
                    erro = true
                };

                if (e.Message.ToString().Contains("Inativo"))
                    ViewBag.UsuarioInativo = true;

                return View("Index");
            }

        }

        public ActionResult Home()
        {
            ViewBag.Socios = new Business.SociosBusiness().ListSocios().Count();
            ViewBag.EntradaLivros = new Business.EntradasLivrosBusiness().ListEntradasLivros().Count();
            ViewBag.VendaLivros = new Business.VendaLivrosBusiness().ListVendaLivros().Count();
            return View();
        }

    }
}