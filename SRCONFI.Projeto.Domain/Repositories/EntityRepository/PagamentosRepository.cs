using SRCONFI.Projeto.Domain.Entity;
using SRCONFI.Projeto.Domain.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace SRCONFI.Projeto.Domain.Repositories.EntityRepository
{
    public class PagamentosRepository : Repository<Pagamentos>, IPagamentosRepository
    {
        public PagamentosRepository(BancoContext context)
            : base(context)
        {
        }

        public Pagamentos GetAndRelation(int id)
        {
            return BancoContext.Pagamentos.Include("Socios")
                                      .Include("Mes")
                                      .FirstOrDefault(s => s.pagamentoID == id);
        }

        public IEnumerable<Pagamentos> GetAllAndRelation()
        {
            return BancoContext.Pagamentos.Include("Socios")
                                      .Include("Mes");
        }
        

        public BancoContext BancoContext
        {
            get { return Context as BancoContext; }
        }

    }
}