using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AE.AdvancedMaths.Test
{
    [TestClass]
    public class ComplexTest
    {
        [TestMethod]
        public void MultTest1()
        {
            var c1 = new Complex { Re = 0, Im = 1 };
            var c2 = new Complex { Re = 0, Im = 1 };

            var actual = c1 * c2;

            var actualR = Math.Round(actual.Re, 2);
            var actualI = Math.Round(actual.Im, 2);

            Assert.AreEqual(0.00, actualI);
            Assert.AreEqual(-1.00, actualR);
        }

        [TestMethod]
        public void PowerTest1()
        {
            var c1 = new Complex { Re = 0, Im = 1 };
            var c2 = new Complex { Re = 0, Im = 1 };

            var actual = c1 ^ c2;

            var actualR = Math.Round(actual.Re, 2);
            var actualI = Math.Round(actual.Im, 2);

            Assert.AreEqual(0.00, actualI);
            Assert.AreEqual(0.21, actualR);
        }
    }
}
