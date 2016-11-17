using SRCONFI.Projeto.Domain.UnitOfWork;
using System.Collections.Generic;
using System.Linq;

namespace SRCONFI.Projeto.Business
{
    public class SociosBusiness
    {
        public List<Domain.Entity.Socios> ListSocios()
        {
            List<Domain.Entity.Socios> lstSocioss = new List<Domain.Entity.Socios>();
            using (var unitOfWork = new UnitOfWork(new Domain.BancoContext()))
            {
                lstSocioss = unitOfWork.Socios.GetAllAndRelation().ToList();
                unitOfWork.Dispose();
            }
            return lstSocioss;
        }
        public void AddSocios(Domain.Entity.Socios socios)
        {
            using (var unitOfWork = new UnitOfWork(new Domain.BancoContext()))
            {
                unitOfWork.Socios.Add(socios);
                unitOfWork.Complete();
                unitOfWork.Dispose();
            }
        }
        public void EditSocios(Domain.Entity.Socios socios)
        {
            using (var unitOfWork = new UnitOfWork(new Domain.BancoContext()))
            {
                unitOfWork.Socios.Edit(socios);
                unitOfWork.Complete();
                unitOfWork.Dispose();
            }
        }
        public void DeleteSocios(int id)
        {
            using (var unitOfWork = new UnitOfWork(new Domain.BancoContext()))
            {
                var socios = unitOfWork.Socios.Get(id);
                unitOfWork.Socios.Remove(socios);
                unitOfWork.Complete();
                unitOfWork.Dispose();
            }
        }
        public Domain.Entity.Socios GetSocios(int idSocios)
        {
            Domain.Entity.Socios socios;
            using (var unitOfWork = new UnitOfWork(new Domain.BancoContext()))
            {
                socios = unitOfWork.Socios.Get(idSocios);
                unitOfWork.Dispose();
            }

            return socios;
        }


    }
}
