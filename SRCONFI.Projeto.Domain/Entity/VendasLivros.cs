using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SRCONFI.Projeto.Domain.Entity
{
    public class VendasLivros
    {
        public int vendaID { get; set; }
        public DateTime dataVenda { get; set; }

        public decimal valorDesconto { get; set; }

        public decimal totalVenda { get; set; }

        public int estoqueID_FK { get; set; }

        [ForeignKey("estoqueID_FK")]
        public virtual Estoque Estoque { get; set; }


    }
}
