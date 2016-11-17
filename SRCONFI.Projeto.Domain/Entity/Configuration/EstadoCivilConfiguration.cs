using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRCONFI.Projeto.Domain.Entity.Configuration
{
    public class EstadoCivilConfiguration : EntityTypeConfiguration<EstadoCivil>
    {
        public EstadoCivilConfiguration()
        {

            //Primary Key, relação obrigatória com a tabela PeriodoAtividade
            this.HasKey(a => a.EstadoCivilID);

            //Not Null, Nome da coluna, Identity
            Property(a => a.EstadoCivilID)
                .IsRequired()
                .HasColumnName("ID_ESCOLARIDADE")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(a => a.DescricaoEstadoCivil)
               .IsRequired()
               .HasMaxLength(150)
               .HasColumnName("TX_DESCRICAO_EST_CIV");

        }
          

    }
}
