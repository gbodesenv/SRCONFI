using SRCONFI.Projeto.Domain.UnitOfWork;
using SRCONFI.Projeto.Domain.Entity;
using System.Collections.Generic;
using System.Linq;

namespace SRCONFI.Projeto.Business
{
    public class VendaLivrosBusiness
    {
        public List<VendasLivros> ListVendaLivros()
        {
            List<VendasLivros> listVendaLivros = new List<VendasLivros>();
            using (var unitOfWork = new UnitOfWork(new Domain.BancoContext()))
            {
                listVendaLivros = unitOfWork.VendaLivros.GetAll().ToList();
            }
            return listVendaLivros;
        }

        public List<VendasLivros> ListVendaLivrosAndRelationEstoque()
        {
            List<VendasLivros> listVendaLivros = new List<VendasLivros>();
            using (var unitOfWork = new UnitOfWork(new Domain.BancoContext()))
            {
                listVendaLivros = unitOfWork.VendaLivros.GetAllAndRelationComplete().ToList();
            }
            return listVendaLivros;
        }

        public void AddVendaLivros(VendasLivros vendaLivros, int idEstoque, int quantidadeVendida)
        {
            using (var unitOfWork = new UnitOfWork(new Domain.BancoContext()))
            {
                vendaLivros.estoqueID_FK = idEstoque;
                unitOfWork.VendaLivros.Add(vendaLivros);
                unitOfWork.Estoque.Edit(AlterarEstoque(idEstoque, quantidadeVendida));
                unitOfWork.Complete();
                unitOfWork.Dispose();
            }
        }

        public void EditVendaLivros(VendasLivros vendaLivros, int idEstoque, int quantidadeVendida)
        {
            using (var unitOfWork = new UnitOfWork(new Domain.BancoContext()))
            {
                vendaLivros.estoqueID_FK = idEstoque;
                unitOfWork.VendaLivros.Edit(vendaLivros);
                unitOfWork.Estoque.Edit(AlterarEstoque(idEstoque, quantidadeVendida));
                unitOfWork.Complete();
                unitOfWork.Dispose();
            }
        }
        public void DeleteVendaLivros(int id)
        {
            using (var unitOfWork = new UnitOfWork(new Domain.BancoContext()))
            {
                var VendaLivros = unitOfWork.VendaLivros.Get(id);
                unitOfWork.VendaLivros.Remove(VendaLivros);
                unitOfWork.Complete();
                unitOfWork.Dispose();
            }
        }

        public VendasLivros GetVendaLivros(int idVendaLivros)
        {
            VendasLivros VendaLivros;
            using (var unitOfWork = new UnitOfWork(new Domain.BancoContext()))
            {
                VendaLivros = unitOfWork.VendaLivros.Get(idVendaLivros);
                unitOfWork.Dispose();
            }

            return VendaLivros;
        }

        #region Métodos Privados

        //private Estoque RetornarEstoque(VendasLivros entLivros, int idLivro)
        //{
        //    return new Estoque()
        //    {
        //        entradaID_FK = entLivros.entradaID,
        //        livroID_FK = idLivro,
        //        nrQuantidade = (int)(entLivros.ValorTotalEntrada / entLivros.unitarioLivro),
        //        vlUnitarioLivro = entLivros.unitarioLivro
        //    };
        //}

        private Estoque AlterarEstoque( int idEstoque, int quantidadeVendida)
        {
            var estoque = new EstoqueBusiness().GetEstoque(idEstoque);

            RN_ValidarQUantidadeEmEstoque(estoque.nrQuantidade, quantidadeVendida);

            estoque.nrQuantidade = estoque.nrQuantidade - quantidadeVendida;
            return estoque;
        }
        #endregion Métodos Privados

        private void RN_ValidarQUantidadeEmEstoque(int estoque, int vendido)
        {
            if (vendido > estoque)
                throw new System.ArgumentException("A quantidade vendida extrapola a quantidade em estoque!", "limiteEstoque");
        }

        #region Regra de negócio

        #endregion Regra de negócio

    }
}
