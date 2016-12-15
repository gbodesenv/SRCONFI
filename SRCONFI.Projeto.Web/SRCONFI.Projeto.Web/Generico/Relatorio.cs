using Codaxy.WkHtmlToPdf;
using System;
using System.Web.Mvc;

namespace SRCONFI.Projeto.Web.Generico
{
    public static class Relatorio
    {

        public static string GerarRelatorio(string pasta, string html, string nomeRelatorio)
        {
            var caminho = String.Format("C:/Users/gabriel.oliveira/Source/Repos/SRCONFI/SRCONFI.Projeto.Web/SRCONFI.Projeto.Web/PDF/{0}", pasta);

            if (!Arquivo.VerificarPasta(caminho))
                Arquivo.CriarPasta(caminho);

            string arquivo = String.Format("{0}_{1}.pdf", pasta, DateTime.Now.ToString().Trim()
                                                                             .Replace("/", "").Trim()
                                                                             .Replace(":", "").Trim()
                                                                             .Replace(" ", "").Trim());
            var caminhoFinal = String.Format("{0}/{1}", caminho, arquivo);

            PdfConvert.Environment.Debug = true;
            PdfConvert.ConvertHtmlToPdf(new PdfDocument
            {
                Url = "-",
                Html = html,
                HeaderLeft = nomeRelatorio,
                HeaderRight = "Data: [date] Hora: [time]",
                FooterCenter = "Página [page] de [topage]"


            }, new PdfOutput
            {
                //OutputStream = Arquivo.AbrirArquivo(caminhoFinal)
                OutputFilePath = caminhoFinal
            });

            return caminhoFinal;
        }
        
    }
}