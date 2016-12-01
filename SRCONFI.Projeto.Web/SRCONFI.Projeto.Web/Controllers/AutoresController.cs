using SRCONFI.Projeto.Domain.Entity;
using System.Collections.Generic;
using System.Web.Mvc;

namespace SRCONFI.Projeto.Web.Controllers
{
    public class AutoresController : Controller
    {

        #region Listar 

        // GET: Autores
        public ActionResult Listar()
        {
            return View(new Business.AutoresBusiness().ListAutores());
        }

        public PartialViewResult _TableListarAutores(int? id = null)
        {
            var listaDeAutoress = new List<Autores>();

            if (id.HasValue)
                listaDeAutoress.Add(new Business.AutoresBusiness().GetAutores((int)id));
            else
                listaDeAutoress = new Business.AutoresBusiness().ListAutores();

            return PartialView(listaDeAutoress);
        }

        #endregion Fim Listar 

        #region Inserir 

        [HttpGet]
        public ActionResult Inserir()
        {

            return PartialView();
        }

        [HttpPost]
        public ActionResult Inserir(Autores autor)
        {
            try
            {

                //if (ModelState.IsValid)
                //{
                new Business.AutoresBusiness().AddAutores(autor);

                //}
                var retorno = new
                {
                    mensagem = "Autores Inserido com Sucesso!",
                    erro = false,
                    id = autor.autorID
                };

                return Json(retorno, JsonRequestBehavior.AllowGet);
            }
            catch (System.Exception e)
            {
                var retorno = new
                {
                    mensagem = e.Message.ToString(),//"Ocorreu algum erro ao inserir Autores!",
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
            var autor = new Business.AutoresBusiness().GetAutores(id);

            return View(autor);
        }

        [HttpPost]
        public ActionResult Editar(Autores autor)
        {
            try
            {
                new Business.AutoresBusiness().EditAutores(autor);

                var retorno = new
                {
                    mensagem = "Autores Atualizado com Sucesso!",
                    erro = false,
                    id = autor.autorID
                };

                return Json(retorno, JsonRequestBehavior.AllowGet);
            }
            catch (System.Exception e)
            {
                var retorno = new
                {
                    mensagem = e.Message.ToString(),//"Ocorreu algum erro ao editar Autores!",
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
                new Business.AutoresBusiness().DeleteAutores(id);

                var retorno = new
                {
                    mensagem = "Autores Excluido com Sucesso!",
                    erro = false
                };

                return Json(retorno, JsonRequestBehavior.AllowGet);
            }
            catch (System.Exception e)
            {
                var retorno = new
                {
                    mensagem = e.Message.ToString(),//"Ocorreu algum erro ao editar Autores!",
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
            modal.IdModal = "Autores";
            modal.TipoBotao = (int)Enum.ModalEnum.TipoBotaoEnum.Incluir;
            modal.TituloModal = "Inserir Autor";
            modal.CaminhoBodyModal = Url.Action("Inserir", "Autores");

            return PartialView("~/Views/Modal/Modal.cshtml", modal);
        }

        public ActionResult ModalEditar()
        {
            ViewModel.ModalViewModel modal = new ViewModel.ModalViewModel();
            modal.IdModal = "Autores";
            modal.TipoBotao = (int)Enum.ModalEnum.TipoBotaoEnum.Editar;
            modal.TituloModal = "Editar Autores";
            modal.CaminhoBodyModal = Url.Action("Editar", "Autores");

            return PartialView("~/Views/Modal/Modal.cshtml", modal);
        }

        #endregion Fim Modais 

    }
}