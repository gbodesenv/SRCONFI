using SRCONFI.Projeto.Domain.UnitOfWork;
using System.Collections.Generic;
using System.Linq;

namespace SRCONFI.Projeto.Business
{
    public class PagamentosBusiness
    {
        public List<Domain.Entity.Pagamentos> ListPagamentos()
        {
            List<Domain.Entity.Pagamentos> listPagamentos = new List<Domain.Entity.Pagamentos>();
            using (var unitOfWork = new UnitOfWork(new Domain.BancoContext()))
            {
                listPagamentos = unitOfWork.Pagamentos.GetAllAndRelation().ToList();
            }
            return listPagamentos;
        }

        public void AddPagamentos(Domain.Entity.Pagamentos pagamentos)
        {
            using (var unitOfWork = new UnitOfWork(new Domain.BancoContext()))
            {
                unitOfWork.Pagamentos.Add(pagamentos);
                unitOfWork.Complete();
                unitOfWork.Dispose();
            }
        }
        public void EditPagamentos(Domain.Entity.Pagamentos pagamentos)
        {
            using (var unitOfWork = new UnitOfWork(new Domain.BancoContext()))
            {
                unitOfWork.Pagamentos.Edit(pagamentos);
                unitOfWork.Complete();
                unitOfWork.Dispose();
            }
        }
        public void DeletePagamentos(int id)
        {
            using (var unitOfWork = new UnitOfWork(new Domain.BancoContext()))
            {
                var pagamentos = unitOfWork.Pagamentos.Get(id);
                unitOfWork.Pagamentos.Remove(pagamentos);
                unitOfWork.Complete();
                unitOfWork.Dispose();
            }
        }
        public Domain.Entity.Pagamentos GetPagamentos(int idPagamentos)
        {
            Domain.Entity.Pagamentos pagamentos;
            using (var unitOfWork = new UnitOfWork(new Domain.BancoContext()))
            {
                pagamentos = unitOfWork.Pagamentos.Get(idPagamentos);
                unitOfWork.Dispose();
            }

            return pagamentos;
        }

        public Domain.Entity.Pagamentos GetAndRelation(int idLivro)
        {
            Domain.Entity.Pagamentos pagamento;
            using (var unitOfWork = new UnitOfWork(new Domain.BancoContext()))
            {
                pagamento = unitOfWork.Pagamentos.GetAndRelation(idLivro);
                unitOfWork.Dispose();
            }

            return pagamento;
        }

      

    }
}
