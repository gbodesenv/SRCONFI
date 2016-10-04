using SRCONFI.Projeto.Domain.Entity;
using SRCONFI.Projeto.Domain.Entity.Configuration;
using System.Data.Entity;

namespace SRCONFI.Projeto.Domain
{
    public class BancoContext : DbContext
    {
        #region Construtor
        public BancoContext()
            : base("DBSRCONFI")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }
        #endregion Construtor

        #region Entidades/Tabelas

        #region Inclusão
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<TipoUsuario> TipoUsuario { get; set; }
        public DbSet<Logs> Log { get; set; }

        #endregion Inclusão
        
        #region Configurações 
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Configurations
                .Add(new UsuarioConfiguration())
                .Add(new TipoUsuarioConfiguration())
                .Add(new LogsConfiguration()
            );

            modelBuilder.Entity<Usuario>().ToTable("TB_USUARIOS");
            modelBuilder.Entity<TipoUsuario>().ToTable("TB_TIPO_USUARIOS");
            modelBuilder.Entity<Logs>().ToTable("TB_LOGS");

        }
        #endregion Configurações 

        #endregion Entidades/Tabelas 
    }
}
