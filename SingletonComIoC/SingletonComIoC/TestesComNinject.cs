using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;

namespace SingletonComIoC
{
    [TestClass]
    public class TestesComNinject
    {
        [TestMethod]
        public void RetornaAMesmaInstanciaDaClasseConfiguracoesQuandoSolicitadaDuasVezes()
        {
            StandardKernel ninjectKernel = new StandardKernel();
            ninjectKernel.Bind<Configuracoes>().ToSelf().InSingletonScope();

            var configuracoes = ninjectKernel.Get<Configuracoes>();
            var novasConfiguracoes = ninjectKernel.Get<Configuracoes>();

            Assert.AreSame(configuracoes, novasConfiguracoes);
        }
    }
}
