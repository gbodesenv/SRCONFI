using SRCONFI.Projeto.Domain.Entity;
using SRCONFI.Projeto.Domain.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace SRCONFI.Projeto.Domain.Repositories
{
    public class SociosRepository : Repository<Socios>, ISociosRepository
    {
        public SociosRepository(BancoContext context)
            : base(context)
        {
        }

        public IEnumerable<Socios> GetAllAndRelation()
        {
            return BancoContext.Socios
                .Include("Categoria");
            
        }
        
        public BancoContext BancoContext
        {
            get { return Context as BancoContext; }
        }

    }
}
