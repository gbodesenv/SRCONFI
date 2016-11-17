using System;

namespace SRCONFI.Projeto.Domain.Entity
{
    public class PeriodoAtividade
    {
        public PeriodoAtividade()
        {
            Atividades = new Atividades();
            LocalAtividade = new LocalAtividade();
        }

        public int periodoID { get; set; }

        public int? diasSemanaID_FK { get; set; }

        public DateTime horaInicio { get; set; }

        public DateTime horaFim { get; set; }

        public virtual DiasSemana DiaSemana { get; set; }



        public int atividadesID_FK { get; set; }

        public int? localAtividadeID_FK { get; set; }

        public virtual Atividades Atividades { get; set; }

        public virtual LocalAtividade LocalAtividade { get; set; }
    }
}
