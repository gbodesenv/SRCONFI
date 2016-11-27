using SRCONFI.Projeto.Domain.Entity;
using System.Collections.Generic;
using System.Web.Mvc;

namespace SRCONFI.Projeto.Web.Controllers
{
    public class LivrosController : Controller
    {

        #region Listar 

        // GET: Livros
        public ActionResult Listar()
        {
            return View(new Business.LivrosBusiness().ListLivros());
        }

        public PartialViewResult _TableListarLivros(int? id = null)
        {
            var listaDeLivross = new List<Livros>();

            if (id.HasValue)
                listaDeLivross.Add(new Business.LivrosBusiness().GetLivros((int)id));
            else
                listaDeLivross = new Business.LivrosBusiness().ListLivros();

            return PartialView(listaDeLivross);
        }

        #endregion Fim Listar 

        #region Inserir 

        [HttpGet]
        public ActionResult Inserir()
        {
            Combos();
            return PartialView();
        }

        [HttpPost]
        public ActionResult Inserir(Livros livros)
        {
            try
            {

                //if (ModelState.IsValid)
                //{
                new Business.LivrosBusiness().AddLivros(livros);

                //}
                var retorno = new
                {
                    mensagem = "Livros Inserido com Sucesso!",
                    erro = false,
                    id = livros.livroID
                };

                return Json(retorno, JsonRequestBehavior.AllowGet);
            }
            catch (System.Exception e)
            {
                var retorno = new
                {
                    mensagem = e.Message.ToString(),//"Ocorreu algum erro ao inserir Livros!",
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
            var livros = new Business.LivrosBusiness().GetLivros(id);

            Combos(livros.editoraID_FK, livros.autorID_FK);

            return View(livros);
        }

        [HttpPost]
        public ActionResult Editar(Livros livros)
        {
            try
            {
                new Business.LivrosBusiness().EditLivros(livros);

                var retorno = new
                {
                    mensagem = "Livros Atualizado com Sucesso!",
                    erro = false,
                    id = livros.livroID
                };

                return Json(retorno, JsonRequestBehavior.AllowGet);
            }
            catch (System.Exception e)
            {
                var retorno = new
                {
                    mensagem = e.Message.ToString(),//"Ocorreu algum erro ao editar Livros!",
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
                new Business.LivrosBusiness().DeleteLivros(id);

                var retorno = new
                {
                    mensagem = "Livros Excluido com Sucesso!",
                    erro = false
                };

                return Json(retorno, JsonRequestBehavior.AllowGet);
            }
            catch (System.Exception e)
            {
                var retorno = new
                {
                    mensagem = e.Message.ToString(),//"Ocorreu algum erro ao editar Livros!",
                    erro = true
                };

                return Json(retorno, JsonRequestBehavior.AllowGet);
            }
        }


        #endregion Fim Excluir 

        #region Imprimir 
        #endregion Fim Imprimir 

        #region Métodos Auxiliares 

        public void Combos(int? editoraID = null, int? autorID = null)
        {
            List<SelectListItem> selectListEditoras = new List<SelectListItem>();
            var lstEditoras = new Business.EditorasBusiness().ListEditoras(); // esse método vai ao banco.

            foreach (var item in lstEditoras)
            {
                selectListEditoras.Add(new SelectListItem()
                {
                    Text = item.nomeEditora,
                    Value = item.editoraID.ToString(),
                    Selected = (editoraID == item.editoraID) ? true : false
                });
            }

            ViewBag.listEditoras = selectListEditoras; //ViewBag - esse cara vai até a view e lá utilizamos ela.

            List<SelectListItem> selectListAutores = new List<SelectListItem>();
            var lstAutores = new Business.AutoresBusiness().ListAutores(); // esse método vai ao banco.

            foreach (var item in lstAutores)
            {
                selectListAutores.Add(new SelectListItem()
                {
                    Text = item.nomeAutor,
                    Value = item.autorID.ToString(),
                    Selected = (editoraID == item.autorID) ? true : false
                });
            }

            ViewBag.listAutores = selectListAutores; //ViewBag - esse cara vai até a view e lá utilizamos ela.


        }

        #endregion Fim Métodos Auxiliares 

        #region Modais

        public ActionResult ModalInserir()
        {
            ViewModel.ModalViewModel modal = new ViewModel.ModalViewModel();
            modal.IdModal = "Livros";
            modal.TipoBotao = (int)Enum.ModalEnum.TipoBotaoEnum.Incluir;
            modal.TituloModal = "Inserir Livros";
            modal.CaminhoBodyModal = Url.Action("Inserir", "Livros");

            return PartialView("~/Views/Modal/Modal.cshtml", modal);
        }

        public ActionResult ModalEditar()
        {
            ViewModel.ModalViewModel modal = new ViewModel.ModalViewModel();
            modal.IdModal = "Livros";
            modal.TipoBotao = (int)Enum.ModalEnum.TipoBotaoEnum.Editar;
            modal.TituloModal = "Editar Livros";
            modal.CaminhoBodyModal = Url.Action("Editar", "Livros");

            return PartialView("~/Views/Modal/Modal.cshtml", modal);
        }

        #endregion Fim Modais 

    }
}