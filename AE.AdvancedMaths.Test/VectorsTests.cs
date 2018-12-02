using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AE.AdvancedMaths.Test
{
    [TestClass]
    public class VectorsTests
    {
        [TestMethod]
        public void VectAddTest()
        {
            Vector vect1, vect2;
            vect1 = new Vector (3);
            vect2 = new Vector (3);

            vect1.elements = new double[] { 1, 3, 2 };
            vect2.elements = new double[] { 5, 1, 8 };

            Vector output = vect1 + vect2;
            for (int i = 0; i < vect1.size; i++)
            {
                output.elements[i] = Math.Round(output.elements[i], 2);
            }

            Vector real = new Vector(3);
            real.elements = new double[] { 6, 4, 10 };
            for (int i = 0; i < vect1.size; i++)
            {
                Assert.AreEqual(real.elements[i], output.elements[i]);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void VectAdd_Throws_Exception_Different_Dimensions()
        {
            Vector vect1, vect2;
            vect1 = new Vector (4);
            vect2 = new Vector (3);

            vect1.elements = new double[]{ 1, 3, 2, 0};
            vect2.elements = new double[] { 5, 1, 8};

            Vector output = vect1 + vect2;
        }

        [TestMethod]
        public void VectSubTest()
        {
            Vector vect1, vect2;
            vect1 = new Vector (3);
            vect2 = new Vector (3);

            vect1.elements = new double[] { 1, 3, 2 };
            vect2.elements = new double[] { 5, 1, 8 };

            Vector output = vect1 - vect2;
            for (int i = 0; i < vect1.size; i++)
            {
                output.elements[i] = Math.Round(output.elements[i], 2);
            }

            Vector real = new Vector(3);
            real.elements = new double[] { -4, 2, -6 };
            for (int i = 0; i < vect1.size; i++)
            {
                Assert.AreEqual(real.elements[i], output.elements[i]);
            }
        }

        [TestMethod]
        public void VectModTest()
        {
            Vector vect = new Vector(new double[]{ 3, 4});
            Assert.AreEqual(vect.Mod, 5);
        }
    }
}
