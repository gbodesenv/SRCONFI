namespace SRCONFI.Projeto.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RecriandoBaseERelacionamentos : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TB_LOGS", "Usuario_usuarioID", "dbo.TB_USUARIOS");
            DropIndex("dbo.TB_LOGS", new[] { "Usuario_usuarioID" });
            RenameColumn(table: "dbo.TB_LOGS", name: "Usuario_usuarioID", newName: "usuarioID_FK");
            RenameColumn(table: "dbo.TB_USUARIOS", name: "tipoUsuarioID", newName: "tipoUsuarioID_FK");
            RenameIndex(table: "dbo.TB_USUARIOS", name: "IX_tipoUsuarioID", newName: "IX_tipoUsuarioID_FK");
            CreateTable(
                "dbo.TB_ATIVIDADES",
                c => new
                    {
                        ID_ATIVIDADE = c.Int(nullable: false, identity: true),
                        localID_FK = c.Int(),
                        TX_NOME_ATIVIDADE = c.String(nullable: false, maxLength: 250),
                        TX_DESCRICAO_ATIVIDADE = c.String(nullable: false, maxLength: 250),
                        DT_DATA_INICIO_ATIVIDADE = c.DateTime(nullable: false),
                        DT_DATA_TERMINO_ATIVIDADE = c.DateTime(nullable: false),
                        IN_INATIVO = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID_ATIVIDADE)
                .ForeignKey("dbo.TB_LOCAL_ATIVIDADE", t => t.localID_FK)
                .Index(t => t.localID_FK);
            
            CreateTable(
                "dbo.TB_LOCAL_ATIVIDADE",
                c => new
                    {
                        ID_LOCAL = c.Int(nullable: false, identity: true),
                        periodoID_FK = c.Int(),
                        TX_DESCRICAO_LOCAL = c.String(nullable: false, maxLength: 150),
                        NR_LOTACAO = c.Int(nullable: false),
                        IN_ATIVO = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID_LOCAL);
            
            CreateTable(
                "dbo.TB_PERIODO_ATIVIDADE",
                c => new
                    {
                        ID_PERIODO = c.Int(nullable: false, identity: true),
                        diasSemanaID_FK = c.Int(),
                        DT_HORA_INICIO = c.DateTime(nullable: false),
                        DT_HORA_FIM = c.DateTime(nullable: false),
                        atividadesID_FK = c.Int(nullable: false),
                        localAtividadeID_FK = c.Int(),
                    })
                .PrimaryKey(t => t.ID_PERIODO)
                .ForeignKey("dbo.TB_ATIVIDADES", t => t.atividadesID_FK, cascadeDelete: true)
                .ForeignKey("dbo.TB_DIAS_SEMANA", t => t.diasSemanaID_FK)
                .ForeignKey("dbo.TB_LOCAL_ATIVIDADE", t => t.atividadesID_FK, cascadeDelete: true)
                .Index(t => t.diasSemanaID_FK)
                .Index(t => t.atividadesID_FK);
            
            CreateTable(
                "dbo.TB_DIAS_SEMANA",
                c => new
                    {
                        ID_DIA_SEMANA = c.Int(nullable: false, identity: true),
                        TX_NOME_SEMANA = c.String(nullable: false, maxLength: 250),
                    })
                .PrimaryKey(t => t.ID_DIA_SEMANA);
            
            CreateTable(
                "dbo.TB_CATEGORIA",
                c => new
                    {
                        ID_CATEGORIA = c.Int(nullable: false, identity: true),
                        TX_DESCRICAO = c.String(nullable: false, maxLength: 150),
                    })
                .PrimaryKey(t => t.ID_CATEGORIA);
            
            CreateTable(
                "dbo.TB_DADOS_COMPLEMENTARES",
                c => new
                    {
                        ID_DADO_COMPLEMENTAR = c.Int(nullable: false, identity: true),
                        escolaridadeID_FK = c.Int(),
                        EstadoCivilID_FK = c.Int(),
                        NR_CPF_SOCIO = c.Int(nullable: false),
                        TX_RG_SOCIO = c.String(nullable: false, maxLength: 50),
                        TX_SEXO_SOCIO = c.String(nullable: false, maxLength: 50),
                        DT_DATA_NASC_SOCIO = c.DateTime(nullable: false),
                        NR_CELULAR_SOCIO = c.Int(nullable: false),
                        TX_NACIONALIDADE_SOCIO = c.String(nullable: false, maxLength: 150),
                        TX_PROFISSAO_SOCIO = c.String(nullable: false, maxLength: 150),
                    })
                .PrimaryKey(t => t.ID_DADO_COMPLEMENTAR)
                .ForeignKey("dbo.TB_ESCOLARIDADE", t => t.escolaridadeID_FK)
                .ForeignKey("dbo.TB_ESTADO_CIVIL", t => t.EstadoCivilID_FK)
                .Index(t => t.escolaridadeID_FK)
                .Index(t => t.EstadoCivilID_FK);
            
            CreateTable(
                "dbo.TB_ESCOLARIDADE",
                c => new
                    {
                        ID_ESCOLARIDADE = c.Int(nullable: false, identity: true),
                        TX_DESC_ESCOL = c.String(nullable: false, maxLength: 150),
                    })
                .PrimaryKey(t => t.ID_ESCOLARIDADE);
            
            CreateTable(
                "dbo.TB_ESTADO_CIVIL",
                c => new
                    {
                        ID_ESCOLARIDADE = c.Int(nullable: false, identity: true),
                        TX_DESCRICAO_EST_CIV = c.String(nullable: false, maxLength: 150),
                    })
                .PrimaryKey(t => t.ID_ESCOLARIDADE);
            
            CreateTable(
                "dbo.TB_ENDERECO",
                c => new
                    {
                        ID_ENDERECO = c.Int(nullable: false, identity: true),
                        estadoID_FK = c.Int(),
                        TX_CIDADE = c.String(nullable: false, maxLength: 150),
                        NR_CEP = c.Int(nullable: false),
                        TX_ENDERECO = c.String(nullable: false, maxLength: 250),
                        NR_NUMERO = c.Int(nullable: false),
                        TX_COMPLEMENTO = c.String(nullable: false, maxLength: 150),
                        TX_BAIRRO = c.String(nullable: false, maxLength: 150),
                    })
                .PrimaryKey(t => t.ID_ENDERECO)
                .ForeignKey("dbo.TB_UF", t => t.estadoID_FK)
                .Index(t => t.estadoID_FK);
            
            CreateTable(
                "dbo.TB_UF",
                c => new
                    {
                        ID_UF = c.Int(nullable: false, identity: true),
                        TX_NOME_UF = c.String(nullable: false, maxLength: 150),
                        TX_SIGLA_UF = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.ID_UF);
            
            CreateTable(
                "dbo.TB_PARTICIPANTES",
                c => new
                    {
                        ID_PARTICIPANTE = c.Int(nullable: false, identity: true),
                        socioID = c.Int(),
                        atividadeID = c.Int(),
                    })
                .PrimaryKey(t => t.ID_PARTICIPANTE)
                .ForeignKey("dbo.TB_ATIVIDADES", t => t.atividadeID)
                .ForeignKey("dbo.TB_SOCIOS", t => t.socioID)
                .Index(t => t.socioID)
                .Index(t => t.atividadeID);
            
            CreateTable(
                "dbo.TB_SOCIOS",
                c => new
                    {
                        ID_SOCIO = c.Int(nullable: false, identity: true),
                        TX_NOME_SOCIO = c.String(nullable: false, maxLength: 100),
                        TX_EMAIL_SOCIO = c.String(nullable: false, maxLength: 250),
                        NR_TELEFONE_SOCIO = c.Int(nullable: false),
                        IN_STATUS = c.Byte(nullable: false),
                        DT_DATA_INGRESSO_SOCIO = c.DateTime(nullable: false),
                        ID_CATEGORIA = c.Int(nullable: false),
                        ID_ENDERECO = c.Int(nullable: false),
                        ID_DADO_COMPLEMENTAR = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID_SOCIO)
                .ForeignKey("dbo.TB_CATEGORIA", t => t.ID_CATEGORIA, cascadeDelete: true)
                .ForeignKey("dbo.TB_DADOS_COMPLEMENTARES", t => t.ID_DADO_COMPLEMENTAR, cascadeDelete: true)
                .ForeignKey("dbo.TB_ENDERECO", t => t.ID_ENDERECO, cascadeDelete: true)
                .Index(t => t.ID_CATEGORIA)
                .Index(t => t.ID_ENDERECO)
                .Index(t => t.ID_DADO_COMPLEMENTAR);
            
            AlterColumn("dbo.TB_LOGS", "usuarioID_FK", c => c.Int());
            CreateIndex("dbo.TB_LOGS", "usuarioID_FK");
            AddForeignKey("dbo.TB_LOGS", "usuarioID_FK", "dbo.TB_USUARIOS", "ID_USUARIO");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TB_LOGS", "usuarioID_FK", "dbo.TB_USUARIOS");
            DropForeignKey("dbo.TB_PARTICIPANTES", "socioID", "dbo.TB_SOCIOS");
            DropForeignKey("dbo.TB_SOCIOS", "ID_ENDERECO", "dbo.TB_ENDERECO");
            DropForeignKey("dbo.TB_SOCIOS", "ID_DADO_COMPLEMENTAR", "dbo.TB_DADOS_COMPLEMENTARES");
            DropForeignKey("dbo.TB_SOCIOS", "ID_CATEGORIA", "dbo.TB_CATEGORIA");
            DropForeignKey("dbo.TB_PARTICIPANTES", "atividadeID", "dbo.TB_ATIVIDADES");
            DropForeignKey("dbo.TB_ENDERECO", "estadoID_FK", "dbo.TB_UF");
            DropForeignKey("dbo.TB_DADOS_COMPLEMENTARES", "EstadoCivilID_FK", "dbo.TB_ESTADO_CIVIL");
            DropForeignKey("dbo.TB_DADOS_COMPLEMENTARES", "escolaridadeID_FK", "dbo.TB_ESCOLARIDADE");
            DropForeignKey("dbo.TB_ATIVIDADES", "localID_FK", "dbo.TB_LOCAL_ATIVIDADE");
            DropForeignKey("dbo.TB_PERIODO_ATIVIDADE", "atividadesID_FK", "dbo.TB_LOCAL_ATIVIDADE");
            DropForeignKey("dbo.TB_PERIODO_ATIVIDADE", "diasSemanaID_FK", "dbo.TB_DIAS_SEMANA");
            DropForeignKey("dbo.TB_PERIODO_ATIVIDADE", "atividadesID_FK", "dbo.TB_ATIVIDADES");
            DropIndex("dbo.TB_SOCIOS", new[] { "ID_DADO_COMPLEMENTAR" });
            DropIndex("dbo.TB_SOCIOS", new[] { "ID_ENDERECO" });
            DropIndex("dbo.TB_SOCIOS", new[] { "ID_CATEGORIA" });
            DropIndex("dbo.TB_PARTICIPANTES", new[] { "atividadeID" });
            DropIndex("dbo.TB_PARTICIPANTES", new[] { "socioID" });
            DropIndex("dbo.TB_LOGS", new[] { "usuarioID_FK" });
            DropIndex("dbo.TB_ENDERECO", new[] { "estadoID_FK" });
            DropIndex("dbo.TB_DADOS_COMPLEMENTARES", new[] { "EstadoCivilID_FK" });
            DropIndex("dbo.TB_DADOS_COMPLEMENTARES", new[] { "escolaridadeID_FK" });
            DropIndex("dbo.TB_PERIODO_ATIVIDADE", new[] { "atividadesID_FK" });
            DropIndex("dbo.TB_PERIODO_ATIVIDADE", new[] { "diasSemanaID_FK" });
            DropIndex("dbo.TB_ATIVIDADES", new[] { "localID_FK" });
            AlterColumn("dbo.TB_LOGS", "usuarioID_FK", c => c.Int(nullable: false));
            DropTable("dbo.TB_SOCIOS");
            DropTable("dbo.TB_PARTICIPANTES");
            DropTable("dbo.TB_UF");
            DropTable("dbo.TB_ENDERECO");
            DropTable("dbo.TB_ESTADO_CIVIL");
            DropTable("dbo.TB_ESCOLARIDADE");
            DropTable("dbo.TB_DADOS_COMPLEMENTARES");
            DropTable("dbo.TB_CATEGORIA");
            DropTable("dbo.TB_DIAS_SEMANA");
            DropTable("dbo.TB_PERIODO_ATIVIDADE");
            DropTable("dbo.TB_LOCAL_ATIVIDADE");
            DropTable("dbo.TB_ATIVIDADES");
            RenameIndex(table: "dbo.TB_USUARIOS", name: "IX_tipoUsuarioID_FK", newName: "IX_tipoUsuarioID");
            RenameColumn(table: "dbo.TB_USUARIOS", name: "tipoUsuarioID_FK", newName: "tipoUsuarioID");
            RenameColumn(table: "dbo.TB_LOGS", name: "usuarioID_FK", newName: "Usuario_usuarioID");
            CreateIndex("dbo.TB_LOGS", "Usuario_usuarioID");
            AddForeignKey("dbo.TB_LOGS", "Usuario_usuarioID", "dbo.TB_USUARIOS", "ID_USUARIO", cascadeDelete: true);
        }
    }
}
