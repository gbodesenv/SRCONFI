using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SRCONFI.Projeto.Domain.Entity.Configuration
{
    public class AutoresConfiguration : EntityTypeConfiguration<Autores>
    {
        public AutoresConfiguration()
        {

            this.HasKey(a => a.autorID);

            Property(a => a.autorID)
              .IsRequired()
              .HasColumnName("ID_AUTOR")
              .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(a => a.nomeAutor)
              .IsRequired()
              .HasMaxLength(150)
              .HasColumnName("TX_NOME_AUTOR");

        }

    }
}
