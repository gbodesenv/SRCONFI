using System;
using System.Collections.Generic;

namespace SRCONFI.Projeto.Domain.Entity
{
    public class Atividades
    {
        public int atividadeID { get; set; }

        public int? localID_FK { get; set; }

        public int? periodoID_FK { get; set; }

        public string nomeAtividade { get; set; }

        public string descricaoAtividade { get; set; }

        public DateTime dataInicioAtividade { get; set; }

        public DateTime dataTerminoAtividade { get; set; }

        public bool inAtivo { get; set; }

        public virtual LocalAtividade LocalAtividade { get; set; }

        public virtual IEnumerable<PeriodoAtividade> PeriodoAtividade { get; set; }

    }
}
