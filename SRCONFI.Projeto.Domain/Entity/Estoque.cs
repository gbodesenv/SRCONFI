using System;


namespace SRCONFI.Projeto.Domain.Entity
{
    public class Estoque
    {
        public int estoqueID { get; set; }

        public int? livroID_FK { get; set; }

        public int? entradaID_FK { get; set; }

        public int nrQuantidade { get; set; }

        public decimal vlUnitarioLivro { get; set; }
    }
}
