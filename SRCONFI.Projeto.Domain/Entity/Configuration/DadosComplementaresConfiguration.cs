using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRCONFI.Projeto.Domain.Entity.Configuration
{
    public class DadosComplementaresConfiguration : EntityTypeConfiguration<DadosComplementares>
    {
        public DadosComplementaresConfiguration()
        {
            //Primary Key, relação obrigatória com a tabela PeriodoAtividade

            this.HasKey(a => a.dadoComplementarID);

            this.HasOptional(a => a.Escolaridade)
                .WithMany()
                .HasForeignKey(a => a.escolaridadeID_FK);

            this.HasOptional(a => a.EstadoCivil)
                .WithMany()
                .HasForeignKey(a => a.EstadoCivilID_FK);


            //Not Null, Nome da coluna, Identity
            Property(a => a.dadoComplementarID)
                .IsRequired()
                .HasColumnName("ID_DADO_COMPLEMENTAR")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(a => a.nrCpfSocio)
               .IsRequired()
               .HasColumnName("NR_CPF_SOCIO");

            Property(a => a.rgSocio)
            .IsRequired()
            .HasMaxLength(50)
            .HasColumnName("TX_RG_SOCIO");

            Property(a => a.sexoSocio)
            .IsRequired()
            .HasMaxLength(50)
            .HasColumnName("TX_SEXO_SOCIO");

            Property(a => a.dataNascSocio)
               .IsRequired()
               .HasColumnName("DT_DATA_NASC_SOCIO");

            Property(a => a.nrCelularSocio)
            .IsRequired()
            .HasColumnName("NR_CELULAR_SOCIO");

            Property(a => a.nacionalidadeSocio)
       .IsRequired()
       .HasMaxLength(150)
       .HasColumnName("TX_NACIONALIDADE_SOCIO");

            Property(a => a.profissaoSocio)
      .IsRequired()
      .HasMaxLength(150)
      .HasColumnName("TX_PROFISSAO_SOCIO");
        }

    }
}
