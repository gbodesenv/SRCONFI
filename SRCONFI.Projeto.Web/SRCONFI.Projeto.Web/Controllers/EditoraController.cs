using SRCONFI.Projeto.Domain.Entity;
using System.Collections.Generic;
using System.Web.Mvc;

namespace SRCONFI.Projeto.Web.Controllers
{
    public class EditorasController : Controller
    {

        #region Listar 

        // GET: Editoras
        public ActionResult Listar()
        {
            return View(new Business.EditorasBusiness().ListEditoras());
        }

        public PartialViewResult _TableListarEditoras(int? id = null)
        {
            var listaDeEditorass = new List<Editoras>();

            if (id.HasValue)
                listaDeEditorass.Add(new Business.EditorasBusiness().GetEditoras((int)id));
            else
                listaDeEditorass = new Business.EditorasBusiness().ListEditoras();

            return PartialView(listaDeEditorass);
        }

        #endregion Fim Listar 

        #region Inserir 

        [HttpGet]
        public ActionResult Inserir()
        {
         
            return PartialView();
        }

        [HttpPost]
        public ActionResult Inserir(Editoras editora)
        {
            try
            {

                //if (ModelState.IsValid)
                //{
                new Business.EditorasBusiness().AddEditoras(editora);

                //}
                var retorno = new
                {
                    mensagem = "Editoras Inserido com Sucesso!",
                    erro = false,
                    id = editora.editoraID
                };

                return Json(retorno, JsonRequestBehavior.AllowGet);
            }
            catch (System.Exception e)
            {
                var retorno = new
                {
                    mensagem = e.Message.ToString(),//"Ocorreu algum erro ao inserir Editoras!",
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
            var editora = new Business.EditorasBusiness().GetEditoras(id);

            return View(editora);
        }

        [HttpPost]
        public ActionResult Editar(Editoras editora)
        {
            try
            {
                new Business.EditorasBusiness().EditEditoras(editora);

                var retorno = new
                {
                    mensagem = "Editoras Atualizado com Sucesso!",
                    erro = false,
                    id = editora.editoraID
                };

                return Json(retorno, JsonRequestBehavior.AllowGet);
            }
            catch (System.Exception e)
            {
                var retorno = new
                {
                    mensagem = e.Message.ToString(),//"Ocorreu algum erro ao editar Editoras!",
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
                new Business.EditorasBusiness().DeleteEditoras(id);

                var retorno = new
                {
                    mensagem = "Editoras Excluido com Sucesso!",
                    erro = false
                };

                return Json(retorno, JsonRequestBehavior.AllowGet);
            }
            catch (System.Exception e)
            {
                var retorno = new
                {
                    mensagem = e.Message.ToString(),//"Ocorreu algum erro ao editar Editoras!",
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
            modal.IdModal = "Editoras";
            modal.TipoBotao = (int)Enum.ModalEnum.TipoBotaoEnum.Incluir;
            modal.TituloModal = "Inserir Editoras";
            modal.CaminhoBodyModal = Url.Action("Inserir", "Editoras");

            return PartialView("~/Views/Modal/Modal.cshtml", modal);
        }

        public ActionResult ModalEditar()
        {
            ViewModel.ModalViewModel modal = new ViewModel.ModalViewModel();
            modal.IdModal = "Editoras";
            modal.TipoBotao = (int)Enum.ModalEnum.TipoBotaoEnum.Editar;
            modal.TituloModal = "Editar Editoras";
            modal.CaminhoBodyModal = Url.Action("Editar", "Editoras");

            return PartialView("~/Views/Modal/Modal.cshtml", modal);
        }

        #endregion Fim Modais 

    }
}