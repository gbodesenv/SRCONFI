
namespace SRCONFI.Projeto.Domain.Entity
{
    public class Endereco
    {
        public int enderecoID { get; set; }

        public int? ufID_FK { get; set; }

        public string cidade { get; set; }

        public string nrCep { get; set; }

        public string endereco { get; set; }

        public int nrNumero { get; set; }

        public string complemento { get; set; }

        public string bairro { get; set; }
    }
}
