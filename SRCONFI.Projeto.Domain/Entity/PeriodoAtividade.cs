using System;

namespace SRCONFI.Projeto.Domain.Entity
{
    public class PeriodoAtividade
    {
        public int periodoID { get; set; }

        public int? DiasSemanaID_FK { get; set; }

        public DateTime horaInicio { get; set; }

        public DateTime horaFim { get; set; }

        public virtual DiasSemana DiaSemana { get; set; }

    }
}
