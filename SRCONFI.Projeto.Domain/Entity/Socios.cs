using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SRCONFI.Projeto.Domain.Entity
{
    public class Socios
    {
        public int socioID { get; set; }

        [ForeignKey("Categoria")]
        public int? categoriaID_FK { get; set; }

        public int? enderecoID_FK { get; set; }

        public int? dadoComplementarID_FK { get; set; }

        public string nomeSocio { get; set; }

        public string emailsocio { get; set; }

        public int telefoneSocio { get; set; }

        public bool inStatus { get; set; }

        public DateTime dataIngressoSocio { get; set; }




        public virtual Categoria Categoria { get; set; }

        public virtual Endereco Endereco { get; set; }
        
        public virtual DadosComplementares DadosComplementares { get; set; }
    }
}
