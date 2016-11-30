﻿using SRCONFI.Projeto.Domain.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace SRCONFI.Projeto.Web.Controllers
{
    public class VendaLivrosController : Controller
    {

        #region Listar 

        // GET: VendaLivros
        public ActionResult Listar()
        {
            return View();
        }

        public PartialViewResult _TableListarVendaLivros(int? id = null)
        {
            var listaDeVendaLivross = new List<VendasLivros>();

            if (id.HasValue)
                listaDeVendaLivross.Add(new Business.VendaLivrosBusiness().GetVendaLivros((int)id));
            else
                listaDeVendaLivross = new Business.VendaLivrosBusiness().ListVendaLivros();

            return PartialView(listaDeVendaLivross);
        }

        #endregion Fim Listar 

        #region Inserir 
        [HttpGet]
        public ActionResult Inserir()
        {
            //Combos();
            return PartialView();
        }

        [HttpPost]
        public ActionResult Inserir(VendasLivros vendaLivro, int idLivro)
        {
            try
            {

                //if (ModelState.IsValid)
                //{
                new Business.VendaLivrosBusiness().AddVendaLivros(vendaLivro, idLivro);

                //}
                var retorno = new
                {
                    mensagem = "Entrada Inserida com Sucesso!",
                    erro = false,
                    id = vendaLivro.vendaID
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
            var vendaLivro = new Business.VendaLivrosBusiness().GetVendaLivros(id);
            var livro = BuscarLivro(id);
            ViewBag.Livro = livro;
            //ViewBag.Quantidade = (vendaLivro.ValorTotalEntrada / vendaLivro.unitarioLivro);
            Combos(livro.editoraID_FK, livro.autorID_FK);
            return View(vendaLivro);
        }

        [HttpPost]
        public ActionResult Editar(VendasLivros vendaLivro, int idLivro)
        {
            try
            {
                new Business.VendaLivrosBusiness().EditVendaLivros(vendaLivro, idLivro);

                var retorno = new
                {
                    mensagem = "Entrada Atualizada com Sucesso!",
                    erro = false,
                    id = vendaLivro.vendaID
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
                new Business.VendaLivrosBusiness().DeleteVendaLivros(id);

                var retorno = new
                {
                    mensagem = "Entrada Excluida com Sucesso!",
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

        #region Livros

        public ActionResult _PesquisarLivros()
        {
            return View();
        }

        [HttpGet]
        public ActionResult _Livro(int id)
        {
            return PartialView(BuscarLivro(null, id));
        }

        #endregion Livros


        #region Métodos Auxiliares 


        private Livros BuscarLivro(int? idEntrada = null, int? idLivro = null)
        {
            Livros livro;
            if (idEntrada.HasValue)
                livro = new Business.LivrosBusiness().GetLivroByEntradaID((int)idEntrada);
            else
                livro = new Business.LivrosBusiness().GetAndRelation((int)idLivro);

            return livro;
        }

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

        public ActionResult ModalPesquisarLivros()
        {
            ViewModel.ModalViewModel modal = new ViewModel.ModalViewModel();
            modal.IdModal = "VendaLivros";
            modal.TipoBotao = (int)Enum.ModalEnum.TipoBotaoEnum.Confirmar;
            modal.TituloModal = "Pesquisar Livros";
            modal.CaminhoBodyModal = Url.Action("PesquisarLivros", "VendaLivros");

            return PartialView("~/Views/Modal/Modal.cshtml", modal);
        }

        public ActionResult ModalEditar()
        {
            ViewModel.ModalViewModel modal = new ViewModel.ModalViewModel();
            modal.IdModal = "VendaLivros";
            modal.TipoBotao = (int)Enum.ModalEnum.TipoBotaoEnum.Editar;
            modal.TituloModal = "Entrada de Livros";
            modal.CaminhoBodyModal = Url.Action("Editar", "VendaLivros");

            return PartialView("~/Views/Modal/Modal.cshtml", modal);
        }

        #endregion Fim Modais 

    }
}