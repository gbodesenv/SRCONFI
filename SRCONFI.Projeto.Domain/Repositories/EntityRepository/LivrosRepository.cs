using SRCONFI.Projeto.Domain.Entity;
using SRCONFI.Projeto.Domain.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace SRCONFI.Projeto.Domain.Repositories.EntityRepository
{
    public class LivrosRepository : Repository<Livros>, ILivrosRepository
    {
        public LivrosRepository(BancoContext context)
            : base(context)
        {
        }

        public Livros GetAndRelation(int id)
        {
            return BancoContext.Livros.Include("Editoras")
                                      .Include("Autores")
                                      .FirstOrDefault(s => s.livroID == id);
        }

        public IEnumerable<Livros> GetAllAndRelation()
        {
            return BancoContext.Livros.Include("Editoras")
                                      .Include("Autores");
        }

        public Livros GetLivroByEntradaID(int idEntrada)
        {
            return (from l in BancoContext.Livros.Include("Editoras").Include("Autores").ToList()
            join e in BancoContext.Estoque on l.livroID equals e.livroID_FK
                    where e.entradaID_FK == idEntrada
                    select l).FirstOrDefault();
        }

        public BancoContext BancoContext
        {
            get { return Context as BancoContext; }
        }

    }
}