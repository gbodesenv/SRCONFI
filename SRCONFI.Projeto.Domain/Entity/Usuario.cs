﻿
using System.ComponentModel.DataAnnotations;

namespace SRCONFI.Projeto.Domain.Entity
{

    public class Usuario
    {

        public int usuarioID { get; set; }

        [Required(ErrorMessage = "Campo Nome é obrigatório")]
        public string nome { get; set; }


        public string login { get; set; }


        public string senha { get; set; }


        public string email { get; set; }


        public int numeroTelefone { get; set; }

        public byte inStatus { get; set; }

        public int? tipoUsuarioID_FK { get; set; }

        public virtual TipoUsuario TipoUsuario { get; set; }

    }
}
