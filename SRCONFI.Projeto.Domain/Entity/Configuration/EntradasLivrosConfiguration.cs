using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;


namespace SRCONFI.Projeto.Domain.Entity.Configuration
{
    public class EntradasLivrosConfiguration : EntityTypeConfiguration<EntradasLivros>
    {
        public EntradasLivrosConfiguration()
        {

            this.HasKey(e => e.entradaID);

            Property(e => e.entradaID)
              .IsRequired()
              .HasColumnName("ID_ENTRADA")
              .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(e => e.notaFiscal)
              .IsRequired()
              .HasMaxLength(50)
              .HasColumnName("TX_NOTA_FISCAL");

            Property(e => e.ValorTotalEntrada)
              .IsRequired()
              .HasColumnName("VL_VALOR_TOTAL_ENTRADA");

            Property(e => e.unitarioLivro)
              .IsRequired()
              .HasColumnName("VL_UNITARIO_LIVRO");

            Property(e => e.dataEntrada)
              .IsRequired()
              .HasColumnName("DT_DATA_ENTRADA");

        }

    }
}
