using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRCONFI.Projeto.Domain.Entity.Configuration
{
    public class LocalAtividadeConfiguration : EntityTypeConfiguration<LocalAtividade>
    {
        public LocalAtividadeConfiguration()
        {
            this.HasKey(a => a.localID);

            this.HasOptional(a => a.PeriodoAtividade)
              .WithMany()
              .HasForeignKey(a => a.periodoID_FK);

            this.HasMany(a => a.PeriodoAtividade)
           .WithRequired(s => s.LocalAtividade)
           .HasForeignKey(s => s.atividadesID_FK);

            //Not Null, Nome da coluna, Identity
            Property(a => a.localID)
                .IsRequired()
                .HasColumnName("ID_LOCAL")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(a => a.descricaoLocal)
               .IsRequired()
               .HasMaxLength(150)
               .HasColumnName("TX_DESCRICAO_LOCAL");

            Property(a => a.nrLotacao)
            .IsRequired()
            .HasColumnName("NR_LOTACAO");

            Property(a => a.inAtivo)
            .IsRequired()            
            .HasColumnName("IN_ATIVO");


            
        }
    }
}
