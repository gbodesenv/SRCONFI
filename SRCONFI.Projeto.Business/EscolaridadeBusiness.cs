using SRCONFI.Projeto.Domain.UnitOfWork;
using System.Collections.Generic;
using System.Linq;

namespace SRCONFI.Projeto.Business
{
    public class EscolaridadeBusiness
    {
        public List<Domain.Entity.Escolaridade> ListEscolaridade()
        {
            List<Domain.Entity.Escolaridade> listEscolaridade = new List<Domain.Entity.Escolaridade>();
            using (var unitOfWork = new UnitOfWork(new Domain.BancoContext()))
            {
                listEscolaridade = unitOfWork.Escolaridade.GetAll().ToList();
            }
            return listEscolaridade;
        }

        public void AddEscolaridade(Domain.Entity.Escolaridade escolaridade)
        {
            using (var unitOfWork = new UnitOfWork(new Domain.BancoContext()))
            {
                unitOfWork.Escolaridade.Add(escolaridade);
                unitOfWork.Complete();
                unitOfWork.Dispose();
            }
        }
        public void EditEscolaridade(Domain.Entity.Escolaridade escolaridade)
        {
            using (var unitOfWork = new UnitOfWork(new Domain.BancoContext()))
            {
                unitOfWork.Escolaridade.Edit(escolaridade);
                unitOfWork.Complete();
                unitOfWork.Dispose();
            }
        }
        public void DeleteEscolaridade(int id)
        {
            using (var unitOfWork = new UnitOfWork(new Domain.BancoContext()))
            {
                var escolaridade = unitOfWork.Escolaridade.Get(id);
                unitOfWork.Escolaridade.Remove(escolaridade);
                unitOfWork.Complete();
                unitOfWork.Dispose();
            }
        }
        public Domain.Entity.Escolaridade GetEscolaridade(int idEscolaridade)
        {
            Domain.Entity.Escolaridade escolaridade;
            using (var unitOfWork = new UnitOfWork(new Domain.BancoContext()))
            {
                escolaridade = unitOfWork.Escolaridade.Get(idEscolaridade);
                unitOfWork.Dispose();
            }

            return escolaridade;
        }

    }
}
