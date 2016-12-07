using SRCONFI.Projeto.Domain.Entity;
using SRCONFI.Projeto.Domain.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace SRCONFI.Projeto.Domain.Repositories.EntityRepository
{
    public class VendaLivrosRepository : Repository<VendasLivros>, IVendaLivrosRepository
    {
        public VendaLivrosRepository(BancoContext context)
            : base(context)
        {
        }

        public IEnumerable<VendasLivros> GetAllAndRelationComplete()
        {
            return BancoContext.VendasLivros.Include("Estoque")
                                   .Include("Estoque.Livros")
                                   .Include("Estoque.Livros.Autores")
                                   .Include("Estoque.Livros.Editoras");                                  
        }

        public BancoContext BancoContext
        {
            get { return Context as BancoContext; }
        }
    }
}
