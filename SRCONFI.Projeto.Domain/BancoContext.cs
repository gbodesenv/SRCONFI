using SRCONFI.Projeto.Domain.Entity;
using SRCONFI.Projeto.Domain.Entity.Configuration;
using System.Data.Entity;

namespace SRCONFI.Projeto.Domain
{
    public class BancoContext : DbContext
    {
        #region Construtor
        public BancoContext()
            : base("DBSRCONFI")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }
        #endregion Construtor

        #region Entidades/Tabelas

        #region Inclusão
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<TipoUsuario> TipoUsuario { get; set; }
        public DbSet<Logs> Log { get; set; }
        public DbSet<Atividades> Atividades { get; set; }
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<DadosComplementares> DadosComplementares { get; set; }
        public DbSet<DiasSemana> DiasSemana { get; set; }
        public DbSet<Endereco> Endereco { get; set; }
        public DbSet<Escolaridade> Escolaridade { get; set; }
        public DbSet<EstadoCivil> EstadoCivil { get; set; }
        public DbSet<Estado> Estado { get; set; }
        public DbSet<LocalAtividade> LocalAtividade { get; set; }
        public DbSet<Participantes> Participantes { get; set; }
        public DbSet<PeriodoAtividade> PeriodoAtividade { get; set; }
        public DbSet<Socios> Socios { get; set; }
        public DbSet<Editoras> Editoras { get; set; }
        public DbSet<Livros> Livros { get; set; }
        public DbSet<Autores> Autores { get; set; }
        public DbSet<EntradasLivros> EntradasLivros { get; set; }
        public DbSet<VendasLivros> VendasLivros { get; set; }
        public DbSet<Estoque> Estoque { get; set; }
        public DbSet<Pagamentos> Pagamentos { get; set; }
        public DbSet<Mes> Mes { get; set; }
        public DbSet<Doacoes> Doacoes { get; set; }

        #endregion Inclusão

        #region Configurações 

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Configurations
                .Add(new UsuarioConfiguration())
                .Add(new TipoUsuarioConfiguration())
                .Add(new LogsConfiguration())
                .Add(new AtividadesConfiguration())
                .Add(new CategoriaConfiguration())
                .Add(new DadosComplementaresConfiguration())
                .Add(new DiasSemanaConfiguration())
                .Add(new EnderecoConfiguration())
                .Add(new EscolaridadeConfiguration())
                .Add(new EstadoCivilConfiguration())
                .Add(new EstadoConfiguration())
                .Add(new LocalAtividadeConfiguration())
                .Add(new ParticipantesConfiguration())
                .Add(new PeriodoAtividadeConfiguration())
                .Add(new SociosConfiguration())
                .Add(new EditorasConfiguration())
                .Add(new AutoresConfiguration())
                .Add(new LivrosConfiguration())
                .Add(new EntradasLivrosConfiguration())
                .Add(new EstoqueConfiguration())
                .Add(new VendasLivrosConfiguration())
                .Add(new PagamentosConfiguration())
                .Add(new MesConfiguration())
                .Add(new DoacoesConfiguration());

            modelBuilder.Entity<Usuario>().ToTable("TB_USUARIOS");
            modelBuilder.Entity<TipoUsuario>().ToTable("TB_TIPO_USUARIOS");
            modelBuilder.Entity<Logs>().ToTable("TB_LOGS");
            modelBuilder.Entity<Atividades>().ToTable("TB_ATIVIDADES");
            modelBuilder.Entity<Categoria>().ToTable("TB_CATEGORIA");
            modelBuilder.Entity<DadosComplementares>().ToTable("TB_DADOS_COMPLEMENTARES");
            modelBuilder.Entity<DiasSemana>().ToTable("TB_DIAS_SEMANA");
            modelBuilder.Entity<Endereco>().ToTable("TB_ENDERECO");
            modelBuilder.Entity<Escolaridade>().ToTable("TB_ESCOLARIDADE");
            modelBuilder.Entity<EstadoCivil>().ToTable("TB_ESTADO_CIVIL");
            modelBuilder.Entity<Estado>().ToTable("TB_UF");
            modelBuilder.Entity<LocalAtividade>().ToTable("TB_LOCAL_ATIVIDADE");
            modelBuilder.Entity<Participantes>().ToTable("TB_PARTICIPANTES");
            modelBuilder.Entity<PeriodoAtividade>().ToTable("TB_PERIODO_ATIVIDADE");
            modelBuilder.Entity<Socios>().ToTable("TB_SOCIOS");
            modelBuilder.Entity<Livros>().ToTable("TB_LIVROS");//Em vermelho, nome da tabela que vai ser gerada no banco
            modelBuilder.Entity<Autores>().ToTable("TB_AUTORES");
            modelBuilder.Entity<Editoras>().ToTable("TB_EDITORAS");
            modelBuilder.Entity<EntradasLivros>().ToTable("TB_ENTRADA_LIVROS");
            modelBuilder.Entity<VendasLivros>().ToTable("TB_VENDAS_LIVROS");
            modelBuilder.Entity<Estoque>().ToTable("TB_ESTOQUE_LIVROS");
            modelBuilder.Entity<Pagamentos>().ToTable("TB_PAGAMENTOS");
            modelBuilder.Entity<Mes>().ToTable("TB_MES");
            modelBuilder.Entity<Doacoes>().ToTable("TB_DOACOES");
        }

        #endregion Configurações 

        #endregion Entidades/Tabelas 
    }
}
