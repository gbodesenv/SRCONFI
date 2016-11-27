using SRCONFI.Projeto.Domain.UnitOfWork;
using System.Collections.Generic;
using System.Linq;

namespace SRCONFI.Projeto.Business
{
    public class AutoresBusiness
    {
        public List<Domain.Entity.Autores> ListAutores()
        {
            List<Domain.Entity.Autores> listAutores = new List<Domain.Entity.Autores>();
            using (var unitOfWork = new UnitOfWork(new Domain.BancoContext()))
            {
                listAutores = unitOfWork.Autores.GetAll().ToList();
            }
            return listAutores;
        }

        public void AddAutores(Domain.Entity.Autores autores)
        {
            using (var unitOfWork = new UnitOfWork(new Domain.BancoContext()))
            {
                unitOfWork.Autores.Add(autores);
                unitOfWork.Complete();
                unitOfWork.Dispose();
            }
        }
        public void EditAutores(Domain.Entity.Autores autores)
        {
            using (var unitOfWork = new UnitOfWork(new Domain.BancoContext()))
            {
                unitOfWork.Autores.Edit(autores);
                unitOfWork.Complete();
                unitOfWork.Dispose();
            }
        }
        public void DeleteAutores(int id)
        {
            using (var unitOfWork = new UnitOfWork(new Domain.BancoContext()))
            {
                var autores = unitOfWork.Autores.Get(id);
                unitOfWork.Autores.Remove(autores);
                unitOfWork.Complete();
                unitOfWork.Dispose();
            }
        }
        public Domain.Entity.Autores GetAutores(int idAutores)
        {
            Domain.Entity.Autores autores;
            using (var unitOfWork = new UnitOfWork(new Domain.BancoContext()))
            {
                autores = unitOfWork.Autores.Get(idAutores);
                unitOfWork.Dispose();
            }

            return autores;
        }

    }
}
