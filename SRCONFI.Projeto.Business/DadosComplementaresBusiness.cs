using SRCONFI.Projeto.Domain.UnitOfWork;
using System.Collections.Generic;
using System.Linq;

namespace SRCONFI.Projeto.Business
{
    public class DadosComplementaresBusiness
    {
        public List<Domain.Entity.DadosComplementares> ListDadosComplementares()
        {
            List<Domain.Entity.DadosComplementares> listDadosComplementares = new List<Domain.Entity.DadosComplementares>();
            using (var unitOfWork = new UnitOfWork(new Domain.BancoContext()))
            {
                listDadosComplementares = unitOfWork.DadosComplementares.GetAll().ToList();
            }
            return listDadosComplementares;
        }

        public void AddDadosComplementares(Domain.Entity.DadosComplementares dadosComplementares)
        {
            using (var unitOfWork = new UnitOfWork(new Domain.BancoContext()))
            {
                unitOfWork.DadosComplementares.Add(dadosComplementares);
                unitOfWork.Complete();
                unitOfWork.Dispose();
            }
        }
        public void EditDadosComplementares(Domain.Entity.DadosComplementares dadosComplementares)
        {
            using (var unitOfWork = new UnitOfWork(new Domain.BancoContext()))
            {
                unitOfWork.DadosComplementares.Edit(dadosComplementares);
                unitOfWork.Complete();
                unitOfWork.Dispose();
            }
        }
        public void DeleteDadosComplementares(int id)
        {
            using (var unitOfWork = new UnitOfWork(new Domain.BancoContext()))
            {
                var dadosComplementares = unitOfWork.DadosComplementares.Get(id);
                unitOfWork.DadosComplementares.Remove(dadosComplementares);
                unitOfWork.Complete();
                unitOfWork.Dispose();
            }
        }
        public Domain.Entity.DadosComplementares GetDadosComplementares(int idDadosComplementares)
        {
            Domain.Entity.DadosComplementares dadosComplementares;
            using (var unitOfWork = new UnitOfWork(new Domain.BancoContext()))
            {
                dadosComplementares = unitOfWork.DadosComplementares.Get(idDadosComplementares);
                unitOfWork.Dispose();
            }

            return dadosComplementares;
        }

    }
}
