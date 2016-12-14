using Codaxy.WkHtmlToPdf;
using SRCONFI.Projeto.Domain.Entity;
using System.Collections.Generic;
using System.IO;
using System.Web.Mvc;

namespace SRCONFI.Projeto.Web.Controllers
{
    public class UsuarioController : Controller
    {

        #region Listar 

        // GET: Usuario
        public ActionResult Listar()
        {
            return View(new Business.UsuarioBusiness().ListUsuarios());
        }

        public PartialViewResult _TableListarUsuario(int? id = null)
        {
            var listaDeUsuarios = new List<Usuario>();

            if (id.HasValue)
                listaDeUsuarios.Add(new Business.UsuarioBusiness().GetUsuario((int)id));
            else
                listaDeUsuarios = new Business.UsuarioBusiness().ListUsuarios();

            return PartialView(listaDeUsuarios);
        }

        #endregion Fim Listar 

        #region Inserir 

        public ActionResult Inserir()
        {
            Combos();
            return PartialView();
        }

        [HttpPost]
        public ActionResult Inserir(Usuario usu)
        {
            try
            {

                //if (ModelState.IsValid)
                //{
                new Business.UsuarioBusiness().AddUsuario(usu);

                //}
                var retorno = new
                {
                    mensagem = "Usuário Inserido com Sucesso!",
                    erro = false,
                    id = usu.usuarioID
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
            var usuario = new Business.UsuarioBusiness().GetUsuario(id);

            Combos(usuario.inStatus, usuario.tipoUsuarioID_FK);

            return View(usuario);
        }

        [HttpPost]
        public ActionResult Editar(Usuario usu)
        {
            try
            {
                new Business.UsuarioBusiness().EditUsuario(usu);

                var retorno = new
                {
                    mensagem = "Usuário Atualizado com Sucesso!",
                    erro = false,
                    id = usu.usuarioID
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
                new Business.UsuarioBusiness().DeleteUsuario(id);

                var retorno = new
                {
                    mensagem = "Usuário Excluido com Sucesso!",
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

        public ActionResult _UsuariosPDF()
        {
            var HTML = "<!DOCTYPE html>" +
    "< html lang = 'pt-br' > " +
       "< head > " +
     "< title > Título da página</ title >    " +
        "< meta charset = 'utf-8' >     " +
       "</ head >     " +
       "< body >" +
         "Aqui vai o código HTML que fará seu site aparecer.     " +
       "</ body >" +
     "</ html > ";

            //var users = new Business.UsuarioBusiness().ListUsuarios();
            var Html = RenderPartialToString(this, "_UsuariosPDF", new Business.UsuarioBusiness().ListUsuarios());
            PdfConvert.Environment.Debug = true;
            PdfConvert.ConvertHtmlToPdf(new PdfDocument
            {
                Url = "-",
                Html = Html,
                HeaderLeft = "SRCONFI - Relatório de Usuários ",
                HeaderRight = "[date] [time]",
                FooterCenter = "Page [page] of [topage]"
               

            }, new PdfOutput
            {
                OutputFilePath = "C:/Users/gabri/GitHub/SRCONFI.Projeto/SRCONFI.Projeto.Web/SRCONFI.Projeto.Web/Wkhtmltopdf/wkhtmltopdf-page.pdf"
            });

            return View("Listar");
        }

        public static string RenderPartialToString(Controller controller, string viewName, object model)
        {
            controller.ViewData.Model = model;

            using (StringWriter sw = new StringWriter())
            {
                ViewEngineResult viewResult = ViewEngines.Engines.FindPartialView(controller.ControllerContext, viewName);
                ViewContext viewContext = new ViewContext(controller.ControllerContext, viewResult.View, controller.ViewData, controller.TempData, sw);
                viewResult.View.Render(viewContext, sw);

                return sw.GetStringBuilder().ToString();
            }
        }


        #endregion Fim Imprimir 

        #region Métodos Auxiliares 

        public void Combos(int? idSituacao = null, int? idTipoUsuario = null)
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

            List<SelectListItem> selectListTipoUsuario = new List<SelectListItem>();
            var lstTipoUsuario = new Business.TipoUsuarioBusiness().ListTipoUsuario();

            foreach (var item in lstTipoUsuario)
            {
                selectListTipoUsuario.Add(new SelectListItem()
                {
                    Text = item.descricaoTipoUsuario,
                    Value = item.tipoUsuarioID.ToString(),
                    Selected = (idTipoUsuario == item.tipoUsuarioID) ? true : false
                });
            }

            ViewBag.listTipoUsuario = selectListTipoUsuario;
        }

        #endregion Fim Métodos Auxiliares 

        #region Modais

        public ActionResult ModalInserir()
        {
            ViewModel.ModalViewModel modal = new ViewModel.ModalViewModel();
            modal.IdModal = "Usuario";
            modal.TipoBotao = (int)Enum.ModalEnum.TipoBotaoEnum.Incluir;
            modal.TituloModal = "Inserir Usuário";
            modal.CaminhoBodyModal = Url.Action("Inserir", "Usuario");

            return PartialView("~/Views/Modal/Modal.cshtml", modal);
        }

        public ActionResult ModalEditar()
        {
            ViewModel.ModalViewModel modal = new ViewModel.ModalViewModel();
            modal.IdModal = "Usuario";
            modal.TipoBotao = (int)Enum.ModalEnum.TipoBotaoEnum.Editar;
            modal.TituloModal = "Editar Usuário";
            modal.CaminhoBodyModal = Url.Action("Editar", "Usuario");

            return PartialView("~/Views/Modal/Modal.cshtml", modal);
        }

        #endregion Fim Modais 

    }
}

//using System;
//using System.Collections.Generic;
//using System.Text;
//using System.IO;

//namespace Codaxy.WkHtmlToPdf.Tests
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            Console.InputEncoding = Encoding.UTF8;

//            PdfConvert.Environment.Debug = false;
//            PdfConvert.ConvertHtmlToPdf(new PdfDocument { Url = "http://www.codaxy.com" }, new PdfOutput
//            {
//                OutputFilePath = "codaxy.pdf"
//            });
//            PdfConvert.ConvertHtmlToPdf(new PdfDocument
//            {
//                Url = "http://www.codaxy.com",
//                HeaderLeft = "[title]",
//                HeaderRight = "[date] [time]",
//                FooterCenter = "Page [page] of [topage]"

//            }, new PdfOutput
//            {
//                OutputFilePath = "codaxy_hf.pdf"
//            });
//            PdfConvert.ConvertHtmlToPdf(new PdfDocument { Url = "-", Html = "<html><h1>test</h1></html>" }, new PdfOutput
//            {
//                OutputFilePath = "inline.pdf"
//            });
//            PdfConvert.ConvertHtmlToPdf(new PdfDocument { Url = "-", Html = "<html><h1>測試</h1></html>" }, new PdfOutput
//            {
//                OutputFilePath = "inline_cht.pdf"
//            });


//            //PdfConvert.ConvertHtmlToPdf("http://tweakers.net", "tweakers.pdf");
//        }
//    }
//}