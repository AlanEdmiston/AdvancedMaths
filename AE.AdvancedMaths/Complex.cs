using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AE.AdvancedMaths
{
    public class Complex
    {
        //properties
        public double Re, Im;

        private double[] ReIm
        {
            get
            {
                return new double[2] { Re, Im };
            }
            set
            {
                Re = value[0];
                Im = value[1];
            }
        }
        private double[] ModArg
        {
            get
            {
                var pol = new double[2];
                pol[0] = Math.Sqrt(ReIm[0] * ReIm[0] + ReIm[1] * ReIm[1]);
                if (ReIm[0] > 0)
                {
                    pol[1] = Math.Atan(ReIm[1] / ReIm[0]);
                }
                else if (ReIm[0] < 0)
                {
                    pol[1] = Math.PI / 2 - Math.Atan(ReIm[1] / ReIm[0]);
                }
                else
                {
                    pol[1] = Math.PI / 2;
                }
                return pol;
            }
            set
            {
                ReIm[0] = value[0] * Math.Cos(value[1]);
                ReIm[1] = value[0] * Math.Sin(value[1]);
            }
        }

        public double Modulus
        {
            get
            {
                return ModArg[0];
            }
        }
        public double Argument
        {
            get
            {
                return ModArg[1];
            }
        }

        //basic operations
        public static Complex operator *(Complex comp1, Complex comp2)
        {
            Complex output = new Complex();
            output.ModArg = new double[] { comp1.ModArg[0] * comp2.ModArg[0], comp1.ModArg[1] + comp2.ModArg[1] };
            return output;
        }
        public static Complex operator /(Complex comp1, Complex comp2)
        {
            Complex output = new Complex();
            output.ModArg[0] = comp1.ModArg[0] / comp2.ModArg[0];
            output.ModArg[1] = comp1.ModArg[1] - comp2.ModArg[1];
            return output;
        }
        public static Complex operator +(Complex comp1, Complex comp2)
        {
            Complex output = new Complex();
            output.ReIm[0] = comp1.ReIm[0] + comp2.ReIm[0];
            output.ReIm[1] = comp1.ReIm[1] + comp2.ReIm[1];
            return output;
        }
        public static Complex operator -(Complex comp1, Complex comp2)
        {
            Complex output = new Complex();
            output.ReIm[0] = comp1.ReIm[0] - comp2.ReIm[0];
            output.ReIm[1] = comp1.ReIm[1] - comp2.ReIm[1];
            return output;
        }

        static public Complex Conjugate(Complex comp)
        {
            return new Complex { Re = comp.Re, Im = -comp.Im };
        }

        //powers
        static public Complex Exp(Complex comp)
        {
            Complex output = new Complex
            {
                ModArg = new double[] { Math.Exp(comp.ReIm[0]), comp.ReIm[1] }
            };
            return output;
        }
        static public Complex Ln(Complex comp)
        {
            Complex output = new Complex
            {
                ReIm = new double[] { Math.Log(comp.ModArg[0]), comp.ModArg[1] }
            };

            return output;
        }
        static public Complex operator ^(Complex comp1, Complex comp2)
        {
            Complex output = new Complex();
            output = Ln(comp1);
            output = Exp(comp2 * output);
            return output;
        }
        //trigonometric functions
        public Complex Sin(Complex comp)
        {
            Complex output = new Complex();
            Complex i = new Complex { ReIm = new double[] { 0, 1 } };
            output = (Exp(i * comp) - Exp(ToComplex(-1) * i * comp)) / ToComplex(2);
            return output;
        }
        public Complex Cos(Complex comp)
        {
            Complex output = new Complex();
            Complex i = new Complex { ReIm = new double[] { 0, 1 } };
            output = (Exp(i * comp) + Exp(ToComplex(-1) * i * comp)) / ToComplex(2);
            return output;
        }
        public Complex Tan(Complex comp)
        {
            Complex output = new Complex();
            output = Sin(comp) / Cos(comp);
            return output;
        }
        //hyperbolic functions
        public Complex Sinh(Complex comp)
        {
            Complex output = new Complex();
            output = (Exp(comp) - Exp(ToComplex(-1) * comp)) / ToComplex(2);
            return output;
        }
        public Complex Cosh(Complex comp)
        {
            Complex output = new Complex();
            output = (Exp(comp) + Exp(ToComplex(-1) * comp)) / ToComplex(2);
            return output;
        }
        public Complex Tanh(Complex comp)
        {
            Complex output = new Complex();
            output = Sinh(comp) / Cosh(comp);
            return output;
        }
        static public Complex ToComplex(double real)
        {
            Complex output = new Complex { ReIm = new double[] { real, 0 } };
            return output;
        }

        public override string ToString()
        {
            return $"{ReIm[0]} + {ReIm[1]}i  (modulus = {ModArg[0]}, argument = {ModArg[1]})";
        }
    }
}
