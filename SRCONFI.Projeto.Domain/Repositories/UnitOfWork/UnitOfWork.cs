using SRCONFI.Projeto.Domain.Entity;
using SRCONFI.Projeto.Domain.Repositories;
using SRCONFI.Projeto.Domain.Repositories.EntityRepository;
using SRCONFI.Projeto.Domain.Repositories.Interfaces;

namespace SRCONFI.Projeto.Domain.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BancoContext _context;

        public UnitOfWork(BancoContext context)
        {
            _context = context;
            Usuario = new UsuarioRepository(_context);
            TipoUsuario = new TipoUsuarioRepository(_context);
            Log = new LogRepository(_context);
           
            Categoria = new CategoriaRepository(_context);

            DadosComplementares = new DadosComplementaresRepository(_context);
            Escolaridade = new EscolaridadeRepository(_context);
            EstadoCivil = new EstadoCivilRepository(_context);
            Estado = new EstadoRepository(_context);
        }

        public IUsuarioRepository Usuario { get; private set; }
        public ITipoUsuarioRepository TipoUsuario { get; private set; }
        public ILogRepository Log { get; private set; }
        public ISociosRepository Socios { get; private set; }
        public ICategoriaRepository Categoria { get; private set; }

        public IDadosComplementaresRepository DadosComplementares { get; private set; }
        public IEscolaridadeRepository Escolaridade { get; private set; }
        public IEstadoCivilRepository EstadoCivil { get; private set; }
        public IEstadoRepository Estado { get; private set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
