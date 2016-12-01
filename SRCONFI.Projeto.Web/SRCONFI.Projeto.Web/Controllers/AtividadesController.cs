using SRCONFI.Projeto.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SRCONFI.Projeto.Web.Controllers
{
    public class AtividadesController : Controller
    {

        #region Listar 

        // GET: Atividades
        public ActionResult Listar()
        {
            return View(new Business.AtividadesBusiness().ListAtividades());
        }

        public PartialViewResult _TableListarAtividades(int? id = null)
        {
            var listaDeAtividades = new List<Atividades>();

            if (id.HasValue)
                listaDeAtividades.Add(new Business.AtividadesBusiness().GetAtividades((int)id));
            else
                listaDeAtividades = new Business.AtividadesBusiness().ListAtividades();

            return PartialView(listaDeAtividades);
        }

        #endregion Fim Listar 

        #region Inserir 

        public ActionResult Inserir()
        {
            Combos();
            return PartialView();
        }

        [HttpPost]
        public ActionResult Inserir(Atividades atividades)
        {
            try
            {

                //if (ModelState.IsValid)
                //{
                new Business.AtividadesBusiness().AddAtividades(atividades);

                //}
                var retorno = new
                {
                    mensagem = "Atividade Inserida com Sucesso!",
                    erro = false,
                    id = atividades.atividadeID
                };

                return Json(retorno, JsonRequestBehavior.AllowGet);
            }
            catch (System.Exception e)
            {
                var retorno = new
                {
                    mensagem = e.Message.ToString(),//"Ocorreu algum erro ao inserir Sócios!",
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
            var atividades = new Business.AtividadesBusiness().GetAtividades(id);

            //Combos(atividades.inStatus, atividades.categoriaID_FK);

            return View(atividades);
        }

        [HttpPost]
        public ActionResult Editar(Atividades atividades)
        {
            try
            {
                new Business.AtividadesBusiness().EditAtividades(atividades);

                var retorno = new
                {
                    mensagem = "Sócios Atualizado com Sucesso!",
                    erro = false,
                    id = atividades.atividadeID
                };

                return Json(retorno, JsonRequestBehavior.AllowGet);
            }
            catch (System.Exception e)
            {
                var retorno = new
                {
                    mensagem = e.Message.ToString(),//"Ocorreu algum erro ao editar Sócios!",
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
                new Business.AtividadesBusiness().DeleteAtividades(id);

                var retorno = new
                {
                    mensagem = "Atividades Excluída com Sucesso!",
                    erro = false
                };

                return Json(retorno, JsonRequestBehavior.AllowGet);
            }
            catch (System.Exception e)
            {
                var retorno = new
                {
                    mensagem = e.Message.ToString(),//"Ocorreu algum erro ao editar Sócios!",
                    erro = true
                };

                return Json(retorno, JsonRequestBehavior.AllowGet);
            }
        }


        #endregion Fim Excluir 

        #region Imprimir 
        #endregion Fim Imprimir 

        #region Métodos Auxiliares 

        public void Combos(int? idStatus = null, int? idCategoria = null,
                           string sexo = null, int? idEstadoCivil = null,
                           int? idEscolaridade = null, int? idEstado = null)
        {
            List<SelectListItem> lstStatus = new List<SelectListItem>();

            lstStatus.Add(new SelectListItem()
            {
                Text = "",
                Value = "",
                Selected = (idStatus == null) ? true : false
            });


            lstStatus.Add(new SelectListItem()
            {
                Text = "Ativo",
                Value = "1",
                Selected = (idStatus == 1) ? true : false
            });

            lstStatus.Add(new SelectListItem()
            {
                Text = "Inativo",
                Value = "0",
                Selected = (idStatus == 0) ? true : false
            });


            ViewBag.listStatus = lstStatus;

            List<SelectListItem> selectListCategoria = new List<SelectListItem>();
            var lstCategoria = new Business.CategoriaBusiness().ListCategoria();

            foreach (var item in lstCategoria)
            {
                selectListCategoria.Add(new SelectListItem()
                {
                    Text = item.descricao,
                    Value = item.categoriaID.ToString(),
                    Selected = (idCategoria == item.categoriaID) ? true : false
                });
            }

            ViewBag.listCategoria = selectListCategoria;

            List<SelectListItem> listSexo = new List<SelectListItem>();

            listSexo.Add(new SelectListItem()
            {
                Text = "",
                Value = "",
                Selected = (sexo == null) ? true : false
            });


            listSexo.Add(new SelectListItem()
            {
                Text = "Masculino",
                Value = "M",
                Selected = (sexo == "M") ? true : false
            });

            listSexo.Add(new SelectListItem()
            {
                Text = "Feminino",
                Value = "F",
                Selected = (sexo == "F") ? true : false
            });

            ViewBag.listSexo = listSexo;


            List<SelectListItem> selectListEstadoCivil = new List<SelectListItem>();
            var lstEstadoCivil = new Business.EstadoCivilBusiness().ListEstadoCivil();

            foreach (var item in lstEstadoCivil)
            {
                selectListEstadoCivil.Add(new SelectListItem()
                {
                    Text = item.DescricaoEstadoCivil,
                    Value = item.EstadoCivilID.ToString(),
                    Selected = (idEstadoCivil == item.EstadoCivilID) ? true : false
                });
            }

            ViewBag.listEstadoCivil = selectListEstadoCivil;

            List<SelectListItem> selectListEscolaridade = new List<SelectListItem>();
            var lstEscolaridade = new Business.EscolaridadeBusiness().ListEscolaridade();

            foreach (var item in lstEscolaridade)
            {
                selectListEscolaridade.Add(new SelectListItem()
                {
                    Text = item.descricaoEscolaridade,
                    Value = item.escolaridadeID.ToString(),
                    Selected = (idEscolaridade == item.escolaridadeID) ? true : false
                });
            }

            ViewBag.listEscolaridade = selectListEscolaridade;

            List<SelectListItem> selectListEstado = new List<SelectListItem>();
            var lstEstado = new Business.EstadoBusiness().ListEstado();

            foreach (var item in lstEstado)
            {
                selectListEstado.Add(new SelectListItem()
                {
                    Text = item.Sigla,
                    Value = item.estadoID.ToString(),
                    Selected = (idEstado == item.estadoID) ? true : false
                });
            }

            ViewBag.listEstado = selectListEstado;

        }

        #endregion Fim Métodos Auxiliares 

        #region Modais

        public ActionResult ModalInserir()
        {
            ViewModel.ModalViewModel modal = new ViewModel.ModalViewModel();
            modal.IdModal = "Atividades";
            modal.TipoBotao = (int)Enum.ModalEnum.TipoBotaoEnum.Incluir;
            modal.TituloModal = "Inserir Sócios";
            modal.CaminhoBodyModal = Url.Action("Inserir", "Atividades");

            return PartialView("~/Views/Modal/Modal.cshtml", modal);
        }

        public ActionResult ModalEditar()
        {
            ViewModel.ModalViewModel modal = new ViewModel.ModalViewModel();
            modal.IdModal = "Atividades";
            modal.TipoBotao = (int)Enum.ModalEnum.TipoBotaoEnum.Editar;
            modal.TituloModal = "Editar Sócios";
            modal.CaminhoBodyModal = Url.Action("Editar", "Atividades");

            return PartialView("~/Views/Modal/Modal.cshtml", modal);
        }

        #endregion Fim Modais 
    }
}