using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace SRCONFI.Projeto.Web.Helpers
{
    public static class CamposHtmlHelper
    {
        //@Html.TextBoxFor(model => model.email, new { @class = "form-control", @placeholder = "E-mail", @type="email", @data_parsley_type = "email", @data_parsley_required = "", @data_parsley_error_message = "O campo 'E-mail' é obrigatório" })

        //public static class MvcHtmlString TextBoxEmail(this HtmlHelper TextBoxEmail, string idCampo, )
         
    }
}


// public static HtmlString AtributoEspecificacaoTexto(this HtmlHelper htmlHelper, int id, string nomeAtributoEspecifTecnica,
//                                                                    string textoValue, string siglaValue, string obrigatorio, int? nroMaxCaracteres, string caracteresPermitidos, string legenda)
//{
//    bool obrig = obrigatorio == "1";

//    StringBuilder html = new StringBuilder();

//    html.Append("<div class='d6'>");
//    html.Append(LabelCampo(nomeAtributoEspecifTecnica, legenda, obrig));
//    html.Append(HiddenTipoAtributo(htmlHelper, id, TipoAtributoEspecEnum.Texto));
//    if (nroMaxCaracteres.HasValue && nroMaxCaracteres.Value > 0)
//    {
//        if (!string.IsNullOrEmpty(caracteresPermitidos))
//            html.Append(InputExtensions.TextBox(htmlHelper, ID(id), textoValue,
//                new { @maxlength = nroMaxCaracteres, @class = "caracteres-permitidos", @permitidos = caracteresPermitidos, @data_required = obrig }).ToHtmlString());
//        else
//            html.Append(InputExtensions.TextBox(htmlHelper, ID(id), textoValue,
//                new { @maxlength = nroMaxCaracteres, @data_required = obrig }).ToHtmlString());
//    }
//    else
//    {
//        if (!string.IsNullOrEmpty(caracteresPermitidos))
//            html.Append(InputExtensions.TextBox(htmlHelper, ID(id), textoValue, new { @class = "caracteres-permitidos", @permitidos = caracteresPermitidos, @data_required = obrig }).ToHtmlString());
//        else
//            html.Append(InputExtensions.TextBox(htmlHelper, ID(id), textoValue, new { @data_required = obrig }).ToHtmlString());
//    }

//    html.Append("</div>");
//    return new HtmlString(html.ToString());
//}