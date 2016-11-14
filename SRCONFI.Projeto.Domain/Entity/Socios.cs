using System;

namespace SRCONFI.Projeto.Domain.Entity
{
    public class Socios
    {
        public int socioID { get; set; }

        public int? categoriaID_FK { get; set; }

        public int? enderecoID_FK { get; set; }

        public int? dadoComplementarID_FK { get; set; }

        public string nomeSocio { get; set; }

        public string emailsocio { get; set; }

        public int telefoneSocio { get; set; }

        public Boolean inStatus { get; set; }

        public DateTime dataIngressoSocio { get; set; }

    }
}
