using SRCONFI.Projeto.Domain.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRCONFI.Projeto.Domain.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        ICategoriaRepository Categoria { get; }
        ILogRepository Log { get; }
        ISociosRepository Socios { get; }
        ITipoUsuarioRepository TipoUsuario { get; }
        IUsuarioRepository Usuario { get; }

        int Complete();
    }
}
