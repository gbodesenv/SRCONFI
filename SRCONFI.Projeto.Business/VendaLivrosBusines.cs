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

        public void AddVendaLivros(VendasLivros VendaLivros, int idLivro)
        {
            using (var unitOfWork = new UnitOfWork(new Domain.BancoContext()))
            {
                unitOfWork.VendaLivros.Add(VendaLivros);
                //unitOfWork.Estoque.Add(RetornarEstoque(VendaLivros, idLivro));
                unitOfWork.Complete();
                unitOfWork.Dispose();
            }
        }

        public void EditVendaLivros(VendasLivros VendaLivros, int idLivro)
        {
            using (var unitOfWork = new UnitOfWork(new Domain.BancoContext()))
            {
                unitOfWork.VendaLivros.Edit(VendaLivros);
                //unitOfWork.Estoque.Edit(AlterarEstoque(VendaLivros, idLivro));
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

        //private Estoque AlterarEstoque(VendasLivros entLivros, int idLivro)
        //{
        //    var estoque = new Business.EstoqueBusiness().GetEstoqueByEntradaID(entLivros.entradaID);
        //    estoque.livroID_FK = idLivro;
        //    estoque.nrQuantidade = (int)(entLivros.ValorTotalEntrada / entLivros.unitarioLivro);
        //    estoque.vlUnitarioLivro = entLivros.unitarioLivro;
        //    return estoque;
        //}

        #endregion Métodos Privados

    }
}
