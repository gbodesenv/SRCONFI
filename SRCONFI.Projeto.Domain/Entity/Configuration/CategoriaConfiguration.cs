using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRCONFI.Projeto.Domain.Entity.Configuration
{
    public class CategoriaConfiguration : EntityTypeConfiguration<Categoria>
    {
        public CategoriaConfiguration()
        {
            //Primary Key, relação obrigatória com a tabela PeriodoAtividade
            this.HasKey(a => a.categoriaID);
            
            //Not Null, Nome da coluna, Identity
            Property(a => a.categoriaID)
                .IsRequired()
                .HasColumnName("ID_CATEGORIA")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(a => a.descricao)
               .IsRequired()
               .HasMaxLength(150)
               .HasColumnName("TX_DESCRICAO");
            
        }

    }
}
