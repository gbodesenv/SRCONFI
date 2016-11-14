using System;
namespace SRCONFI.Projeto.Domain.Entity
{
    public class EntradasLivros
    {
        public int entradaID { get; set; }

        public string notaFiscal { get; set; }

        public decimal ValorTotalEntrada { get; set; }

        public decimal unitarioLivro { get; set; }

        public DateTime  dataEntrada { get; set; }
        
    }
}
