using SRCONFI.Projeto.Domain.UnitOfWork;
using SRCONFI.Projeto.Domain.Entity;
using System.Collections.Generic;
using System.Linq;

namespace SRCONFI.Projeto.Business
{
    public class EntradasLivrosBusiness
    {
        public List<EntradasLivros> ListEntradasLivros()
        {
            List<EntradasLivros> listEntradasLivros = new List<EntradasLivros>();
            using (var unitOfWork = new UnitOfWork(new Domain.BancoContext()))
            {
                listEntradasLivros = unitOfWork.EntradasLivros.GetAll().ToList();
            }
            return listEntradasLivros;
        }

        public void AddEntradasLivros(EntradasLivros entradaLivro, int idLivro)
        {
            using (var unitOfWork = new UnitOfWork(new Domain.BancoContext()))
            {
                unitOfWork.EntradasLivros.Add(entradaLivro);
                unitOfWork.Estoque.Add(RetornarEstoque(entradaLivro, idLivro));
                unitOfWork.Complete();
                unitOfWork.Dispose();
            }
        }

        public void EditEntradasLivros(EntradasLivros entradaLivro, int idLivro)
        {
            using (var unitOfWork = new UnitOfWork(new Domain.BancoContext()))
            {
                unitOfWork.EntradasLivros.Edit(entradaLivro);
                unitOfWork.Estoque.Edit(AlterarEstoque(entradaLivro, idLivro));
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

        public EntradasLivros GetEntradasLivros(int idEntradasLivros)
        {
            EntradasLivros entradaLivro;
            using (var unitOfWork = new UnitOfWork(new Domain.BancoContext()))
            {
                entradaLivro = unitOfWork.EntradasLivros.Get(idEntradasLivros);
                unitOfWork.Dispose();
            }

            return entradaLivro;
        }

        #region Métodos Privados

        private Estoque RetornarEstoque(EntradasLivros entLivros, int idLivro)
        {
            return new Estoque()
            {
                entradaID_FK = entLivros.entradaID,
                livroID_FK = idLivro,
                nrQuantidade = (int)(entLivros.ValorTotalEntrada / entLivros.unitarioLivro),
                vlUnitarioLivro = entLivros.unitarioLivro
            };
        }

        private Estoque AlterarEstoque(EntradasLivros entLivros, int idLivro)
        {
            var estoque = new Business.EstoqueBusiness().GetEstoqueByEntradaID(entLivros.entradaID);
            estoque.livroID_FK = idLivro;
            estoque.nrQuantidade = (int)(entLivros.ValorTotalEntrada / entLivros.unitarioLivro);
            estoque.vlUnitarioLivro = entLivros.unitarioLivro;
            return estoque;
        }

        #endregion Métodos Privados

    }
}
