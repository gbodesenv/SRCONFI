using SRCONFI.Projeto.Domain.Entity;
using SRCONFI.Projeto.Domain.Repositories.Interfaces;


namespace SRCONFI.Projeto.Domain.Repositories.EntityRepository
{
    public class EstadoRepository : Repository<Estado>, IEstadoRepository
    {
        public EstadoRepository(BancoContext context)
            : base(context)
        {
        }

        public BancoContext BancoContext
        {
            get { return Context as BancoContext; }
        }

    }
}
