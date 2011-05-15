using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Castle.Core;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.Registration.Lifestyle;
using Castle.Windsor;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SingletonComIoC
{
    [TestClass]
    public class TestesComWindsor
    {
        [TestMethod]
        public void RetornaAMesmaInstanciaDaClasseConfiguracoesQuandoSolicitadaDuasVezes()
        {
            WindsorContainer windsorContainer = new WindsorContainer();
            windsorContainer.Register(Component.For<Configuracoes>().LifeStyle.Is(LifestyleType.Singleton));

            var conf = windsorContainer.Resolve<Configuracoes>();
            var conf2 = windsorContainer.Resolve<Configuracoes>();

            Assert.AreSame(conf, conf2);
        }
    }

}
