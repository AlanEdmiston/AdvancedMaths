using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AE.AdvancedMaths
{
    public static class AdvancedMaths
    {
        public static double[,] FourierSeries(Func<double, double> function, double start, double end, int coeffs, int precision)
        {
            double L = end - start;
            double[,] output = new double[coeffs, 2];
            for(int i = 0; i < coeffs; i++)
            {
                Func<double, double> cosFunc = x => function(L * x / Math.PI) * Math.Sin(i * x);
                Func<double, double> sinFunc = x => function(L * x / Math.PI) * Math.Cos(i * x);
                output[i, 0] = Calculus.IntegrateSimpsons3(cosFunc, start, end, precision);
                output[i, 1] = Calculus.IntegrateSimpsons3(sinFunc, start, end, precision);
            }
            return output;
        }
        static Func<double, Complex> FourierTransform(Func<double, double> function, double start, double end, int increments)
        {
            Func<double, double > newFunc = x => function(x) * Math.Exp(2 * Math.PI * x);
            return k => Calculus.IntegrateSimpsons3(newFunc, start, end, increments) * Complex.Exp(k * new Complex(0, 1));
        }

        public static int Fact(this int n)
        {
            if (n > 12)
            {
                throw new ArgumentException("n is too large");
            }
            int factorial = 1;

            for (int i = 2; i < n + 1; i++)
            {
                factorial = factorial * i;
            }
            return factorial;
        }

        public static long LargeFact(this int n)
        {
            long factorial = 1;

            if (n > 20)
            {
                throw new ArgumentException("n is too large");
            }

            for (int i = 2; i < n + 1; i++)
            {
                factorial = factorial * i;
            }
            return factorial;
        }
        public static double LnFactStirlings(this double n)
        {
            double output = n * Math.Log(n) - n + 0.5 * Math.Log(2 * Math.PI * n) + 1 / (12 * n)
                - 1 / (360 * Math.Pow(n, 3)) + 1 / (1260 * Math.Pow(n, 5)) - 1 / (1680 * Math.Pow(n, 7));
            return (output);
        }
        public static double Gamma(this double n)
        {
            return Math.Exp((n - 1).LnFactStirlings());
        }

        public static double Bisection(Func<double, double> f, double x0, double xEnd)
        {

        }
    }
}
