using System;
using System.Data.Entity.ModelConfiguration;

namespace SRCONFI.Projeto.Domain.Entity.Configuration
{
    public class AtividadesConfiguration : EntityTypeConfiguration<Atividades>
    {
        public AtividadesConfiguration()
        {

            //Primary Key, relação obrigatória com a tabela PeriodoAtividade

            this.HasKey(a => a.atividadeID);

            this.HasOptional(a => a.LocalAtividade)
                .WithMany()
                .HasForeignKey(a => a.localID_FK);

            this.HasOptional(a => a.PeriodoAtividade)
                .WithMany()
                .HasForeignKey(a => a.periodoID_FK);


            //Not Null, Nome da coluna, Identity
            Property(a => a.atividadeID)
                .IsRequired()
                .HasColumnName("ID_ATIVIDADE")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(a => a.nomeAtividade)
               .IsRequired()
               .HasMaxLength(250)
               .HasColumnName("TX_NOME_ATIVIDADE");

            Property(a => a.descricaoAtividade)
            .IsRequired()
            .HasMaxLength(250)
            .HasColumnName("TX_DESCRICAO_ATIVIDADE");

            Property(a => a.dataInicioAtividade)
            .IsRequired()
            .HasColumnName("DT_DATA_INICIO_ATIVIDADE");

            Property(a => a.dataTerminoAtividade)
               .IsRequired()
               .HasColumnName("DT_DATA_TERMINO_ATIVIDADE");

            Property(a => a.inAtivo)
            .IsRequired()
            .HasColumnName("IN_INATIVO");


        }
    }
}
