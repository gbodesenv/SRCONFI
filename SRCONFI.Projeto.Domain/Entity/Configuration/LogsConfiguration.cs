using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SRCONFI.Projeto.Domain.Entity.Configuration
{
    public class LogsConfiguration : EntityTypeConfiguration<Logs>
    {
        public LogsConfiguration()
        {
            //Primary Key, relação obrigatória com a tabela Usuario
            this.HasKey(l => l.logID)
                .HasOptional(l => l.Usuario)
                .WithMany()
                .HasForeignKey(l => l.usuarioID_FK);

            //Not Null, Nome da coluna, Identity
            Property(l => l.logID)
            .IsRequired()
            .HasColumnName("ID_LOG")
            .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(l => l.contexto)
            .IsRequired()
            .HasMaxLength(500)
            .HasColumnName("TX_CONTEXTO");

            Property(l => l.dataHoraOperacao)
            .IsRequired()
            .HasColumnName("DT_DATA_HORA_OPERACAO");

            Property(l => l.loginUsuario)
            .IsRequired()
            .HasMaxLength(50)
            .HasColumnName("TX_LOGIN_USUARIO");

            Property(l => l.operacao)
            .IsRequired()
            .HasMaxLength(500)
            .HasColumnName("TX_SENHA_USUARIO");            
        }
    }
}
