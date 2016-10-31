using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SRCONFI.Projeto.Web.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult Listar()
        {
            return View(new Business.UsuarioBusiness().ListUsuarios());
        }

        public ActionResult Inserir()
        {
            return PartialView();
        }

        public ActionResult Modal()
        {
            ViewModel.ModalViewModel modal = new ViewModel.ModalViewModel();
            modal.IdModal = "Usuario";
            modal.TipoBotao = (int)Enum.ModalEnum.TipoBotaoEnum.Incluir;
            modal.TituloModal = "Inserir Usuário";
            modal.CaminhoBodyModal = Url.Action("Inserir", "Usuario");

            return PartialView("~/Views/Modal/Modal.cshtml", modal);
        }

    }
}