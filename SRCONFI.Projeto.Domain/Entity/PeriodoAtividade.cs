using System;

namespace SRCONFI.Projeto.Domain.Entity
{
    public class PeriodoAtividade
    {
        public int periodoID { get; set; }

        public int? SemanaDiaID_FK { get; set; }

        public DateTime horaInicio { get; set; }

        public DateTime horaFim { get; set; }

    }
}
