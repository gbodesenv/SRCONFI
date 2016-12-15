using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SRCONFI.Projeto.Web.Generico
{
    public static class Arquivo
    {
        /// <summary>
        /// Verifica existência de arquivo
        /// </summary>
        /// <param name="caminhoArquivo"></param>
        /// <returns></returns>
        public static bool VerificarExistenciaArquivo(String caminhoArquivo)
        {
            FileInfo arquivo = new FileInfo(caminhoArquivo);

            if (arquivo.Exists)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Verifica existência da pasta
        /// </summary>
        /// <param name="caminho"></param>
        /// <returns></returns>
        public static bool VerificarPasta(String caminho)
        {
            DirectoryInfo pasta = new DirectoryInfo(caminho);
            return pasta.Exists;
        }

        /// <summary>
        /// Cria pasta caso ela não exista
        /// </summary>
        /// <param name="caminho"></param>
        public static void CriarPasta(String caminho)
        {
            DirectoryInfo pasta = new DirectoryInfo(caminho);
            if (!VerificarPasta(caminho))
                pasta.Create();
        }

        /// <summary>
        /// Retorna lista de sub pastas
        /// </summary>
        /// <param name="caminho"></param>
        public static List<String> ListarSubPastas(String caminho)
        {
            List<String> lstSubPastas = new List<String>();

            if (VerificarPasta(caminho))
            {
                DirectoryInfo pasta = new DirectoryInfo(caminho);

                foreach (var subDiretorio in pasta.GetDirectories().ToList())
                    lstSubPastas.Add(subDiretorio.Name);
            }

            return lstSubPastas;
        }

        /// <summary>
        /// Retorna lista de Arquivos
        /// </summary>
        /// <param name="caminho"></param>
        public static List<String> ListarArquivos(String caminho)
        {
            List<String> lstArquivos = new List<String>();

            if (VerificarPasta(caminho))
            {
                DirectoryInfo pasta = new DirectoryInfo(caminho);

                pasta.GetFiles().ToList().ForEach(new Action<FileInfo>(delegate (FileInfo subDiretorio)
                {
                    lstArquivos.Add(subDiretorio.Name);
                }));
            }

            return lstArquivos;
        }
        
        /// <summary>
        /// Adiona texto no arquivo, NÃO substitui
        /// </summary>
        /// <param name="caminhoArquivo"></param>
        /// <param name="conteudoArquivo"></param>
        /// <param name="encode"></param>
        public static void AdicionarConteudoArquivo(String caminhoArquivo, String conteudoArquivo, Encoding encode)
        {
            var objWriter = new StreamWriter(caminhoArquivo, true, encode);

            objWriter.WriteLine(conteudoArquivo);
            objWriter.Flush();

            if (objWriter != null)
                objWriter.Close();
        }

        /// <summary>
        /// Retorna a data do arquivo mais atualizado
        /// </summary>
        /// <param name="caminho"></param>
        /// <returns></returns>
        public static DateTime BuscarDataModificacaoArquivos(String caminho)
        {
            try
            {
                DirectoryInfo pasta = new DirectoryInfo(caminho);
                List<DateTime> listaDatas = new List<DateTime>();
                List<DirectoryInfo> subDiretorios = pasta.GetDirectories().ToList();

                listaDatas.Add(pasta.GetFiles().Max(f => f.LastWriteTime));

                if (subDiretorios.Count > 0)
                {
                    subDiretorios.ForEach(new Action<DirectoryInfo>(delegate (DirectoryInfo diretorio)
                    {
                        if (diretorio.GetFiles().Count() > 0)
                            listaDatas.Add(diretorio.GetFiles().Max(f => f.LastWriteTime));
                    }));
                }

                var ultimaModificacao = listaDatas.OrderByDescending(d => d.Ticks).First();
                return ultimaModificacao;
            }
            catch
            {
                return DateTime.MinValue;
            }
        }

        /// <summary>
        /// Deleta o arquivo
        /// </summary>
        /// <param name="caminhoArquivo"></param>
        /// <returns></returns>
        public static string ExcluirArquivo(string caminhoArquivo)
        {
            if (System.IO.File.Exists(caminhoArquivo))
            {
                try
                {
                    System.IO.File.Delete(caminhoArquivo);
                }
                catch (System.IO.IOException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return string.Empty;
        }

        /// <summary>
        /// Deleta o arquivo
        /// </summary>
        /// <param name="localarquivo"></param>
        /// <returns></returns>
        public static string ExcluirArquivo(List<string> lstCaminhoArquivo)
        {
            foreach (string caminhoArquivo in lstCaminhoArquivo)
            {
                if (System.IO.File.Exists(caminhoArquivo))
                {
                    try
                    {
                        System.IO.File.Delete(caminhoArquivo);
                    }
                    catch (System.IO.IOException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }

            return string.Empty;
        }

        public static int SalvarArquivo(Stream arquivo, string caminhoArquivo)
        {
            FileStream fs = File.Create(caminhoArquivo);
            arquivo.CopyTo(fs);
            fs.Close();
            return 1;
        }

        public static FileStream AbrirArquivo(string caminhoArquivo)
        {
            return File.OpenRead(caminhoArquivo);
        }
    }
}
