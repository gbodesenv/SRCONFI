using SRCONFI.Projeto.Domain.UnitOfWork;
using System.Collections.Generic;
using System.Linq;

namespace SRCONFI.Projeto.Business
{
    public class PeriodoAtividadeBusiness
    {
        public List<Domain.Entity.PeriodoAtividade> ListPeriodoAtividade()
        {
            List<Domain.Entity.PeriodoAtividade> listPeriodoAtividade = new List<Domain.Entity.PeriodoAtividade>();
            using (var unitOfWork = new UnitOfWork(new Domain.BancoContext()))
            {
                listPeriodoAtividade = unitOfWork.PeriodoAtividade.GetAll().ToList();
            }
            return listPeriodoAtividade;
        }

        public void AddPeriodoAtividade(Domain.Entity.PeriodoAtividade periodoatividade)
        {
            using (var unitOfWork = new UnitOfWork(new Domain.BancoContext()))
            {
                unitOfWork.PeriodoAtividade.Add(periodoatividade);
                unitOfWork.Complete();
                unitOfWork.Dispose();
            }
        }
        public void EditPeriodoAtividade(Domain.Entity.PeriodoAtividade periodoatividade)
        {
            using (var unitOfWork = new UnitOfWork(new Domain.BancoContext()))
            {
                unitOfWork.PeriodoAtividade.Edit(periodoatividade);
                unitOfWork.Complete();
                unitOfWork.Dispose();   
            }
        }
        public void DeletePeriodoAtividade(int id)
        {
            using (var unitOfWork = new UnitOfWork(new Domain.BancoContext()))
            {
                var periodoatividade = unitOfWork.PeriodoAtividade.Get(id);
                unitOfWork.PeriodoAtividade.Remove(periodoatividade);
                unitOfWork.Complete();
                unitOfWork.Dispose();
            }
        }
        public Domain.Entity.PeriodoAtividade GetPeriodoAtividade(int idPeriodoAtividade)
        {
            Domain.Entity.PeriodoAtividade periodoatividade;
            using (var unitOfWork = new UnitOfWork(new Domain.BancoContext()))
            {
                periodoatividade = unitOfWork.PeriodoAtividade.Get(idPeriodoAtividade);
                unitOfWork.Dispose();
            }

            return periodoatividade;
        }

    }
}
