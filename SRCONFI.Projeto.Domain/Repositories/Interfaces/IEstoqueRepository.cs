using SRCONFI.Projeto.Domain.Entity;
using System.Collections.Generic;

namespace SRCONFI.Projeto.Domain.Repositories.Interfaces
{
    public interface IEstoqueRepository : IRepository<Estoque>
    {
        IEnumerable<Estoque> GetAllAndRelation();
        Estoque GetAndRelation(int id);
    }
}
