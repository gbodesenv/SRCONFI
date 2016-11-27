using System;


namespace SRCONFI.Projeto.Domain.Entity
{
    public class Pagamentos
    {
        public int pagamentoID { get; set; }

        public int? socioID_FK { get; set; }

        public int? mesID_FK { get; set; }

        public DateTime dataPag { get; set; }

        public Decimal valorPag { get; set; }

        public string comentarioPag { get; set; }

        public string justificativaCanc { get; set; }

        public DateTime dataCanc { get; set; }

        public string justificativaRetificacao { get; set; }

        public string dataRetificacao { get; set; }

        public byte? inCancelado { get; set; }

        public virtual Mes Mes { get; set; }

        public virtual Socios Socios { get; set; }
    }
}
