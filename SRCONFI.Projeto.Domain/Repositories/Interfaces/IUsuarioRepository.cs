using SRCONFI.Projeto.Domain.Entity;
using System.Collections.Generic;

namespace SRCONFI.Projeto.Domain.Repositories.Interfaces
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        bool ValidLoginUsuario(string login, string senha);
        IEnumerable<Usuario> GetAllAndRelation();
    }
}
