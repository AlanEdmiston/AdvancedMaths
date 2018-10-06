using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AE.AdvancedMaths
{
    public static class Statistics
    {
        public static int NcR(int n, int r)
        {
            int output = 1;
            if(r < n / 2)
            {
                r = n - r;
            }
            for (int i = r + 1; i < n + 1; i++)
            {
                output = output * i;
            }
            output = output / AdvancedMaths.Fact(n - r);
            return output;
        }
        public static double Bayes(double coincidenceProb, double evidenceProb, double evidenceGivenData)
        {
            return coincidenceProb * evidenceProb / evidenceGivenData;
        }
        public static int NpR(int n, int r)
        {
            int output = 1;
            for (int i = r + 1; i < n + 1; i++)
            {
                output = output * i;
            }
            return output;
        }
        public static double Binomial(int n, double p, int PositiveResults)
        {
            return NcR(n, PositiveResults) * Math.Pow(p, PositiveResults) * Math.Pow(1 - p, n - PositiveResults);
        }

        public static double BinomialCumulative(int n, double p, int PositiveResults)
        {
            double output = 0;
            if(PositiveResults < n / 2)
            {
                for(int i = 0; i < PositiveResults; i++)
                {
                    output += Binomial(n, p, i);
                }
            }
            else
            {
                for (int i = PositiveResults + 1; i < n + 1; i++)
                {
                    output += Binomial(n, p, i);
                }
                output = 1 - output;
            }
            return output;
        }

        public static double Poisson(int k, double lambda)
        {
            return Math.Pow(lambda, k) * Math.Exp(-lambda) / AdvancedMaths.LargeFact(k);
        }

        public static double GaussianNormalisedCumulative(double deviationsFromMean, double acceptableError)
        {
            double output = 0;
            double z = deviationsFromMean / Math.Sqrt(2);
            double maxError;
            int i = 0;
            do
            {
                maxError = (Math.Pow(-1, i) * Math.Pow(z, 2 * i + 1)) / (AdvancedMaths.Fact(i) * (2 * i + 1));
                output += maxError;
                i++;
            } while (acceptableError < 2 * Math.Sqrt(Math.PI) * maxError);
            return output * 2 * Math.Sqrt(Math.PI);
        }

        public static double Gaussian(double deviationsFromMean)
        {
            return Math.Exp(-Math.Pow(deviationsFromMean, 2) / 2) / Math.Sqrt(2 * Math.PI);
        }

        public static double Median(List<double> data)
        {
            List<double> sortedData = data;
            sortedData.Sort();
            int i = data.Count / 2;
            return sortedData.ElementAt(i);
        }

        public static double Skew(List<double> data)
        {
            return (data.Average() - Median(data)) / StandardDeviation(data);
        }

        public static double Sxx(List<double> data)
        {
            double sxx = 0;
            double average = data.Average();
            foreach(double element in data)
            {
                sxx += Math.Pow(element - average, 2);
            }
            return sxx;
        }

        public static double StandardDeviation(List<double> data)
        {
            return Math.Sqrt(Sxx(data) / (data.Count - 1));
        }

        public static double Sxy(List<double> XData, List<double> YData)
        {
            double averageX = XData.Average();
            double averageY = YData.Average();
            double sxy = 0;
            double elementY;
            int i = 0;
            foreach(double elementX in XData)
            {
                i++;
                elementY = YData.ElementAt(i);
                sxy += (elementX - averageX) * (elementY * averageY);
            }
            return sxy;
        }

        public static double Pearsons(List<double> XData, List<double> YData)
        {
            return (Sxy(XData, YData) / Math.Sqrt(Sxx(XData) * Sxx(YData)));
        }

        public static double[] LinearFit(List<double> XData, List<double> YData)
        {
            double slope = (Sxy(XData, YData) / Sxx(XData));
            double intercept = YData.Average() - slope * XData.Average();
            return new double[]{ slope, intercept};
        }

        public static double ChiSquared(List<double> Data, List<double> ExpectedValues)
        {
            double output = 0;
            int i = 0;
            foreach(double element in Data)
            {
                i++;
                output += Math.Pow(element - ExpectedValues.ElementAt(i), 2);
            }
            return output;
        }

        public static double[,] FourierDataFitting(List<double> XData, List<double> YData, int funcs)
        {
            double[,] coeffs = new double[funcs, 2];
            double[] xDataArr = XData.ToArray();
            double[] yDataArr = YData.ToArray();
            double length = XData.Last() - XData.First();

            for (int i = 1; i < xDataArr.Length; i++)
            {
                coeffs[0, 0] += (xDataArr[i] - xDataArr[i - 1]) * (yDataArr[i] + yDataArr[i - 1]);
            }
            coeffs[0, 0] = coeffs[0, 0] / length;
            for (int i = 1; i < funcs + 1; i++)
            {
                for(int j = 1; j < xDataArr.Length; j++)
                {
                    coeffs[i, 0] += (xDataArr[j] - xDataArr[j - 1]) * (yDataArr[j] * Math.Cos(2 * Math.PI * xDataArr[j] * i / length) + yDataArr[j - 1] * Math.Cos(2 * Math.PI * xDataArr[j - 1] * i / length));
                    coeffs[i, 1] += (xDataArr[j] - xDataArr[j - 1]) * (yDataArr[j] * Math.Sin(2 * Math.PI * xDataArr[j] * i / length) + yDataArr[j - 1] * Math.Sin(2 * Math.PI * xDataArr[j - 1] * i / length));
                }
                coeffs[i, 0] = coeffs[i, 0] / length;
                coeffs[i, 1] = coeffs[i, 1] / length;
            }
            return coeffs;
        }
        public static double Entropy(double[] probabilities, double[] values)
        {
            ///<para>returns the entropy of a probablitiy mass distribution in bits</para>
            double expLogPmf = 0;
            for(int i = 0; i < probabilities.Length; i++)
            {
                expLogPmf -= values[i] * Math.Log(probabilities[i]);
            }
            return expLogPmf / Math.Log(2);
        }
        public static double ConditionalEntropy(double[] probabilities, double[] values)
        {
            double expLogPmf = 0;
            for (int i = 0; i < probabilities.Length; i++)
            {
                expLogPmf -= values[i] * Math.Log(probabilities[i]);
            }
            return expLogPmf;
        }
    }
}
