using SRCONFI.Projeto.Domain.Entity;
using SRCONFI.Projeto.Domain.Repositories.Interfaces;


namespace SRCONFI.Projeto.Domain.Repositories.EntityRepository
{
    class TipoUsuarioRepository : Repository<TipoUsuario>, ITipoUsuarioRepository
    {
        public TipoUsuarioRepository(BancoContext context) 
            : base(context)
        {
        }

        public BancoContext BancoContext
        {
            get { return Context as BancoContext; }
        }

    }
}
