using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRCONFI.Projeto.Domain.Entity.Configuration
{
    public class PeriodoAtividadeConfiguration : EntityTypeConfiguration<PeriodoAtividade>
    {
        public PeriodoAtividadeConfiguration()
        {

            this.HasKey(a => a.periodoID);

            this.HasOptional(a => a.DiaSemana)
              .WithMany()
              .HasForeignKey(a => a.diasSemanaID_FK);

            this.HasRequired<Atividades>(s => s.Atividades)
              .WithMany(s => s.PeriodoAtividade)
              .HasForeignKey(s => s.atividadesID_FK);

            //Not Null, Nome da coluna, Identity
            Property(a => a.periodoID)
                .IsRequired()
                .HasColumnName("ID_PERIODO")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(a => a.horaInicio)
         .IsRequired()
         .HasColumnName("DT_HORA_INICIO");


            Property(a => a.horaFim)
    .IsRequired()
    .HasColumnName("DT_HORA_FIM");



        }
    }
}
