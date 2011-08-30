using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProjectEuler
{
    [TestClass]
    public class Problem01
    {
        [TestMethod]
        public void ASomaDosNumerosNaturaisMultiplosDe3Ou5AbaixoDe10DeveSer23()
        {
            const int resultadoEsperado = 23;
            var resultado = SomarMultiplosDe3Ou5(10);

            Assert.AreEqual(resultadoEsperado, resultado);
        }

        [TestMethod]
        public void ASomaDosNumerosNaturaisMultiplosDe3Ou5AbaixoDe1000DeveSer233168()
        {
            const int resultadoEsperado = 233168;
            var resultado = SomarMultiplosDe3Ou5(1000);

            Assert.AreEqual(resultadoEsperado, resultado);
        }
        
        int SomarMultiplosDe3Ou5(int numero)
        {
            var somaDosMultiplos = 0;

            for (int i = 1; i < numero; i++)
            {
                if (i % 3 == 0 || i % 5 == 0)
                    somaDosMultiplos += i;
            }

            return somaDosMultiplos;
        }
    }
}