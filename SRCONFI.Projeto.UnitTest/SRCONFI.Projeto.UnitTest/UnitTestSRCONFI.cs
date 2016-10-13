using Microsoft.VisualStudio.TestTools.UnitTesting;
using SRCONFI.Projeto.Domain.Entity;
using SRCONFI.Projeto.Domain.UnitOfWork;
using System.Collections.Generic;
using System.Linq;

namespace SRCONFI.Projeto.UnitTest
{
    [TestClass]
    public class UnitTestSRCONFI
    {

        [TestMethod]
        public void IncluirListaDeUsuariosNoBanco()
        {
            List<Usuario> listaUsuarios = new List<Usuario>();

            Usuario usuarioA = new Usuario();
            usuarioA.nome = "Jáderson";
            usuarioA.email = "jaja@gmail.com";
            usuarioA.login = "jaja";
            usuarioA.numeroTelefone = 99995555;
            usuarioA.senha = "abcdefg";
            usuarioA.inStatus = 1;

            //Ao instanciar um novo "tipoUsuario", esse será incluido no banco de dados.
            usuarioA.TipoUsuario = new TipoUsuario()
            {
                descricaoTipoUsuario = "Administrador"
            };

            listaUsuarios.Add(usuarioA);

            //Usuario usuarioB = new Usuario();
            //usuarioB.nome = "Gabriel";
            //usuarioB.email = "beube@gmail.com";
            //usuarioB.login = "beu";
            //usuarioB.numeroTelefone = 85092217;
            //usuarioB.senha = "12345";
            //usuarioB.inStatus = 0;

            ////faz vinculação a um "tipoUsuario" já existente no banco
            //usuarioB.tipoUsuarioID_FK = 1;

            //listaUsuarios.Add(usuarioB);

            using (var unitOfWork = new UnitOfWork(new Domain.BancoContext()))
            {
                unitOfWork.Usuario.AddRange(listaUsuarios);
                unitOfWork.Complete();
                unitOfWork.Dispose();
            }

            //Assert.AreEqual(0, listaUsuarios.Count());
        }

        [TestMethod]
        public void ListarTodosOsUsuariosDoBanco()
        {
            List<Usuario> listaUsuarios = new List<Usuario>();
            using (var unitOfWork = new UnitOfWork(new Domain.BancoContext()))
            {
                listaUsuarios = unitOfWork.Usuario.GetAll().ToList();
                unitOfWork.Dispose();
            }

            Assert.AreEqual(0, listaUsuarios.Count());
        }
    }
}
