using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SRCONFI.Projeto.Domain.Entity
{
    [Table("TB_LOGS")]
    
    public class Logs
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID_LOG")]
        public int logID { get; set; }

        [Column("DT_DATA_HORA_OPERACAO")]
        public DateTime dataHoraOperacao { get; set; }

        [MaxLength(500)]
        [StringLength(500)]
        [Column("TX_OPERACA")]
        public string operacao { get; set; }

        [MaxLength(50)]
        [StringLength(50)]
        [Column("TX_LOGIN_USUARIO")]
        public string loginUsuario { get; set; }

        [MaxLength(500)]
        [StringLength(500)]
        [Column("TX_CONTEXTO")]
        public string contexto { get; set; }
        
    }
}
