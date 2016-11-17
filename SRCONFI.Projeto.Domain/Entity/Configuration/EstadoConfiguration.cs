using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRCONFI.Projeto.Domain.Entity.Configuration
{
    public class EstadoConfiguration : EntityTypeConfiguration<Estado>
    {
        public EstadoConfiguration()
        {
            this.HasKey(a => a.estadoID);

            //Not Null, Nome da coluna, Identity
            Property(a => a.estadoID)
                .IsRequired()
                .HasColumnName("ID_UF")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(a => a.Nome)
               .IsRequired()
               .HasMaxLength(150)
               .HasColumnName("TX_NOME_UF");

            Property(a => a.Sigla)
            .IsRequired()
            .HasMaxLength(20)
            .HasColumnName("TX_SIGLA_UF");
        }
    }
}
