using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AE.AdvancedMaths
{
    static class Calculus
    {
        public static double IntegrateTrapesium(Func<double, double> function, double start, double end, int increments)
        {
            double integral = 0;
            for (int i = 0; i <= increments; i++)
            {
                double nextValue = function(start + i * (end - start) / increments) * (end - start) / increments;
                if (i == 0 || i == increments)
                {
                    integral += nextValue / 2;
                }
                else
                {
                    integral += nextValue;
                }
            }
            return integral;
        }
        public static double IntegrateSimpsons2(Func<double, double> function, double start, double end, int increments)
        {
            double integral = 0;
            for (int i = 0; i <= increments; i++)
            {
                double nextValue = function(start + i * (end - start) / increments) * (end - start) / (3 * increments);
                if (i == 0 || i == increments)
                {
                    integral += nextValue;
                }
                else if (i % 2 == 0)
                {
                    integral += 2 * nextValue;
                }
                else
                {
                    integral += 4 * nextValue;
                }
            }
            return integral;
        }
        public static double IntegrateSimpsons3(Func<double, double> function, double start, double end, int increments)
        {
            double integral = 0;
            for (int i = 0; i <= increments; i++)
            {
                double nextValue = 3 * function(start + i * (end - start) / increments) * (end - start) / increments / 8;
                if (i == 0 || i == increments)
                {
                    integral += nextValue;
                }
                else if (i % 3 == 0)
                {
                    integral += nextValue;
                }
                else
                {
                    integral += 3 * nextValue;
                }
            }
            return integral;
        }
        public static decimal IntegrateTrapesium(Func<decimal, decimal> function, decimal start, decimal end, int increments)
        {
            decimal integral = 0;
            for (int i = 0; i <= increments; i++)
            {
                decimal nextValue = function(start + i * (end - start) / increments) * (end - start) / increments;
                if (i == 0 || i == increments)
                {
                    integral += nextValue / 2;
                }
                else
                {
                    integral += nextValue;
                }
            }
            return integral;
        }
        public static decimal IntegrateSimpsons2(Func<decimal, decimal> function, decimal start, decimal end, int increments)
        {
            decimal integral = 0;
            for (int i = 0; i <= increments; i++)
            {
                decimal nextValue = function(start + i * (end - start) / increments) * (end - start) / (3 * increments);
                if (i == 0 || i == increments)
                {
                    integral += nextValue;
                }
                else if (i % 2 == 0)
                {
                    integral += 2 * nextValue;
                }
                else
                {
                    integral += 4 * nextValue;
                }
            }
            return integral;
        }
        public static decimal IntegrateSimpsons3(Func<decimal, decimal> function, decimal start, decimal end, int increments)
        {
            decimal integral = 0;
            for (int i = 0; i <= increments; i++)
            {
                decimal nextValue = 3 * function(start + i * (end - start) / increments) * (end - start) / increments / 8;
                if (i == 0 || i == increments)
                {
                    integral += nextValue;
                }
                else if (i % 3 == 0)
                {
                    integral += nextValue;
                }
                else
                {
                    integral += 3 * nextValue;
                }
            }
            return integral;
        }
        public static Func<double, double> Derivative(Func<double, double> function, double epsilon)
        {
            return x => ((x + epsilon) - function(x - epsilon)) / (2 * epsilon);
        }
        public static Func<decimal, decimal> Derivative(Func<decimal, decimal> function, decimal epsilon)
        {
            return x => ((x + epsilon) - function(x - epsilon)) / (2 * epsilon);
        }
    }
}
