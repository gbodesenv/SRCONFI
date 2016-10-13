using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SRCONFI.Projeto.Web.ViewModel
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Campo Usuário obrigatório")]
        [DisplayName("Usuário")]        
        public string Usuario { get; set; }
        [Required(ErrorMessage = "Campo Senha obrigatório")]
        [DisplayName("Senha")]
        public string Senha { get; set; }
    }
}