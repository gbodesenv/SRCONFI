using System;

namespace SRCONFI.Projeto.Domain.Entity
{
    public class Doacoes
    {
       public int doacaoID { get; set; }
      
       public string valorDoacao { get; set; }

       public string comentarioDoacao { get; set; }

       public DateTime dataDoacao { get; set; }

       public string nomeDoador { get; set; }

    }
}
