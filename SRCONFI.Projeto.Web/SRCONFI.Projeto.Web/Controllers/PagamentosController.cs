using SRCONFI.Projeto.Domain.Entity;
using SRCONFI.Projeto.Web.Generico;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace SRCONFI.Projeto.Web.Controllers
{
    public class PagamentosController : Controller
    {

        #region Listar 

        // GET: Pagamentos
        public ActionResult Listar()
        {
            Combos();
            return View();
        }

        public PartialViewResult _TableListarPagamentos(int? id = null)
        {
            var listaDePagamentoss = new List<Pagamentos>();

            if (id.HasValue)
                listaDePagamentoss.Add(new Business.PagamentosBusiness().GetPagamentos((int)id));
            else
                listaDePagamentoss = new Business.PagamentosBusiness().ListPagamentos();

            return PartialView(listaDePagamentoss);
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
        public ActionResult Inserir(Pagamentos pagamento)
        {
            try
            {

                //if (ModelState.IsValid)
                //{
                new Business.PagamentosBusiness().AddPagamentos(pagamento);

                //}
                var retorno = new
                {
                    mensagem = "Pagamento Inserida com Sucesso!",
                    erro = false,
                    id = pagamento.pagamentoID
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
            var pagamento = new Business.PagamentosBusiness().GetAndRelation(id);
            Combos();
            return View(pagamento);
        }

        [HttpPost]
        public ActionResult Editar(Pagamentos pagamento)
        {
            try
            {
                new Business.PagamentosBusiness().EditPagamentos(pagamento);

                var retorno = new
                {
                    mensagem = "Pagamento Atualizada com Sucesso!",
                    erro = false,
                    id = pagamento.pagamentoID
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
                new Business.PagamentosBusiness().DeletePagamentos(id);

                var retorno = new
                {
                    mensagem = "Pagamento Excluida com Sucesso!",
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


        public FileResult _PagamentosHistoricoPDF()
        {
            var Html = Generico.Generico.RenderPartialToString(this, "_PagamentosHistoricoPDF", new Business.PagamentosBusiness().ListPagamentos());
            string caminho = Relatorio.GerarRelatorio("Livros", Html, "SRCONFI - Relatório de Usuários");
            byte[] fileBytes = System.IO.File.ReadAllBytes(caminho);
            string fileName = "PagamentosHistorico.pdf";
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
        }

        #endregion Fim Imprimir 

        #region Livros

        public ActionResult _PesquisaSocios()
        {
            return View();
        }

        [HttpGet]
        public ActionResult _Socio(int id)
        {
            return PartialView(BuscarSocios(id));
        }

        #endregion Livros

        #region ConsulaPagamentos

        [HttpGet]
        public ActionResult ConsultaPagamentos()
        {
            return View(new Business.PagamentosBusiness().ListPagamentos());
        }


        [HttpGet]
        public ActionResult RetificarPagamento(int id)
        {
            Combos();
            return View(new Business.PagamentosBusiness().GetAndRelation(id));
        }

        

        #endregion ConsulaPagamentos

        #region Métodos Auxiliares 


        private Socios BuscarSocios(int? id = null)
        {
            return new Business.SociosBusiness().GetAndRelation((int)id);
        }

        public void Combos(int? mesID = null)
        {
            List<SelectListItem> selectListMes = new List<SelectListItem>();
            var lstMes = new Business.MesBusiness().ListMes(); // esse método vai ao banco.

            foreach (var item in lstMes)
            {
                selectListMes.Add(new SelectListItem()
                {
                    Text = item.nomeMes,
                    Value = item.mesID.ToString(),
                    Selected = (mesID == item.mesID) ? true : false
                });
            }

            ViewBag.listMes = selectListMes; //ViewBag - esse cara vai até a view e lá utilizamos ela.

        }

        #endregion Fim Métodos Auxiliares 

        #region Modais

        public ActionResult ModalPesquisarSocios()
        {
            ViewModel.ModalViewModel modal = new ViewModel.ModalViewModel();
            modal.IdModal = "Pagamentos";
            modal.TipoBotao = (int)Enum.ModalEnum.TipoBotaoEnum.Confirmar;
            modal.TituloModal = "Pesquisar Sócios";
            modal.CaminhoBodyModal = Url.Action("PesquisarLivros", "Pagamentos");

            return PartialView("~/Views/Modal/Modal.cshtml", modal);
        }

        public ActionResult ModalEditar()
        {
            ViewModel.ModalViewModel modal = new ViewModel.ModalViewModel();
            modal.IdModal = "Pagamentos";
            modal.TipoBotao = (int)Enum.ModalEnum.TipoBotaoEnum.Editar;
            modal.TituloModal = "Pagamento de Livros";
            modal.CaminhoBodyModal = Url.Action("Editar", "Pagamentos");

            return PartialView("~/Views/Modal/Modal.cshtml", modal);
        }

        #endregion Fim Modais 

    }
}