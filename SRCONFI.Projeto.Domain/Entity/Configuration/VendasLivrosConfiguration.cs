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

            this.HasOptional(v => v.Estoque)
                 .WithMany()
                .HasForeignKey(v => v.estoqueID_FK);

            //Not Null, Nome da coluna, Identity
            Property(v => v.vendaID)
                .IsRequired()
                .HasColumnName("ID_VENDA")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            //Not Null, Nome da coluna, Identity
            Property(v => v.dataVenda)
                .IsRequired()
                .HasColumnName("DT_DATA_VENDA")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(v => v.valorDesconto)
                .IsRequired()
                .HasColumnName("VALOR_DESCONTO")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(v => v.totalVenda)
                .IsRequired()
                .HasColumnName("VL_TOTAL_VENDA")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

        }
    }
}
