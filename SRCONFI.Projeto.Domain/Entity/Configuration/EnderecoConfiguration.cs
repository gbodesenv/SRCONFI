using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRCONFI.Projeto.Domain.Entity.Configuration
{
    public class EnderecoConfiguration : EntityTypeConfiguration<Endereco>
    {
        public EnderecoConfiguration()
        {
            //Primary Key, relação obrigatória com a tabela PeriodoAtividade

            this.HasKey(a => a.enderecoID);

            this.HasOptional(a => a.Estado)
                .WithMany()
                .HasForeignKey(a => a.estadoID_FK);

            //Not Null, Nome da coluna, Identity
            Property(a => a.enderecoID)
                .IsRequired()
                .HasColumnName("ID_ENDERECO")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(a => a.cidade)
               .IsRequired()
               .HasMaxLength(150)
               .HasColumnName("TX_CIDADE");

            Property(a => a.numeroCEP)
            .IsRequired()
            .HasColumnName("NR_CEP");

            Property(a => a.endereco)
            .IsRequired()
            .HasMaxLength(250)
            .HasColumnName("TX_ENDERECO");

            Property(a => a.numero)
               .IsRequired()
               .HasColumnName("NR_NUMERO");

            Property(a => a.complemento)
            .IsRequired()
             .HasMaxLength(150)
            .HasColumnName("TX_COMPLEMENTO");


            Property(a => a.bairro)
      .IsRequired()
      .HasMaxLength(150)
      .HasColumnName("TX_BAIRRO");
        }

    }
}

