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

        public void AddTipoUsuario(Domain.Entity.TipoUsuario usu)
        {
            using (var unitOfWork = new UnitOfWork(new Domain.BancoContext()))
            {
                unitOfWork.TipoUsuario.Add(usu);
                unitOfWork.Complete();
                unitOfWork.Dispose();
            }
        }
        public void EditTipoUsuario(Domain.Entity.TipoUsuario usu)
        {
            using (var unitOfWork = new UnitOfWork(new Domain.BancoContext()))
            {
                unitOfWork.TipoUsuario.Edit(usu);
                unitOfWork.Complete();
                unitOfWork.Dispose();
            }
        }
        public void DeleteTipoUsuario(int id)
        {
            using (var unitOfWork = new UnitOfWork(new Domain.BancoContext()))
            {
                var usu = unitOfWork.TipoUsuario.Get(id);
                unitOfWork.TipoUsuario.Remove(usu);
                unitOfWork.Complete();
                unitOfWork.Dispose();
            }
        }
        public Domain.Entity.TipoUsuario GetTipoUsuario(int idUsu)
        {
            Domain.Entity.TipoUsuario tpUsuario;
            using (var unitOfWork = new UnitOfWork(new Domain.BancoContext()))
            {
                tpUsuario = unitOfWork.TipoUsuario.Get(idUsu);
                unitOfWork.Dispose();
            }

            return tpUsuario;
        }

    }
}
