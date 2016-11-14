using System;

namespace SRCONFI.Projeto.Domain.Entity
{
    public class LocalAtividade
    {
        public int localID { get; set; }

        public int? periodoID_FK { get; set; }

        public string descricaoLocal { get; set; }

        public int nrLotacao { get; set; }

        public bool inAtivo { get; set; }
    }
}
