using System;

namespace SRCONFI.Projeto.Domain.Entity
{
    public class VendasLivros
    {
        public int vendaID { get; set; }

        public int? estoqueID { get; set; }

        public DateTime dataVenda { get; set; }

        public decimal valorDesconto { get; set; }

        public decimal totalVenda { get; set; }


    }
}
