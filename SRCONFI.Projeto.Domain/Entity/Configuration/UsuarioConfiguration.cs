using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SRCONFI.Projeto.Domain.Entity.Configuration
{
    public class UsuarioConfiguration : EntityTypeConfiguration<Usuario>
    {
        public UsuarioConfiguration()
        {
            //Primary Key, relação obrigatória com a tabela TipoUsuario
            this.HasKey(u => u.usuarioID)
                .HasRequired(u => u.TipoUsuario);

            //Not Null, Nome da coluna, Identity
            Property(u => u.usuarioID)
                .IsRequired()
                .HasColumnName("ID_USUARIO")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(u => u.email)
               .IsRequired()
               .HasMaxLength(250)
               .HasColumnName("TX_EMAIL_USUARIO");

            Property(u => u.inStatus)
            .IsRequired()
            .HasColumnName("IN_STATUS");

            Property(u => u.login)
            .IsRequired()
            .HasMaxLength(50)
            .HasColumnName("TX_LOGIN_USUARIO");

            Property(u => u.senha)
               .IsRequired()
               .HasMaxLength(50)
               .HasColumnName("TX_SENHA_USUARIO");

            Property(u => u.nome)
            .IsRequired()
            .HasMaxLength(100)
            .HasColumnName("TX_NOME_USUARIO");

            Property(u => u.numeroTelefone)
            .HasColumnName("NR_TELEFONE_USUARIO");

        }
    }
}
