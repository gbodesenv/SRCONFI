using SRCONFI.Projeto.Domain.UnitOfWork;
using System.Collections.Generic;
using System.Linq;

namespace SRCONFI.Projeto.Business
{
    public class SociosBusiness
    {
        public List<Domain.Entity.Socios> ListSocios()
        {
            List<Domain.Entity.Socios> lstSocios = new List<Domain.Entity.Socios>();
            using (var unitOfWork = new UnitOfWork(new Domain.BancoContext()))
            {
                lstSocios = unitOfWork.Socios.GetAllAndRelation().ToList();
                unitOfWork.Dispose();
            }
            return lstSocios;
        }
        public void AddSocios(Domain.Entity.Socios usu)
        {
            using (var unitOfWork = new UnitOfWork(new Domain.BancoContext()))
            {
                unitOfWork.Socios.Add(usu);
                unitOfWork.Complete();
                unitOfWork.Dispose();
            }
        }
        public void EditSocios(Domain.Entity.Socios usu)
        {
            using (var unitOfWork = new UnitOfWork(new Domain.BancoContext()))
            {
                unitOfWork.Socios.Edit(usu);
                unitOfWork.Complete();
                unitOfWork.Dispose();
            }
        }
        public void DeleteSocios(int id)
        {
            using (var unitOfWork = new UnitOfWork(new Domain.BancoContext()))
            {
                var usu = unitOfWork.Socios.Get(id);
                unitOfWork.Socios.Remove(usu);
                unitOfWork.Complete();
                unitOfWork.Dispose();
            }
        }
        public Domain.Entity.Socios GetSocios(int idUsu)
        {
            Domain.Entity.Socios socios;
            using (var unitOfWork = new UnitOfWork(new Domain.BancoContext()))
            {
                socios = unitOfWork.Socios.Get(idUsu);
                unitOfWork.Dispose();
            }

            return socios;
        }

        public Domain.Entity.Socios GetAndRelation(int idSocio)
        {
            Domain.Entity.Socios socios;
            using (var unitOfWork = new UnitOfWork(new Domain.BancoContext()))
            {
                socios = unitOfWork.Socios.GetAndRelation(idSocio);
                unitOfWork.Dispose();
            }

            return socios;
        }
      
    }
}