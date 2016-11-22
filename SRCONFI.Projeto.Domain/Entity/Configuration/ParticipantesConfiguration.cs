using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRCONFI.Projeto.Domain.Entity.Configuration
{
    public class ParticipantesConfiguration : EntityTypeConfiguration<Participantes>
    {
        public ParticipantesConfiguration()
        {
            //Primary Key, relação obrigatória com a tabela PeriodoAtividade
            this.HasKey(a => a.participanteID);

            this.HasOptional(a => a.Socios)
                .WithMany()
                .HasForeignKey(a => a.socioID);

            this.HasOptional(a => a.Atividades)
                .WithMany()
                .HasForeignKey(a => a.atividadeID);

            //Not Null, Nome da coluna, Identity
            Property(a => a.participanteID)
                .IsRequired()
                .HasColumnName("ID_PARTICIPANTE")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

        }

    }
}
