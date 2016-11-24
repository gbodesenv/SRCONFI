using System;


namespace SRCONFI.Projeto.Domain.Entity
{
    public class Pagamentos
    {
        public int pagamentoID { get; set; }

        public int? socioID { get; set; }

        public int? mesID { get; set; }

        public DateTime dataPag { get; set; }

        public Decimal valorPag { get; set; }

        public string comentarioPag { get; set; }

        public string justificativaCanc { get; set; }

        public DateTime dataCanc { get; set; }

        public string justificativaretificacao { get; set; }

        public string dataRetificacao { get; set; }

        public Boolean inCancelado { get; set; }

        public virtual Mes Mes { get; set; }
    }
}
