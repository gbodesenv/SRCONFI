using SRCONFI.Projeto.Domain.Entity;
using System.Data.Entity;

namespace SRCONFI.Projeto.Domain
{
    public class BancoContext : DbContext
    {
        public BancoContext()
            : base("name=DBSRCONFI")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Usuario> Usuario { get; set; }


    }
}
