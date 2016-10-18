using SRCONFI.Projeto.Domain.Entity;

namespace SRCONFI.Projeto.Domain.Repositories.Interfaces
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
       bool ValidLoginUsuario(string login, string senha);
    }
}
