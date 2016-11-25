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
    public class SociosRepository : Repository<Socios>, ISociosRepository
    {
        public SociosRepository(BancoContext context)
            : base(context)
        {
        }

        public Socios GetAndRelation(int id)
        {
            return BancoContext.Socios.Include("DadosComplementares")
                                      .Include("Categoria")
                                      .Include("Endereco")                                      
                                      .FirstOrDefault(s => s.socioID == id);
        }

        public IEnumerable<Socios> GetAllAndRelation()
        {
            return BancoContext.Socios.Include("Categoria")
                                      .Include("DadosComplementares")
                                      .Include("DadosComplementares.Escolaridade")
                                      .Include("DadosComplementares.EstadoCivil")
                                      .Include("Endereco");
        }

        public BancoContext BancoContext
        {
            get { return Context as BancoContext; }
        }
    }
}
