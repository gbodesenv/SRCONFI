﻿

namespace SRCONFI.Projeto.Domain.Entity
{
    public class Livros
    {
        public int livroID { get; set; }

        public int? editoraID_FK { get; set; }

        public int? autorID_FK { get; set; }

        public string nomeAutor { get; set; }
    }
}