using SRCONFI.Projeto.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SRCONFI.Projeto.Web.Controllers
{
    public class ConsultasController : Controller
    {
        #region ESTOQUE ENTRADAS
        public ActionResult EstoqueEntradas()
        {   
            return View(new Business.EstoqueBusiness().ListEstoqueCompleteRelation());
        }

        public PartialViewResult _TableListarEstoqueEntradas(int? id = null)
        {
            var listaDeEstoques = new List<Estoque>();

            if (id.HasValue)
                listaDeEstoques.Add(new Business.EstoqueBusiness().GetEstoque((int)id));
            else
                listaDeEstoques = new Business.EstoqueBusiness().ListEstoqueCompleteRelation();

            return PartialView(listaDeEstoques);
        }
        #endregion ESTOQUE ENTRADAS

        #region ESTOQUE VENDAS
        public ActionResult EstoqueVendas()
        {
            return View(new Business.VendaLivrosBusiness().ListVendaLivrosAndRelationEstoque());
        }

        public PartialViewResult _TableListarEstoqueVendas(int? id = null)
        {
            var listaDeEstoques = new List<Estoque>();

            if (id.HasValue)
                listaDeEstoques.Add(new Business.EstoqueBusiness().GetEstoque((int)id));
            else
                listaDeEstoques = new Business.EstoqueBusiness().ListEstoqueCompleteRelation();

            return PartialView(listaDeEstoques);
        }
        #endregion ESTOQUE ENTRADAS
    }
}