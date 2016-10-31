using SRCONFI.Projeto.Domain.UnitOfWork;
using System.Collections.Generic;
using System.Linq;

namespace SRCONFI.Projeto.Business
{
    public class UsuarioBusiness
    {
        public List<Domain.Entity.Usuario> ListUsuarios()
        {
            List<Domain.Entity.Usuario> lstUsuarios = new List<Domain.Entity.Usuario>();
            using (var unitOfWork = new UnitOfWork(new Domain.BancoContext()))
            {
                lstUsuarios = unitOfWork.Usuario.GetAllAndRelation().ToList();
            }
            return lstUsuarios;
        }


    }
}
