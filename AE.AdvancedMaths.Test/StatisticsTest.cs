using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AE.AdvancedMaths.Test
{
    [TestClass]
    public class StatisticsTest
    {
        List<double> XData = new List<double> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11};
        List<double> YData = new List<double> { 1, 9, 6, 5, 0, 13, 7, -2, 11, 9, 4};

        List<double> XD = new List<double>();
        List<double> fX = new List<double>();

        [TestMethod]
        void MedianTest()
        {
            double med = Statistics.Median(YData);
            Assert.AreEqual(med, 6);
        }

        [TestMethod]
        void SkewTest()
        {
            double skew = Statistics.Skew(YData);
            skew = Math.Round(skew, 3);
            Assert.AreEqual(skew, -.183);
        }
        [TestMethod]
        void StandardDeviationTest()
        {
            double stdev = Statistics.StandardDeviation(YData);
            stdev = Math.Round(stdev, 3);
            Assert.AreEqual(stdev, 4.494);
        }
        [TestMethod]
        void PearsonsTest()
        {
            double pearsons = Statistics.Pearsons(XData, YData);
            pearsons = Math.Round(pearsons, 3);
            Assert.AreEqual(pearsons, 0.147);
        }
        [TestMethod]
        void FourierTest()
        {
            double[,] ab;
            int funcs = 50;
            ab = Statistics.FourierDataFitting(XData, YData, funcs);
        }
    }
}
