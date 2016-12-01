using SRCONFI.Projeto.Domain.UnitOfWork;
using System.Collections.Generic;
using System.Linq;

namespace SRCONFI.Projeto.Business
{
    public class AtividadesBusiness
    {
        public List<Domain.Entity.Atividades> ListAtividades()
        {
            List<Domain.Entity.Atividades> listAtividades = new List<Domain.Entity.Atividades>();
            using (var unitOfWork = new UnitOfWork(new Domain.BancoContext()))
            {
                listAtividades = unitOfWork.Atividade.GetAll().ToList();
            }
            return listAtividades;
        }

        public void AddAtividades(Domain.Entity.Atividades atividades)
        {
            using (var unitOfWork = new UnitOfWork(new Domain.BancoContext()))
            {
                unitOfWork.Atividade.Add(atividades);
                unitOfWork.Complete();
                unitOfWork.Dispose();
            }
        }
        public void EditAtividades(Domain.Entity.Atividades atividades)
        {
            using (var unitOfWork = new UnitOfWork(new Domain.BancoContext()))
            {
                unitOfWork.Atividade.Edit(atividades);
                unitOfWork.Complete();
                unitOfWork.Dispose();
            }
        }
        public void DeleteAtividades(int id)
        {
            using (var unitOfWork = new UnitOfWork(new Domain.BancoContext()))
            {
                var atividades = unitOfWork.Atividade.Get(id);
                unitOfWork.Atividade.Remove(atividades);
                unitOfWork.Complete();
                unitOfWork.Dispose();
            }
        }
        public Domain.Entity.Atividades GetAtividades(int idAtividades)
        {
            Domain.Entity.Atividades atividades;
            using (var unitOfWork = new UnitOfWork(new Domain.BancoContext()))
            {
                atividades = unitOfWork.Atividade.Get(idAtividades);
                unitOfWork.Dispose();
            }

            return atividades;
        }

    }
}
