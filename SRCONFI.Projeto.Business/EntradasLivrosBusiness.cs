using SRCONFI.Projeto.Domain.UnitOfWork;
using System.Collections.Generic;
using System.Linq;

namespace SRCONFI.Projeto.Business
{
    public class EntradasLivrosBusiness
    {
        public List<Domain.Entity.EntradasLivros> ListEntradasLivros()
        {
            List<Domain.Entity.EntradasLivros> listEntradasLivros = new List<Domain.Entity.EntradasLivros>();
            using (var unitOfWork = new UnitOfWork(new Domain.BancoContext()))
            {
                listEntradasLivros = unitOfWork.EntradasLivros.GetAll().ToList();
            }
            return listEntradasLivros;
        }

        public void AddEntradasLivros(Domain.Entity.EntradasLivros entradaLivro)
        {
            using (var unitOfWork = new UnitOfWork(new Domain.BancoContext()))
            {
                unitOfWork.EntradasLivros.Add(entradaLivro);
                unitOfWork.Complete();
                unitOfWork.Dispose();
            }
        }
        public void EditEntradasLivros(Domain.Entity.EntradasLivros entradaLivro)
        {
            using (var unitOfWork = new UnitOfWork(new Domain.BancoContext()))
            {
                unitOfWork.EntradasLivros.Edit(entradaLivro);
                unitOfWork.Complete();
                unitOfWork.Dispose();
            }
        }
        public void DeleteEntradasLivros(int id)
        {
            using (var unitOfWork = new UnitOfWork(new Domain.BancoContext()))
            {
                var entradaLivro = unitOfWork.EntradasLivros.Get(id);
                unitOfWork.EntradasLivros.Remove(entradaLivro);
                unitOfWork.Complete();
                unitOfWork.Dispose();
            }
        }
        public Domain.Entity.EntradasLivros GetEntradasLivros(int idEntradasLivros)
        {
            Domain.Entity.EntradasLivros entradaLivro;
            using (var unitOfWork = new UnitOfWork(new Domain.BancoContext()))
            {
                entradaLivro = unitOfWork.EntradasLivros.Get(idEntradasLivros);
                unitOfWork.Dispose();
            }

            return entradaLivro;
        }

    }
}
