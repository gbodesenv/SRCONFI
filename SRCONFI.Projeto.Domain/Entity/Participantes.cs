using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRCONFI.Projeto.Domain.Entity
{
    public class Participantes
    {
        public int participanteID { get; set; }

        public int? socioID { get; set; }

        public int? atividadeID { get; set; }

        public virtual ICollection<Atividades> Atividades { get; set; }
        public virtual ICollection<Socios> Socios { get; set; }

    }
}
