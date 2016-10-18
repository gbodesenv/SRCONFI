using SRCONFI.Projeto.Domain.UnitOfWork;
namespace SRCONFI.Projeto.Business.Login
{
    public class LoginBusiness
    {
        public bool AutenticarUsuario(Domain.Entity.Usuario usu)
        {
            bool logado = false;
            using (var unitOfWork = new UnitOfWork(new Domain.BancoContext()))
            {
                logado = unitOfWork.Usuario.ValidLoginUsuario(usu.login, usu.senha);
            }
            return logado;
        }
    }
}
