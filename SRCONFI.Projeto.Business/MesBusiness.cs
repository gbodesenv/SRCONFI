using SRCONFI.Projeto.Domain.UnitOfWork;
using System.Collections.Generic;
using System.Linq;

namespace SRCONFI.Projeto.Business
{
    public class MesBusiness
    {
        public List<Domain.Entity.Mes> ListMes()
        {
            List<Domain.Entity.Mes> listMes = new List<Domain.Entity.Mes>();
            using (var unitOfWork = new UnitOfWork(new Domain.BancoContext()))
            {
                listMes = unitOfWork.Mes.GetAll().ToList();
            }
            return listMes;
        }

        public void AddMes(Domain.Entity.Mes mes)
        {
            using (var unitOfWork = new UnitOfWork(new Domain.BancoContext()))
            {
                unitOfWork.Mes.Add(mes);
                unitOfWork.Complete();
                unitOfWork.Dispose();
            }
        }
        public void EditMes(Domain.Entity.Mes mes)
        {
            using (var unitOfWork = new UnitOfWork(new Domain.BancoContext()))
            {
                unitOfWork.Mes.Edit(mes);
                unitOfWork.Complete();
                unitOfWork.Dispose();
            }
        }
        public void DeleteMes(int id)
        {
            using (var unitOfWork = new UnitOfWork(new Domain.BancoContext()))
            {
                var mes = unitOfWork.Mes.Get(id);
                unitOfWork.Mes.Remove(mes);
                unitOfWork.Complete();
                unitOfWork.Dispose();
            }
        }
        public Domain.Entity.Mes GetMes(int idMes)
        {
            Domain.Entity.Mes mes;
            using (var unitOfWork = new UnitOfWork(new Domain.BancoContext()))
            {
                mes = unitOfWork.Mes.Get(idMes);
                unitOfWork.Dispose();
            }

            return mes;
        }

    }
}
