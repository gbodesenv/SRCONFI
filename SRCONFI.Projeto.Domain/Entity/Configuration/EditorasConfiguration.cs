using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SRCONFI.Projeto.Domain.Entity.Configuration
{
    public class EditorasConfiguration : EntityTypeConfiguration<Editoras>
    {
        public  EditorasConfiguration()
        {

            this.HasKey(e => e.EditoraID);

            Property(e => e.EditoraID)
              .IsRequired()
              .HasColumnName("ID_EDITORA")
              .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(e => e.nomeEditora)
              .IsRequired()
              .HasMaxLength(150)
              .HasColumnName("TX_NOME_EDITORA");

            Property(e => e.siglaEditroa)
              .IsRequired()
              .HasMaxLength(150)
              .HasColumnName("TX_SIGLA_EDITORA");



        }
    }
}
