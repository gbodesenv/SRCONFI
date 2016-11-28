using SRCONFI.Projeto.Domain.Entity;
using System.Collections.Generic;

namespace SRCONFI.Projeto.Domain.Repositories.Interfaces
{
    public interface ILivrosRepository : IRepository<Livros>
    {
        IEnumerable<Livros> GetAllAndRelation();
        Livros GetAndRelation(int id);
        Livros GetLivroByEntradaID(int idEntrada);
    }
}
