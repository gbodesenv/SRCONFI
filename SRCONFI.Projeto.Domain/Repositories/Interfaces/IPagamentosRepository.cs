using SRCONFI.Projeto.Domain.Entity;
using System.Collections.Generic;

namespace SRCONFI.Projeto.Domain.Repositories.Interfaces
{
    public interface IPagamentosRepository : IRepository<Pagamentos>
    {
        IEnumerable<Pagamentos> GetAllAndRelation();
        Pagamentos GetAndRelation(int id);
    }
}
