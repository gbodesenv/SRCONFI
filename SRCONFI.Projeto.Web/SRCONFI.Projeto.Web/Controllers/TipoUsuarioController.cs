using SRCONFI.Projeto.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SRCONFI.Projeto.Web.Controllers
{
    public class TipoUsuarioController : Controller
    {
        // GET: 

        #region Listar 

        // GET: TipoUsuario
        public ActionResult Listar()
        {
            return View(new Business.TipoUsuarioBusiness().ListTipoUsuario());
        }

        public PartialViewResult _TableListarTipoUsuario(int? id = null)
        {
            var listaDeTipoUsuarios = new List<TipoUsuario>();

            if (id.HasValue)
                listaDeTipoUsuarios.Add(new Business.TipoUsuarioBusiness().GetTipoUsuario((int)id));
            else
                listaDeTipoUsuarios = new Business.TipoUsuarioBusiness().ListTipoUsuario();

            return PartialView(listaDeTipoUsuarios);
        }

        #endregion Fim Listar 

        #region Inserir 

        public ActionResult Inserir()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult Inserir(TipoUsuario obj)
        {
            try
            {
                new Business.TipoUsuarioBusiness().AddTipoUsuario(obj);

                var retorno = new
                {
                    mensagem = "Tipo de Usuário Inserido com Sucesso!",
                    erro = false,
                    id = obj.tipoUsuarioID
                };

                return Json(retorno, JsonRequestBehavior.AllowGet);
            }
            catch (System.Exception e)
            {
                var retorno = new
                {
                    mensagem = e.Message.ToString(),//"Ocorreu algum erro ao inserir Usuário!",
                    erro = true
                };

                return Json(retorno, JsonRequestBehavior.AllowGet);
            }
        }

        #endregion Fim Inserir 

        #region Editar 

        [HttpGet]
        public ActionResult Editar(int id)
        {
            var tpUsuario = new Business.TipoUsuarioBusiness().GetTipoUsuario(id);

            return View(tpUsuario);
        }

        [HttpPost]
        public ActionResult Editar(TipoUsuario obj)
        {
            try
            {
                new Business.TipoUsuarioBusiness().EditTipoUsuario(obj);

                var retorno = new
                {
                    mensagem = "Tipo de Usuário Atualizado com Sucesso!",
                    erro = false,
                    id = obj.tipoUsuarioID
                };

                return Json(retorno, JsonRequestBehavior.AllowGet);
            }
            catch (System.Exception e)
            {
                var retorno = new
                {
                    mensagem = e.Message.ToString(),//"Ocorreu algum erro ao editar Usuário!",
                    erro = true
                };

                return Json(retorno, JsonRequestBehavior.AllowGet);
            }
        }

        #endregion Fim Editar 

        #region Excluir 

        [HttpPost]
        public ActionResult Excluir(int id)
        {
            try
            {
                new Business.TipoUsuarioBusiness().DeleteTipoUsuario(id);

                var retorno = new
                {
                    mensagem = "Tipo de Usuário Excluido com Sucesso!",
                    erro = false
                };

                return Json(retorno, JsonRequestBehavior.AllowGet);
            }
            catch (System.Exception e)
            {
                var retorno = new
                {
                    mensagem = e.Message.ToString(),//"Ocorreu algum erro ao editar Usuário!",
                    erro = true
                };

                return Json(retorno, JsonRequestBehavior.AllowGet);
            }
        }


        #endregion Fim Excluir 

        #region Imprimir 
        #endregion Fim Imprimir 

        #region Métodos Auxiliares 


        #endregion Fim Métodos Auxiliares 

        #region Modais

        public ActionResult ModalInserir()
        {
            ViewModel.ModalViewModel modal = new ViewModel.ModalViewModel();
            modal.IdModal = "TipoUsuario";
            modal.TipoBotao = (int)Enum.ModalEnum.TipoBotaoEnum.Incluir;
            modal.TituloModal = "Inserir Tipo de Usuário";
            modal.CaminhoBodyModal = Url.Action("Inserir", "TipoUsuario");

            return PartialView("~/Views/Modal/Modal.cshtml", modal);
        }

        public ActionResult ModalEditar()
        {
            ViewModel.ModalViewModel modal = new ViewModel.ModalViewModel();
            modal.IdModal = "TipoUsuario";
            modal.TipoBotao = (int)Enum.ModalEnum.TipoBotaoEnum.Editar;
            modal.TituloModal = "Editar Tipo de Usuário";
            modal.CaminhoBodyModal = Url.Action("Editar", "TipoUsuario");

            return PartialView("~/Views/Modal/Modal.cshtml", modal);
        }

        #endregion Fim Modais 


    }
}