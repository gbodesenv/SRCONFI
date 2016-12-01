using SRCONFI.Projeto.Domain.UnitOfWork;
using System.Collections.Generic;
using System.Linq;

namespace SRCONFI.Projeto.Business
{
    public class LivrosBusiness
    {
        public List<Domain.Entity.Livros> ListLivros()
        {
            List<Domain.Entity.Livros> listLivros = new List<Domain.Entity.Livros>();
            using (var unitOfWork = new UnitOfWork(new Domain.BancoContext()))
            {
                listLivros = unitOfWork.Livros.GetAllAndRelation().ToList();
            }
            return listLivros;
        }

        public void AddLivros(Domain.Entity.Livros livros)
        {
            using (var unitOfWork = new UnitOfWork(new Domain.BancoContext()))
            {
                unitOfWork.Livros.Add(livros);
                unitOfWork.Complete();
                unitOfWork.Dispose();
            }
        }
        public void EditLivros(Domain.Entity.Livros livros)
        {
            using (var unitOfWork = new UnitOfWork(new Domain.BancoContext()))
            {
                unitOfWork.Livros.Edit(livros);
                unitOfWork.Complete();
                unitOfWork.Dispose();
            }
        }
        public void DeleteLivros(int id)
        {
            using (var unitOfWork = new UnitOfWork(new Domain.BancoContext()))
            {
                var livros = unitOfWork.Livros.Get(id);
                unitOfWork.Livros.Remove(livros);
                unitOfWork.Complete();
                unitOfWork.Dispose();
            }
        }
        public Domain.Entity.Livros GetLivros(int idLivros)
        {
            Domain.Entity.Livros livros;
            using (var unitOfWork = new UnitOfWork(new Domain.BancoContext()))
            {
                livros = unitOfWork.Livros.Get(idLivros);
                unitOfWork.Dispose();
            }

            return livros;
        }

        public Domain.Entity.Livros GetAndRelation(int idLivro)
        {
            Domain.Entity.Livros livro;
            using (var unitOfWork = new UnitOfWork(new Domain.BancoContext()))
            {
                livro = unitOfWork.Livros.GetAndRelation(idLivro);
                unitOfWork.Dispose();
            }

            return livro;
        }

        public Domain.Entity.Livros GetLivroByEntradaID(int idEntrada)
        {
            Domain.Entity.Livros livro;
            using (var unitOfWork = new UnitOfWork(new Domain.BancoContext()))
            {
                livro = unitOfWork.Livros.GetLivroByEntradaID(idEntrada);
                unitOfWork.Dispose();
            }

            return livro;
        }

        public List<Domain.Entity.Livros> GetAllLivroExistInEstoque()
        {
            List<Domain.Entity.Livros> livros;
            using (var unitOfWork = new UnitOfWork(new Domain.BancoContext()))
            {
                livros = unitOfWork.Livros.GetAllLivroExistInEstoque();
                unitOfWork.Dispose();
            }

            return livros;
        }

    }
}
