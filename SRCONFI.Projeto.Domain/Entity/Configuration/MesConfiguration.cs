using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SRCONFI.Projeto.Domain.Entity.Configuration
{
    public class MesConfiguration : EntityTypeConfiguration<Mes>
    {
        public MesConfiguration()
        {
            this.HasKey(m => m.mesID);

            Property(m => m.mesID)
              .IsRequired()
              .HasColumnName("ID_MES")
              .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(m => m.nomeMes)
              .IsRequired()
              .HasColumnName("TX_NOME_MES");
        }
    }
}
