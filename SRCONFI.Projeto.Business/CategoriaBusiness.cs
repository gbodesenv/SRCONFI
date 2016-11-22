using SRCONFI.Projeto.Domain.UnitOfWork;
using System.Collections.Generic;
using System.Linq;

namespace SRCONFI.Projeto.Business
{
    public class CategoriaBusiness
    {
        public List<Domain.Entity.Categoria> ListCategoria()
        {
            List<Domain.Entity.Categoria> listCategoria = new List<Domain.Entity.Categoria>();
            using (var unitOfWork = new UnitOfWork(new Domain.BancoContext()))
            {
                listCategoria = unitOfWork.Categoria.GetAll().ToList();
            }
            return listCategoria;
        }

        public void AddCategoria(Domain.Entity.Categoria categoria)
        {
            using (var unitOfWork = new UnitOfWork(new Domain.BancoContext()))
            {
                unitOfWork.Categoria.Add(categoria);
                unitOfWork.Complete();
                unitOfWork.Dispose();
            }
        }
        public void EditCategoria(Domain.Entity.Categoria categoria)
        {
            using (var unitOfWork = new UnitOfWork(new Domain.BancoContext()))
            {
                unitOfWork.Categoria.Edit(categoria);
                unitOfWork.Complete();
                unitOfWork.Dispose();
            }
        }
        public void DeleteCategoria(int id)
        {
            using (var unitOfWork = new UnitOfWork(new Domain.BancoContext()))
            {
                var categoria = unitOfWork.Categoria.Get(id);
                unitOfWork.Categoria.Remove(categoria);
                unitOfWork.Complete();
                unitOfWork.Dispose();
            }
        }
        public Domain.Entity.Categoria GetCategoria(int idCategoria)
        {
            Domain.Entity.Categoria categoria;
            using (var unitOfWork = new UnitOfWork(new Domain.BancoContext()))
            {
                categoria = unitOfWork.Categoria.Get(idCategoria);
                unitOfWork.Dispose();
            }

            return categoria;
        }

    }
}
