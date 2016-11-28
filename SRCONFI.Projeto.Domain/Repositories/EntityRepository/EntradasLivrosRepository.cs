using SRCONFI.Projeto.Domain.Entity;
using SRCONFI.Projeto.Domain.Repositories.EntityRepository;
using SRCONFI.Projeto.Domain.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRCONFI.Projeto.Domain.Repositories.EntityRepository
{
    public class EntradasLivrosRepository : Repository<EntradasLivros>, IEntradasLivrosRepository
    {
        public EntradasLivrosRepository(BancoContext context)
            : base(context)
        {
        }
        
        public BancoContext BancoContext
        {
            get { return Context as BancoContext; }
        }
    }
}
