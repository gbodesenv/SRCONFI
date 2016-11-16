using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SRCONFI.Projeto.Domain.Entity.Configuration
{
    public class DiasSemanaConfiguration : EntityTypeConfiguration<DiasSemana>
    {
        public DiasSemanaConfiguration()
        {

            this.HasKey(d => d.SemanaDiaID);

            Property(d => d.SemanaDiaID)
              .IsRequired()
              .HasColumnName("ID_DIA_SEMANA")
              .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(d => d.NomeSemana)
              .IsRequired()
              .HasMaxLength(250)
              .HasColumnName("TX_NOME_SEMANA");





        }
    }
}
