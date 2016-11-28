using SRCONFI.Projeto.Domain.Entity;
using SRCONFI.Projeto.Domain.Repositories.EntityRepository;
using SRCONFI.Projeto.Domain.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRCONFI.Projeto.Domain.Repositories.EntityRepository
{
    public class EstoqueRepository : Repository<Estoque>, IEstoqueRepository
    {
        public EstoqueRepository(BancoContext context)
            : base(context)
        {
        }

        public Estoque GetEstoqueByEntradaID(int idEntrada)
        {
            return BancoContext.Estoque.FirstOrDefault(s => s.entradaID_FK == idEntrada);
        }



        public Estoque GetAndRelation(int id)
        {
            return BancoContext.Estoque.Include("EntradasLivros")
                                      .Include("Livros")
                                      .FirstOrDefault(s => s.estoqueID == id);
        }

        public IEnumerable<Estoque> GetAllAndRelation()
        {
            return BancoContext.Estoque.Include("EntradasLivros")
                                      .Include("Livros");
        }

        public BancoContext BancoContext
        {
            get { return Context as BancoContext; }
        }
    }
}
