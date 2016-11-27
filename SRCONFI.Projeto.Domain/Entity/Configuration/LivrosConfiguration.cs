using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SRCONFI.Projeto.Domain.Entity.Configuration
{
    public class LivrosConfiguration : EntityTypeConfiguration<Livros>
    {
        public LivrosConfiguration()
        {

            //Primary Key, relação obrigatória com a tabela TipoUsuario
            this.HasKey(l => l.livroID);

            this.HasRequired(l => l.Autores)
                 .WithMany()
                .HasForeignKey(l => l.autorID_FK);

            this.HasRequired(l => l.Editoras)
                 .WithMany()
                .HasForeignKey(l => l.editoraID_FK);

            //Not Null, Nome da coluna, Identity
            Property(l => l.livroID)
                .IsRequired()
                .HasColumnName("ID_LIVRO")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(s => s.autorID_FK)
            .IsRequired()
            .HasColumnName("ID_AUTOR");
            
            Property(s => s.editoraID_FK)
            .IsRequired()
            .HasColumnName("ID_EDITORA");

            Property(l => l.nomeAutor)
            .IsRequired()
            .HasColumnName("TX_NOME_AUTOR");

        }
    }
}
