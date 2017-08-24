using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AE.AdvancedMaths
{
    public class Statistics
    {
        public int NcR(int n, int r)
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
        public int NpR(int n, int r)
        {
            int output = 1;
            for (int i = r + 1; i < n + 1; i++)
            {
                output = output * i;
            }
            return output;
        }
        public double Binomial(int n, double p, int PositiveResults)
        {
            return NcR(n, PositiveResults) * Math.Pow(p, PositiveResults) * Math.Pow(1 - p, n - PositiveResults);
        }

        public double BinomialCumulative(int n, double p, int PositiveResults)
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

        public double Poisson(int k, double lambda)
        {
            return Math.Pow(lambda, k) * Math.Exp(-lambda) / AdvancedMaths.LargeFact(k);
        }

        public double GaussianNormalised(double deviationsFromMean, double acceptableError)
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

        public double Median(List<double> data)
        {
            List<double> sortedData = data;
            sortedData.Sort();
            int i = data.Count / 2;
            return sortedData.ElementAt(i);
        }

        public double Skew(List<double> data)
        {
            return (data.Average() - Median(data)) / StandardDeviation(data);
        }

        public double Sxx(List<double> data)
        {
            double sxx = 0;
            double average = data.Average();
            foreach(double element in data)
            {
                sxx += Math.Pow(element - average, 2);
            }
            return sxx;
        }

        public double StandardDeviation(List<double> data)
        {
            return Math.Sqrt(Sxx(data) / (data.Count - 1));
        }

        public double Sxy(List<double> XData, List<double> YData)
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

        public double Pearsons(List<double> XData, List<double> YData)
        {
            return (Sxy(XData, YData) / Math.Sqrt(Sxx(XData) * Sxx(YData)));
        }

        public double[] LinearFit(List<double> XData, List<double> YData)
        {
            double slope = (Sxy(XData, YData) / Sxx(XData));
            double intercept = YData.Average() - slope * XData.Average();
            return new double[]{ slope, intercept};
        }

        public double ChiSquared(List<double> Data, List<double> ExpectedValues)
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
    }
}
