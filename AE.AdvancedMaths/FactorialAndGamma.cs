using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AE.AdvancedMaths
{
    public class FactorialAndGamma
    {
        public static int Fact(int n)
        {
            if(n > 12)
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

        public static long LargeFact(int n)
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
        public static double LnFactStirling(double n)
        {
            double output = n * Math.Log(n) - n + 0.5 * Math.Log(2 * Math.PI * n) + 1 / (12 * n)
                - 1 / (360 * Math.Pow(n, 3)) + 1 / (1260 * Math.Pow(n, 5)) - 1 / (1680 * Math.Pow(n, 7));
            return (output);
        }
        public static double GammaStirling(double n)
        {
            return Math.Exp(LnFactStirling(n - 1));
        }
    }
}
