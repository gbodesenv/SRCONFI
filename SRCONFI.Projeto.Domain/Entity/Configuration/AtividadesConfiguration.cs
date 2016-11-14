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

            //this.HasOptional(a => a.localID_FK)
            





        }
    }
}
