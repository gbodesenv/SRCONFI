using SRCONFI.Projeto.Domain.Entity;
using SRCONFI.Projeto.Domain.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace SRCONFI.Projeto.Domain.Repositories
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(BancoContext context) 
            : base(context)
        {
        }

        public bool ValidLoginUsuario(string login, string senha)
        {
            return BancoContext.Usuario.Where(u=> u.login.Equals(login) && u.senha.Equals(senha)).Any();
        }


        public BancoContext BancoContext
        {
            get { return Context as BancoContext; }
        }
  
    }
}
