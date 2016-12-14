using SRCONFI.Projeto.Domain.Entity;
using SRCONFI.Projeto.Domain.Repositories.Interfaces;


namespace SRCONFI.Projeto.Domain.Repositories.EntityRepository
{
    public class DoacoesRepository : Repository<Doacoes>, IDoacoesRepository
    {
        public DoacoesRepository(BancoContext context)
            : base(context)
        {
        }

        public BancoContext BancoContext
        {
            get { return Context as BancoContext; }
        }

    }
}
