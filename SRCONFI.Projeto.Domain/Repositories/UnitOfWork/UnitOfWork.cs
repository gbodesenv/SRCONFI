﻿using SRCONFI.Projeto.Domain.Entity;
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
            Socios = new SociosRepository(_context);
            Categoria = new CategoriaRepository(_context);
            DadosComplementares = new DadosComplementaresRepository(_context);
            Escolaridade = new EscolaridadeRepository(_context);
            EstadoCivil = new EstadoCivilRepository(_context);
            Estado = new EstadoRepository(_context);
            Livros = new LivrosRepository(_context);
            Editoras = new EditorasRepository(_context);
            Autores = new AutoresRepository(_context);
            EntradasLivros = new EntradasLivrosRepository(_context);
            Estoque = new EstoqueRepository(_context);

            Atividade = new AtividadesRepository(_context);
            LocalAtividade = new LocalAtividadeRepository(_context);
            PeriodoAtividade = new PeriodoAtividadeRepository(_context);
            VendaLivros = new VendaLivrosRepository(_context);
            Pagamentos = new PagamentosRepository(_context);
            Mes = new MesRepository(_context);
            Doacoes = new DoacoesRepository(_context);
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
        public ILivrosRepository Livros { get; private set; }
        public IEditorasRepository Editoras { get; private set; }
        public IAutoresRepository Autores { get; private set; }
        public IEntradasLivrosRepository EntradasLivros { get; private set; }
        public IEstoqueRepository Estoque { get; private set; }
        public IVendaLivrosRepository VendaLivros { get; private set; }

        public IAtividadesRepository Atividade { get; private set; }
        public ILocalAtividadeRepository LocalAtividade { get; private set; }
        public IPeriodoAtividadeRepository PeriodoAtividade { get; private set; }
        public IPagamentosRepository Pagamentos { get; private set; }
        public IMesRepository Mes { get; private set; }
        public IDoacoesRepository Doacoes { get; private set; }


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
