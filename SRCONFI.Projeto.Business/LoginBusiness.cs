using SRCONFI.Projeto.Domain.UnitOfWork;
namespace SRCONFI.Projeto.Business
{
    public class LoginBusiness
    {
        public bool AutenticarUsuario(Domain.Entity.Usuario usu)
        {
            Domain.Entity.Usuario usuarioBD;
            using (var unitOfWork = new UnitOfWork(new Domain.BancoContext()))
            {
                usuarioBD = unitOfWork.Usuario.ValidLoginUsuario(usu.login, usu.senha);
                unitOfWork.Dispose();
            }

            if (usuarioBD == null)
                return false;

            if (usuarioBD != null && usuarioBD.inStatus == 0)
                throw new System.Exception("Usuário Inativo no sistama!");

            return usuarioBD != null && usuarioBD.usuarioID > 0;
        }
    }
}
