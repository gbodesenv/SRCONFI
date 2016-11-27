

using System.ComponentModel.DataAnnotations.Schema;

namespace SRCONFI.Projeto.Domain.Entity
{
    public class Livros
    {
        public int livroID { get; set; }
                       
        public string nomeAutor { get; set; }

        public int editoraID_FK { get; set; }

        [ForeignKey("editoraID_FK")]
        public virtual Editoras Editoras { get; set; }

        public int autorID_FK { get; set; }

        [ForeignKey("autorID_FK")]
        public virtual Autores Autores { get; set; }
    }
}
