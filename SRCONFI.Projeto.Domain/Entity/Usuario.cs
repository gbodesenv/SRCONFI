using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SRCONFI.Projeto.Domain.Entity
{
    [Table("TB_USUARIOS")]
    public class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID_USUARIO")]
        public int usuarioID { get; set; }

        [MaxLength(100)]// EF knows what will be the maximum lenght of the column in the database (like varchar(50)).
        [StringLength(100)]//Used for validation on the client side.
        [Column("TX_NOME_USUARIO")]
        public string nome { get; set; }

        [MaxLength(50)]
        [StringLength(100)]
        [Column("TX_LOGIN_USUARIO")]
        public string login { get; set; }

        [MaxLength(50)]
        [StringLength(100)]
        [Column("TX_SENHA_USUARIO")]
        public string senha { get; set; }

        [MaxLength(250)]
        [StringLength(100)]
        [Column("TX_EMAIL_USUARIO")]
        public string email { get; set; }

        [Column("NR_TELEFONE")]
        public int numeroTelefone { get; set; }
    }
}
