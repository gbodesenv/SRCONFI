using System;

namespace SRCONFI.Projeto.Domain.Entity
{
    public class DadosComplementares
    {
        public int dadoComplementarID { get; set; }

        public int? escolaridadeID_FK { get; set; }

        public int? EstadoCivilID_FK { get; set; }

        public int nrCpfSocio { get; set; }

        public string rgSocio { get; set; }

        public string sexoSocio { get; set; }

        public DateTime dataNascSocio { get; set; }

        public int nrCelularSocio { get; set; }

        public string nacionalidadeSocio { get; set; }

        public string profissaoSocio { get; set; }



        public virtual Escolaridade Escolaridade { get; set; }

        public virtual EstadoCivil EstadoCivil { get; set; }
    }
}
