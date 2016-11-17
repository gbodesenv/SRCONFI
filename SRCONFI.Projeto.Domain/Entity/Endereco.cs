
namespace SRCONFI.Projeto.Domain.Entity
{
    public class Endereco
    {
        public int enderecoID { get; set; }

        public int? estadoID_FK { get; set; }

        public string cidade { get; set; }

        public int numeroCEP { get; set; }

        public string endereco { get; set; }

        public int numero { get; set; }

        public string complemento { get; set; }

        public string bairro { get; set; }

        public virtual Estado Estado { get; set; }
    }
}
