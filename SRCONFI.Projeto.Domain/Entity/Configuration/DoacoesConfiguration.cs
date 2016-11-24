using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SRCONFI.Projeto.Domain.Entity.Configuration
{
    public class DoacoesConfiguration : EntityTypeConfiguration<Doacoes>
    {

        public DoacoesConfiguration()
        {
            this.HasKey(d => d.doacaoID);

            Property(d => d.doacaoID)
              .IsRequired()
              .HasColumnName("ID_DOACAO")
              .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(d => d.valorDoacao)
              .IsRequired()
              .HasColumnName("VL_VALOR_DOACAO");

            Property(d => d.comentarioDoacao)
              .IsRequired()
              .HasMaxLength(250)
              .HasColumnName("TX_COMENTARIO_DOACAO");

            Property(d => d.dataDoacao)
              .IsRequired()
              .HasColumnName("DT_DATA_DOACAO");

            Property(d => d.nomeDoador)
              .IsRequired()
              .HasMaxLength(150)
              .HasColumnName("TX_NOME_DOADOR");
        }
    }
}
