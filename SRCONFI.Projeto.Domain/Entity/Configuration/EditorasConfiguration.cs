using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SRCONFI.Projeto.Domain.Entity.Configuration
{
    public class EditorasConfiguration : EntityTypeConfiguration<Editoras>
    {
        public  EditorasConfiguration()
        {

            this.HasKey(e => e.editoraID);

            Property(e => e.editoraID)
              .IsRequired()
              .HasColumnName("ID_EDITORA")
              .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(e => e.nomeEditora)
              .IsRequired()
              .HasMaxLength(150)
              .HasColumnName("TX_NOME_EDITORA");

            Property(e => e.siglaEditora)
              .IsRequired()
              .HasMaxLength(50)
              .HasColumnName("TX_SIGLA_EDITORA");



        }
    }
}
