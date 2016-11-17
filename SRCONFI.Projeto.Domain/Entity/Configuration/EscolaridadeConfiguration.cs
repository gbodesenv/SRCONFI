using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRCONFI.Projeto.Domain.Entity.Configuration
{
    public class EscolaridadeConfiguration : EntityTypeConfiguration<Escolaridade>
    {
        public EscolaridadeConfiguration()
        {
            //Primary Key, relação obrigatória com a tabela PeriodoAtividade
            this.HasKey(a => a.escolaridadeID);
            
            //Not Null, Nome da coluna, Identity
            Property(a => a.escolaridadeID)
                .IsRequired()
                .HasColumnName("ID_ESCOLARIDADE")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(a => a.descricaoEscolaridade)
               .IsRequired()
               .HasMaxLength(150)
               .HasColumnName("TX_DESC_ESCOL");
            
        }
    }
}
