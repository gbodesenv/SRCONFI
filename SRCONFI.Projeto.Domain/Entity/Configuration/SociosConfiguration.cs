using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SRCONFI.Projeto.Domain.Entity.Configuration
{
    public class SociosConfiguration : EntityTypeConfiguration<Socios>
    {
        public SociosConfiguration()
        {
            //Primary Key, relação obrigatória com a tabela TipoUsuario
            this.HasKey(s => s.socioID);

            this.HasOptional(s => s.Endereco)
                .WithMany()
               .HasForeignKey(u => u.enderecoID_FK);

            this.HasOptional(s => s.DadosComplementares)
                .WithMany()
               .HasForeignKey(u => u.dadoComplementarID_FK);

            this.HasOptional(s => s.Categoria)
               .WithMany()
              .HasForeignKey(u => u.categoriaID_FK);

            //Not Null, Nome da coluna, Identity
            Property(u => u.socioID)
                .IsRequired()
                .HasColumnName("ID_SOCIO")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(s => s.categoriaID_FK)
                .IsRequired()
                .HasColumnName("ID_CATEGORIA");

            Property(s => s.categoriaID_FK)
             .IsRequired()
             .HasColumnName("ID_ENDERECO");

            Property(s => s.categoriaID_FK)
             .IsRequired()
             .HasColumnName("ID_DADO_COMPLEMENTAR");

            Property(u => u.nomeSocio)
             .IsRequired()
             .HasMaxLength(100)
             .HasColumnName("TX_NOME_SOCIO");

            Property(u => u.emailsocio)
             .IsRequired()
             .HasMaxLength(250)
             .HasColumnName("TX_EMAIL_SOCIO");

            Property(u => u.telefoneSocio)
             .HasColumnName("NR_TELEFONE_SOCIO");

            Property(u => u.inStatus)
            .IsRequired()
            .HasColumnName("IN_STATUS");

            Property(u => u.dataIngressoSocio)
           .IsRequired()
           .HasColumnName("DT_DATA_INGRESSO_SOCIO");
        }
    }
}
