using SRCONFI.Projeto.Domain.Entity;
using System.Collections.Generic;

namespace SRCONFI.Projeto.Domain.Repositories.Interfaces
{
    public interface ISociosRepository : IRepository<Socios>
    {
        IEnumerable<Socios> GetAllAndRelation();
        Socios GetAndRelation(int id);
    }
}
