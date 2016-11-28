using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SRCONFI.Projeto.Domain.Entity.Configuration
{
    public class VendasLivrosConfiguration : EntityTypeConfiguration<VendasLivros>
    {
        public VendasLivrosConfiguration()
        {

            //Primary Key, relação obrigatória com a tabela TipoUsuario
            this.HasKey(v => v.vendaID);

            this.HasRequired(v => v.Estoque)
                 .WithMany()
                .HasForeignKey(v => v.estoqueID_FK);

            //Not Null, Nome da coluna, Identity
            Property(v => v.vendaID)
                .IsRequired()
                .HasColumnName("ID_VENDA")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(v => v.estoqueID_FK)
            .IsRequired()
            .HasColumnName("ID_ESTOQUE");

            //Not Null, Nome da coluna, Identity
            Property(v => v.dataVenda)
                .IsRequired()
                .HasColumnName("DT_DATA_VENDA");

            Property(v => v.valorDesconto)
                .IsRequired()
                .HasColumnName("VALOR_DESCONTO");

            Property(v => v.totalVenda)
                .IsRequired()
                .HasColumnName("VL_TOTAL_VENDA"); 

        }
    }
}
