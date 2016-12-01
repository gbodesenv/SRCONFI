using SRCONFI.Projeto.Domain.UnitOfWork;
using System.Collections.Generic;
using System.Linq;

namespace SRCONFI.Projeto.Business
{
    public class LocalAtividadeBusiness
    {
        public List<Domain.Entity.LocalAtividade> ListLocalAtividade()
        {
            List<Domain.Entity.LocalAtividade> listLocalAtividade = new List<Domain.Entity.LocalAtividade>();
            using (var unitOfWork = new UnitOfWork(new Domain.BancoContext()))
            {
                listLocalAtividade = unitOfWork.LocalAtividade.GetAll().ToList();
            }
            return listLocalAtividade;
        }

        public void AddLocalAtividade(Domain.Entity.LocalAtividade localatividade)
        {
            using (var unitOfWork = new UnitOfWork(new Domain.BancoContext()))
            {
                unitOfWork.LocalAtividade.Add(localatividade);
                unitOfWork.Complete();
                unitOfWork.Dispose();
            }
        }
        public void EditLocalAtividade(Domain.Entity.LocalAtividade localatividade)
        {
            using (var unitOfWork = new UnitOfWork(new Domain.BancoContext()))
            {
                unitOfWork.LocalAtividade.Edit(localatividade);
                unitOfWork.Complete();
                unitOfWork.Dispose();
            }
        }
        public void DeleteLocalAtividade(int id)
        {
            using (var unitOfWork = new UnitOfWork(new Domain.BancoContext()))
            {
                var localatividade = unitOfWork.LocalAtividade.Get(id);
                unitOfWork.LocalAtividade.Remove(localatividade);
                unitOfWork.Complete();
                unitOfWork.Dispose();
            }
        }
        public Domain.Entity.LocalAtividade GetLocalAtividade(int idLocalAtividade)
        {
            Domain.Entity.LocalAtividade localatividade;
            using (var unitOfWork = new UnitOfWork(new Domain.BancoContext()))
            {
                localatividade = unitOfWork.LocalAtividade.Get(idLocalAtividade);
                unitOfWork.Dispose();
            }

            return localatividade;
        }

    }
}
