using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SRCONFI.Projeto.Domain.Entity.Configuration
{
    public class PagamentosConfiguration : EntityTypeConfiguration<Pagamentos>
    {

        public  PagamentosConfiguration()
        {

            //Primary Key, relação obrigatória com a tabela PeriodoAtividade

            this.HasKey(p => p.pagamentoID);

            this.HasRequired(p => p.Socios)
                .WithMany()
                .HasForeignKey(p => p.socioID_FK);

            this.HasRequired(p => p.Mes)
                .WithMany()
                .HasForeignKey(p => p.mesID_FK);

            //Not Null, Nome da coluna, Identity
            Property(p => p.pagamentoID )
                .IsRequired()
                .HasColumnName("ID_PAGAMENTO")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(p => p.socioID_FK)
                .IsRequired()
                .HasColumnName("ID_SOCIO");

            Property(p => p.mesID_FK)
                .IsRequired()
                .HasColumnName("ID_MES");

            Property(p => p.dataPag)
                .IsRequired()
                .HasColumnName("DT_DATA_PAG");

            Property(p => p.valorPag)
              .IsRequired()
              .HasColumnName("VL_VALOR_PAG");

            Property(p => p.comentarioPag)
               .IsRequired()
               .HasMaxLength(250)
               .HasColumnName("TX_COMENTARIO_PAG");

            Property(p => p.justificativaCanc)
               .IsRequired()
               .HasMaxLength(250)
               .HasColumnName("TX_JUSTIFICATIVA_CANC");

            Property(p => p.dataCanc)
               .IsRequired()
               .HasColumnName("DT_DATA_CANC");

            Property(p => p.justificativaRetificacao)
               .IsRequired()
               .HasMaxLength(250)
               .HasColumnName("TX_JUSTIFICATIVA_RETIFICACAO");

            Property(p => p.dataRetificacao)
               .IsRequired()
               .HasColumnName("DT_DATA_RETIFICACAO");


            Property(p => p.inCancelado)
            .IsRequired()
            .HasColumnName("IN_CANCELADO");

        }


    }
}
