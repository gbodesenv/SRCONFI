using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SRCONFI.Projeto.Domain.Entity.Configuration
{
    public class EstoqueConfiguration : EntityTypeConfiguration<Estoque>
    {
        public EstoqueConfiguration()
        {

            //Primary Key, relação obrigatória com a tabela TipoUsuario
            this.HasKey(e => e.estoqueID);

            this.HasOptional(e => e.EntradasLivros)
                 .WithMany()
                .HasForeignKey(e => e.entradaID_FK);

            this.HasOptional(e => e.Livros)
                 .WithMany()
                .HasForeignKey(e => e.livroID_FK);

            //Not Null, Nome da coluna, Identity
            Property(e => e.estoqueID)
                .IsRequired()
                .HasColumnName("ID_ESTOQUE")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(e => e.nrQuantidade)
               .IsRequired()
               .HasColumnName("NR_QUANTIDADE");

            Property(e => e.vlUnitarioLivro)
               .IsRequired()
               .HasColumnName("VL_VALOR_UNITARIO");
        }
    }

}
