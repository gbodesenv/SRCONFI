
namespace SRCONFI.Projeto.Domain.Entity
{
    public class Categoria
    {
        public int categoriaID { get; set; }

        public string descricao { get; set; }

        public virtual Socios Socios { get; set; }
    }
}
