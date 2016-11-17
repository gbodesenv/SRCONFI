using SRCONFI.Projeto.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SRCONFI.Projeto.Web.Controllers
{
    public class SociosController : Controller
    {

        #region Listar 

        // GET: Socios
        public ActionResult Listar()
        {
            return View(new Business.SociosBusiness().ListSocios());
        }

        public PartialViewResult _TableListarSocios(int? id = null)
        {
            var listaDeSocioss = new List<Socios>();

            if (id.HasValue)
                listaDeSocioss.Add(new Business.SociosBusiness().GetSocios((int)id));
            else
                listaDeSocioss = new Business.SociosBusiness().ListSocios();

            return PartialView(listaDeSocioss);
        }

        #endregion Fim Listar 

        #region Inserir 

        public ActionResult Inserir()
        {
            Combos();
            return PartialView();
        }

        [HttpPost]
        public ActionResult Inserir(Socios socios)
        {
            try
            {

                //if (ModelState.IsValid)
                //{
                new Business.SociosBusiness().AddSocios(socios);

                //}
                var retorno = new
                {
                    mensagem = "Socios Inserido com Sucesso!",
                    erro = false,
                    id = socios.socioID
                };

                return Json(retorno, JsonRequestBehavior.AllowGet);
            }
            catch (System.Exception e)
            {
                var retorno = new
                {
                    mensagem = e.Message.ToString(),//"Ocorreu algum erro ao inserir Socios!",
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
            var socios = new Business.SociosBusiness().GetSocios(id);

            //Combos(socios.inStatus, socios.tipoSociosID_FK);

            return View(socios);
        }

        [HttpPost]
        public ActionResult Editar(Socios socios)
        {
            try
            {
                new Business.SociosBusiness().EditSocios(socios);

                var retorno = new
                {
                    mensagem = "Socios Atualizado com Sucesso!",
                    erro = false,
                    id = socios.socioID
                };

                return Json(retorno, JsonRequestBehavior.AllowGet);
            }
            catch (System.Exception e)
            {
                var retorno = new
                {
                    mensagem = e.Message.ToString(),//"Ocorreu algum erro ao editar Socios!",
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
                new Business.SociosBusiness().DeleteSocios(id);

                var retorno = new
                {
                    mensagem = "Sócios Excluido com Sucesso!",
                    erro = false
                };

                return Json(retorno, JsonRequestBehavior.AllowGet);
            }
            catch (System.Exception e)
            {
                var retorno = new
                {
                    mensagem = e.Message.ToString(),//"Ocorreu algum erro ao editar Socios!",
                    erro = true
                };

                return Json(retorno, JsonRequestBehavior.AllowGet);
            }
        }


        #endregion Fim Excluir 

        #region Imprimir 
        #endregion Fim Imprimir 

        #region Métodos Auxiliares 

        public void Combos(int? idSituacao = null, int? idTipoSocios = null)
        {
            List<SelectListItem> lstSituacao = new List<SelectListItem>();

            lstSituacao.Add(new SelectListItem()
            {
                Text = "",
                Value = "",
                Selected = (idSituacao == null) ? true : false
            });


            lstSituacao.Add(new SelectListItem()
            {
                Text = "Ativo",
                Value = "1",
                Selected = (idSituacao == 1) ? true : false
            });

            lstSituacao.Add(new SelectListItem()
            {
                Text = "Inativo",
                Value = "0",
                Selected = (idSituacao == 0) ? true : false
            });


            ViewBag.listSituacao = lstSituacao;

            List<SelectListItem> selectListTipoSocios = new List<SelectListItem>();
            //var lstTipoSocios = new Business.TipoUsuarioBusiness().ListTipoSocios();

            //foreach (var item in lstTipoSocios)
            //{
            //    selectListTipoSocios.Add(new SelectListItem()
            //    {
            //        Text = item.descricaoTipoSocios,
            //        Value = item.tipoSociosID.ToString(),
            //        Selected = (idTipoSocios == item.tipoSociosID) ? true : false
            //    });
            //}

            ViewBag.listTipoSocios = selectListTipoSocios;
        }

        #endregion Fim Métodos Auxiliares 

        #region Modais

        public ActionResult ModalInserir()
        {
            ViewModel.ModalViewModel modal = new ViewModel.ModalViewModel();
            modal.IdModal = "Socios";
            modal.TipoBotao = (int)Enum.ModalEnum.TipoBotaoEnum.Incluir;
            modal.TituloModal = "Inserir Sócios";
            modal.CaminhoBodyModal = Url.Action("Inserir", "Socios");

            return PartialView("~/Views/Modal/Modal.cshtml", modal);
        }

        public ActionResult ModalEditar()
        {
            ViewModel.ModalViewModel modal = new ViewModel.ModalViewModel();
            modal.IdModal = "Socios";
            modal.TipoBotao = (int)Enum.ModalEnum.TipoBotaoEnum.Editar;
            modal.TituloModal = "Editar Sócios";
            modal.CaminhoBodyModal = Url.Action("Editar", "Socios");

            return PartialView("~/Views/Modal/Modal.cshtml", modal);
        }

        #endregion Fim Modais 
    }
}