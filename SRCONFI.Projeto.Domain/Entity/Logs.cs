using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SRCONFI.Projeto.Domain.Entity
{

    
    public class Logs
    {

        public int logID { get; set; }
        
        public DateTime dataHoraOperacao { get; set; }


        public string operacao { get; set; }


        public string loginUsuario { get; set; }


        public string contexto { get; set; }

        public int? usuarioID_FK { get; set; }

        public virtual Usuario Usuario { get; set; }
        
    }
}
