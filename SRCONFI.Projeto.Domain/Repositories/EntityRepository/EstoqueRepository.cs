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


        public Estoque GetEstoqueByVendaID(int idVenda)
        {
            return (from e in BancoContext.Estoque.Include("Livros").Include("EntradasLivros").ToList()
                    join v in BancoContext.VendasLivros on e.estoqueID equals v.estoqueID_FK
                    where v.vendaID == idVenda
                    select e).FirstOrDefault();
        }


        public Estoque GetEstoqueByLivroLastDate(int idLivro)
        {
            return BancoContext.Estoque.Include("EntradasLivros").ToList()
                                       .Where(e => e.livroID_FK == idLivro)
                                       .OrderByDescending(es => es.EntradasLivros.dataEntrada).FirstOrDefault();
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
