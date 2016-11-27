using SRCONFI.Projeto.Domain.UnitOfWork;
using System.Collections.Generic;
using System.Linq;

namespace SRCONFI.Projeto.Business
{
    public class EstadoCivilBusiness
    {
        public List<Domain.Entity.EstadoCivil> ListEstadoCivil()
        {
            List<Domain.Entity.EstadoCivil> listEstadoCivil = new List<Domain.Entity.EstadoCivil>();
            using (var unitOfWork = new UnitOfWork(new Domain.BancoContext()))
            {
                listEstadoCivil = unitOfWork.EstadoCivil.GetAll().ToList();
            }
            return listEstadoCivil;
        }

        public void AddEstadoCivil(Domain.Entity.EstadoCivil estadoCivil)
        {
            using (var unitOfWork = new UnitOfWork(new Domain.BancoContext()))
            {
                unitOfWork.EstadoCivil.Add(estadoCivil);
                unitOfWork.Complete();
                unitOfWork.Dispose();
            }
        }
        public void EditEstadoCivil(Domain.Entity.EstadoCivil estadoCivil)
        {
            using (var unitOfWork = new UnitOfWork(new Domain.BancoContext()))
            {
                unitOfWork.EstadoCivil.Edit(estadoCivil);
                unitOfWork.Complete();
                unitOfWork.Dispose();
            }
        }
        public void DeleteEstadoCivil(int id)
        {
            using (var unitOfWork = new UnitOfWork(new Domain.BancoContext()))
            {
                var estadoCivil = unitOfWork.EstadoCivil.Get(id);
                unitOfWork.EstadoCivil.Remove(estadoCivil);
                unitOfWork.Complete();
                unitOfWork.Dispose();
            }
        }
        public Domain.Entity.EstadoCivil GetEstadoCivil(int idEstadoCivil)
        {
            Domain.Entity.EstadoCivil estadoCivil;
            using (var unitOfWork = new UnitOfWork(new Domain.BancoContext()))
            {
                estadoCivil = unitOfWork.EstadoCivil.Get(idEstadoCivil);
                unitOfWork.Dispose();
            }

            return estadoCivil;
        }

    }
}
