using SRCONFI.Projeto.Domain.UnitOfWork;
using System.Collections.Generic;
using System.Linq;

namespace SRCONFI.Projeto.Business
{
    public class EstoqueBusiness
    {
        public List<Domain.Entity.Estoque> ListEstoque()
        {
            List<Domain.Entity.Estoque> listEstoque = new List<Domain.Entity.Estoque>();
            using (var unitOfWork = new UnitOfWork(new Domain.BancoContext()))
            {
                listEstoque = unitOfWork.Estoque.GetAllAndRelation().ToList();
            }
            return listEstoque;
        }

        public void AddEstoque(Domain.Entity.Estoque estoque)
        {
            using (var unitOfWork = new UnitOfWork(new Domain.BancoContext()))
            {
                unitOfWork.Estoque.Add(estoque);
                unitOfWork.Complete();
                unitOfWork.Dispose();
            }
        }
        public void EditEstoque(Domain.Entity.Estoque estoque)
        {
            using (var unitOfWork = new UnitOfWork(new Domain.BancoContext()))
            {
                unitOfWork.Estoque.Edit(estoque);
                unitOfWork.Complete();
                unitOfWork.Dispose();
            }
        }
        public void DeleteEstoque(int id)
        {
            using (var unitOfWork = new UnitOfWork(new Domain.BancoContext()))
            {
                var estoque = unitOfWork.Estoque.Get(id);
                unitOfWork.Estoque.Remove(estoque);
                unitOfWork.Complete();
                unitOfWork.Dispose();
            }
        }
        public Domain.Entity.Estoque GetEstoque(int idEstoque)
        {
            Domain.Entity.Estoque estoque;
            using (var unitOfWork = new UnitOfWork(new Domain.BancoContext()))
            {
                estoque = unitOfWork.Estoque.Get(idEstoque);
                unitOfWork.Dispose();
            }

            return estoque;
        }

        public Domain.Entity.Estoque GetAndRelation(int idLivro)
        {
            Domain.Entity.Estoque livro;
            using (var unitOfWork = new UnitOfWork(new Domain.BancoContext()))
            {
                livro = unitOfWork.Estoque.GetAndRelation(idLivro);
                unitOfWork.Dispose();
            }

            return livro;
        }

    }
}
