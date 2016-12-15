using SRCONFI.Projeto.Domain.Entity;
using System.Collections.Generic;
using System.Web.Mvc;

namespace SRCONFI.Projeto.Web.Controllers
{
    public class DoacoesController : Controller
    {

        #region Listar 

        // GET: Doacoes
        public ActionResult Listar()
        {
            return View(new Business.DoacoesBusiness().ListDoacoes());
        }

        public PartialViewResult _TableListarDoacoes(int? id = null)
        {
            var listaDeDoacoess = new List<Doacoes>();

            if (id.HasValue)
                listaDeDoacoess.Add(new Business.DoacoesBusiness().GetDoacoes((int)id));
            else
                listaDeDoacoess = new Business.DoacoesBusiness().ListDoacoes();

            return PartialView(listaDeDoacoess);
        }

        #endregion Fim Listar 

        #region Inserir 

        [HttpGet]
        public ActionResult Inserir()
        {

            return PartialView();
        }

        [HttpPost]
        public ActionResult Inserir(Doacoes doacoes)
        {
            try
            {

                //if (ModelState.IsValid)
                //{
                new Business.DoacoesBusiness().AddDoacoes(doacoes);

                //}
                var retorno = new
                {
                    mensagem = "Doação Inserido com Sucesso!",
                    erro = false,
                    id = doacoes.doacaoID
                };

                return Json(retorno, JsonRequestBehavior.AllowGet);
            }
            catch (System.Exception e)
            {
                var retorno = new
                {
                    mensagem = e.Message.ToString(),//"Ocorreu algum erro ao inserir Doacoes!",
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
            var doacoes = new Business.DoacoesBusiness().GetDoacoes(id);

            return View(doacoes);
        }

        [HttpPost]
        public ActionResult Editar(Doacoes doacoes)
        {
            try
            {
                new Business.DoacoesBusiness().EditDoacoes(doacoes);

                var retorno = new
                {
                    mensagem = "Doação Atualizado com Sucesso!",
                    erro = false,
                    id = doacoes.doacaoID
                };

                return Json(retorno, JsonRequestBehavior.AllowGet);
            }
            catch (System.Exception e)
            {
                var retorno = new
                {
                    mensagem = e.Message.ToString(),//"Ocorreu algum erro ao editar Doacoes!",
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
                new Business.DoacoesBusiness().DeleteDoacoes(id);

                var retorno = new
                {
                    mensagem = "Doação Excluido com Sucesso!",
                    erro = false
                };

                return Json(retorno, JsonRequestBehavior.AllowGet);
            }
            catch (System.Exception e)
            {
                var retorno = new
                {
                    mensagem = e.Message.ToString(),//"Ocorreu algum erro ao editar Doacoes!",
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
            modal.IdModal = "Doacoes";
            modal.TipoBotao = (int)Enum.ModalEnum.TipoBotaoEnum.Incluir;
            modal.TituloModal = "Inserir Doação";
            modal.CaminhoBodyModal = Url.Action("Inserir", "Doacoes");

            return PartialView("~/Views/Modal/Modal.cshtml", modal);
        }

        public ActionResult ModalEditar()
        {
            ViewModel.ModalViewModel modal = new ViewModel.ModalViewModel();
            modal.IdModal = "Doacoes";
            modal.TipoBotao = (int)Enum.ModalEnum.TipoBotaoEnum.Editar;
            modal.TituloModal = "Editar Doacoes";
            modal.CaminhoBodyModal = Url.Action("Editar", "Doacoes");

            return PartialView("~/Views/Modal/Modal.cshtml", modal);
        }

        #endregion Fim Modais 

    }
}