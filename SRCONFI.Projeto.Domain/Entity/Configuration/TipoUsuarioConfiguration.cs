using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SRCONFI.Projeto.Domain.Entity.Configuration
{
    public class TipoUsuarioConfiguration : EntityTypeConfiguration<TipoUsuario>
    {
        public TipoUsuarioConfiguration()
        {
            //primary key
            this.HasKey(t => t.tipoUsuarioID);

            Property(t => t.tipoUsuarioID)
              .IsRequired()
              .HasColumnName("ID_TIPO_USUARIO")
              .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(t => t.descricaoTipoUsuario)
              .IsRequired()
              .HasMaxLength(250)
              .HasColumnName("TX_DESC_TIPO_USUARIO");

        }
    }
}
