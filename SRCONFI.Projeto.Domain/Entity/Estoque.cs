using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SRCONFI.Projeto.Domain.Entity
{
    public class Estoque
    {
        public int estoqueID { get; set; }

        
        

        public int nrQuantidade { get; set; }

        public decimal vlUnitarioLivro { get; set; }

        public int livroID_FK { get; set; }
        [ForeignKey("livroID_FK")]
        public virtual Livros Livros { get; set; }

        public int entradaID_FK { get; set; }
        [ForeignKey("entradaID_FK")]
        public virtual EntradasLivros EntradasLivros { get; set; }
    }
}
