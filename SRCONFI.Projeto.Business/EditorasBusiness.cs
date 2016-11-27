using SRCONFI.Projeto.Domain.UnitOfWork;
using System.Collections.Generic;
using System.Linq;

namespace SRCONFI.Projeto.Business
{
    public class EditorasBusiness
    {
        public List<Domain.Entity.Editoras> ListEditoras()
        {
            List<Domain.Entity.Editoras> listEditoras = new List<Domain.Entity.Editoras>();
            using (var unitOfWork = new UnitOfWork(new Domain.BancoContext()))
            {
                listEditoras = unitOfWork.Editoras.GetAll().ToList();
            }
            return listEditoras;
        }

        public void AddEditoras(Domain.Entity.Editoras editoras)
        {
            using (var unitOfWork = new UnitOfWork(new Domain.BancoContext()))
            {
                unitOfWork.Editoras.Add(editoras);
                unitOfWork.Complete();
                unitOfWork.Dispose();
            }
        }
        public void EditEditoras(Domain.Entity.Editoras editoras)
        {
            using (var unitOfWork = new UnitOfWork(new Domain.BancoContext()))
            {
                unitOfWork.Editoras.Edit(editoras);
                unitOfWork.Complete();
                unitOfWork.Dispose();
            }
        }
        public void DeleteEditoras(int id)
        {
            using (var unitOfWork = new UnitOfWork(new Domain.BancoContext()))
            {
                var editoras = unitOfWork.Editoras.Get(id);
                unitOfWork.Editoras.Remove(editoras);
                unitOfWork.Complete();
                unitOfWork.Dispose();
            }
        }
        public Domain.Entity.Editoras GetEditoras(int idEditoras)
        {
            Domain.Entity.Editoras editoras;
            using (var unitOfWork = new UnitOfWork(new Domain.BancoContext()))
            {
                editoras = unitOfWork.Editoras.Get(idEditoras);
                unitOfWork.Dispose();
            }

            return editoras;
        }

    }
}
