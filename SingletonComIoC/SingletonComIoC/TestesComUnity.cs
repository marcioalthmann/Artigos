using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Practices.Unity;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SingletonComIoC
{
    [TestClass]
    public class TestesComUnity
    {
        [TestMethod]
        public void RetornaAMesmaInstanciaDaClasseConfiguracoesQuandoSolicitadaDuasVezes()
        {
            UnityContainer unityContainer = new UnityContainer();
            unityContainer.RegisterType<Configuracoes>(new ContainerControlledLifetimeManager());

            var configuracoes = unityContainer.Resolve<Configuracoes>();
            var novasConfiguracoes = unityContainer.Resolve<Configuracoes>();

            Assert.AreSame(configuracoes, novasConfiguracoes);
        }
    }
}
