using System;
using System.Dynamic;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Simple.Data;

namespace SimpleData
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var database = Database.Open();

            var estiloMusical = new EstiloMusical
                                    {
                                        Nome = "Black Metal"
                                    };
            
            database.EstiloMusical.Insert(estiloMusical);
            Assert.AreNotEqual(0, estiloMusical.IdEstiloMusical);
        }
    }

    public class EstiloMusical
    {
        public int IdEstiloMusical { get; set; }
        public string Nome { get; set; }
    }
}
