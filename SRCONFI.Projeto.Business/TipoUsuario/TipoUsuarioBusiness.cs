using SRCONFI.Projeto.Domain.UnitOfWork;
using System.Collections.Generic;
using System.Linq;

namespace SRCONFI.Projeto.Business
{
    public class TipoUsuarioBusiness
    {
        public List<Domain.Entity.TipoUsuario> ListTipoUsuario()
        {
            List<Domain.Entity.TipoUsuario> listTipoUsuario = new List<Domain.Entity.TipoUsuario>();
            using (var unitOfWork = new UnitOfWork(new Domain.BancoContext()))
            {
                listTipoUsuario = unitOfWork.TipoUsuario.GetAll().ToList();
            }
            return listTipoUsuario;
        }


    }
}
