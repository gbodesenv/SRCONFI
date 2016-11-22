using SRCONFI.Projeto.Domain.Entity;
using SRCONFI.Projeto.Domain.Repositories.Interfaces;


namespace SRCONFI.Projeto.Domain.Repositories.EntityRepository
{
    public class CategoriaRepository : Repository<Categoria>, ICategoriaRepository
    {
        public CategoriaRepository(BancoContext context)
            : base(context)
        {
        }

        public BancoContext BancoContext
        {
            get { return Context as BancoContext; }
        }

    }
}
