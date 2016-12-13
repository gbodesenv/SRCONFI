using SRCONFI.Projeto.Domain.UnitOfWork;
using System.Collections.Generic;
using System.Linq;

namespace SRCONFI.Projeto.Business
{
    public class DoacoesBusiness
    {
        public List<Domain.Entity.Doacoes> ListDoacoes()
        {
            List<Domain.Entity.Doacoes> listDoacoes = new List<Domain.Entity.Doacoes>();
            using (var unitOfWork = new UnitOfWork(new Domain.BancoContext()))
            {
                listDoacoes = unitOfWork.Doacoes.GetAll().ToList();
            }
            return listDoacoes;
        }

        public void AddDoacoes(Domain.Entity.Doacoes doacoes)
        {
            using (var unitOfWork = new UnitOfWork(new Domain.BancoContext()))
            {
                unitOfWork.Doacoes.Add(doacoes);
                unitOfWork.Complete();
                unitOfWork.Dispose();
            }
        }
        public void EditDoacoes(Domain.Entity.Doacoes doacoes)
        {
            using (var unitOfWork = new UnitOfWork(new Domain.BancoContext()))
            {
                unitOfWork.Doacoes.Edit(doacoes);
                unitOfWork.Complete();
                unitOfWork.Dispose();
            }
        }
        public void DeleteDoacoes(int id)
        {
            using (var unitOfWork = new UnitOfWork(new Domain.BancoContext()))
            {
                var doacoes = unitOfWork.Doacoes.Get(id);
                unitOfWork.Doacoes.Remove(doacoes);
                unitOfWork.Complete();
                unitOfWork.Dispose();
            }
        }
        public Domain.Entity.Doacoes GetDoacoes(int idDoacoes)
        {
            Domain.Entity.Doacoes doacoes;
            using (var unitOfWork = new UnitOfWork(new Domain.BancoContext()))
            {
                doacoes = unitOfWork.Doacoes.Get(idDoacoes);
                unitOfWork.Dispose();
            }

            return doacoes;
        }

    }
}
