using SRCONFI.Projeto.Domain.Entity;
using SRCONFI.Projeto.Web.Generico;
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

        public FileResult _EstoqueEntradasPDF()
        {
            var Html = Generico.Generico.RenderPartialToString(this, "_EstoqueEntradasPDF", new Business.EstoqueBusiness().ListEstoqueCompleteRelation());
            string caminho = Relatorio.GerarRelatorio("EstoqueEntradas", Html, "SRCONFI - Relatório de Entrada de Livros");
            byte[] fileBytes = System.IO.File.ReadAllBytes(caminho);
            string fileName = "Entradas_Livros.pdf";
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
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


        public FileResult _EstoqueVendasPDF()
        {
            var Html = Generico.Generico.RenderPartialToString(this, "_EstoqueVendasPDF", new Business.VendaLivrosBusiness().ListVendaLivrosAndRelationEstoque());
            string caminho = Relatorio.GerarRelatorio("EstoqueVendas", Html, "SRCONFI - Relatório de Entrada de Livros");
            byte[] fileBytes = System.IO.File.ReadAllBytes(caminho);
            string fileName = "Entradas_Livros.pdf";
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
        }


        #endregion ESTOQUE ENTRADAS
    }
}