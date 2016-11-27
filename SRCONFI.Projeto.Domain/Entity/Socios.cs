using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SRCONFI.Projeto.Domain.Entity
{
    public class Socios
    {
        
        public int socioID { get; set; }

        public string nomeSocio { get; set; }

        public string emailsocio { get; set; }

        public int telefoneSocio { get; set; }

        public byte? inStatus { get; set; }

        public DateTime dataIngressoSocio { get; set; }



        public int? categoriaID_FK { get; set; }
        [ForeignKey("categoriaID_FK")]
        public virtual Categoria Categoria { get; set; }


        public int? enderecoID_FK { get; set; }
        [ForeignKey("enderecoID_FK")]
        public virtual Endereco Endereco { get; set; }


        public int? dadoComplementarID_FK { get; set; }
        [ForeignKey("dadoComplementarID_FK")]
        public virtual DadosComplementares DadosComplementares { get; set; }
    }
}
