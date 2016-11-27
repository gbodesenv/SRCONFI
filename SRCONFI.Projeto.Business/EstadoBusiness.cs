using SRCONFI.Projeto.Domain.UnitOfWork;
using System.Collections.Generic;
using System.Linq;

namespace SRCONFI.Projeto.Business
{
    public class EstadoBusiness
    {
        public List<Domain.Entity.Estado> ListEstado()
        {
            List<Domain.Entity.Estado> listEstado = new List<Domain.Entity.Estado>();
            using (var unitOfWork = new UnitOfWork(new Domain.BancoContext()))
            {
                listEstado = unitOfWork.Estado.GetAll().ToList();
            }
            return listEstado;
        }

        public void AddEstado(Domain.Entity.Estado estado)
        {
            using (var unitOfWork = new UnitOfWork(new Domain.BancoContext()))
            {
                unitOfWork.Estado.Add(estado);
                unitOfWork.Complete();
                unitOfWork.Dispose();
            }
        }
        public void EditEstado(Domain.Entity.Estado estado)
        {
            using (var unitOfWork = new UnitOfWork(new Domain.BancoContext()))
            {
                unitOfWork.Estado.Edit(estado);
                unitOfWork.Complete();
                unitOfWork.Dispose();
            }
        }
        public void DeleteEstado(int id)
        {
            using (var unitOfWork = new UnitOfWork(new Domain.BancoContext()))
            {
                var estado = unitOfWork.Estado.Get(id);
                unitOfWork.Estado.Remove(estado);
                unitOfWork.Complete();
                unitOfWork.Dispose();
            }
        }
        public Domain.Entity.Estado GetEstado(int idEstado)
        {
            Domain.Entity.Estado estado;
            using (var unitOfWork = new UnitOfWork(new Domain.BancoContext()))
            {
                estado = unitOfWork.Estado.Get(idEstado);
                unitOfWork.Dispose();
            }

            return estado;
        }

    }
}
