using SRCONFI.Projeto.Domain.UnitOfWork;
using System.Collections.Generic;
using System.Linq;

namespace SRCONFI.Projeto.Business
{
    public class UsuarioBusiness
    {
        #region CRUD
        public List<Domain.Entity.Usuario> ListUsuarios()
        {
            List<Domain.Entity.Usuario> lstUsuarios = new List<Domain.Entity.Usuario>();
            using (var unitOfWork = new UnitOfWork(new Domain.BancoContext()))
            {
                lstUsuarios = unitOfWork.Usuario.GetAllAndRelation().ToList();
                unitOfWork.Dispose();
            }
            return lstUsuarios;
        }
        public void AddUsuario(Domain.Entity.Usuario usu)
        {
            using (var unitOfWork = new UnitOfWork(new Domain.BancoContext()))
            {
                unitOfWork.Usuario.Add(usu);
                unitOfWork.Complete();
                unitOfWork.Dispose();
            }
        }
        public void EditUsuario(Domain.Entity.Usuario usu)
        {
            using (var unitOfWork = new UnitOfWork(new Domain.BancoContext()))
            {
                unitOfWork.Usuario.Edit(usu);
                unitOfWork.Complete();
                unitOfWork.Dispose();
            }
        }
        public void DeleteUsuario(int id)
        {
            using (var unitOfWork = new UnitOfWork(new Domain.BancoContext()))
            {
                var usu = unitOfWork.Usuario.Get(id);
                unitOfWork.Usuario.Remove(usu);
                unitOfWork.Complete();
                unitOfWork.Dispose();
            }
        }
        public Domain.Entity.Usuario GetUsuario(int idUsu)
        {
            Domain.Entity.Usuario usuario;
            using (var unitOfWork = new UnitOfWork(new Domain.BancoContext()))
            {
                usuario = unitOfWork.Usuario.Get(idUsu);
                unitOfWork.Dispose();
            }

            return usuario;
        }
        #endregion CRUD

        #region RN

        private void RN_LoginExistente(UnitOfWork unitOfWork, string login)
        {
            if(unitOfWork.Usuario.GetAll().Any(u=>u.login.Equals(login)))
                throw new System.ArgumentException("Usuário com mesmo login no sistema!", "loginJaExistente");
        }

        #endregion RN

    }
}
