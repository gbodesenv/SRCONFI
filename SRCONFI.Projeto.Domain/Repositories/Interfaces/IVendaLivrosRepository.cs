using SRCONFI.Projeto.Domain.Entity;
using System.Collections.Generic;

namespace SRCONFI.Projeto.Domain.Repositories.Interfaces
{
    public interface IVendaLivrosRepository : IRepository<VendasLivros>
    {
        IEnumerable<VendasLivros> GetAllAndRelationComplete();
    }
}
