using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AE.AdvancedMaths
{
    public class Complex
    {
        public Complex(double real, double imaginary)
        {
            this.Re = real;
            this.Im = imaginary;
        }
        public Complex()
        {
            this.Re = 0;
            this.Im = 0;
        }
        public static readonly Complex i = new Complex(0, 1);
        //properties
        public double Re, Im;

        private double[] ReIm
        {
            get
            {
                return new double[]{ Re, Im};
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
                Re = value[0] * Math.Cos(value[1]);
                Im = value[0] * Math.Sin(value[1]);
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
        //casts
        public static explicit operator Complex(double x)
        {
            return new Complex(x, 0);
        }
        public static explicit operator Complex(float x)
        {
            return new Complex(x, 0);
        }
        public static explicit operator Complex(int x)
        {
            return new Complex(x, 0);
        }
        public static explicit operator Complex(long x)
        {
            return new Complex(x, 0);
        }
        public static explicit operator Complex(decimal x)
        {
            return new Complex((double)x, 0);
        }
        public static explicit operator double(Complex z)
        {
            if(Math.Abs(z.Im) > 0.000001)
            {
                throw new InvalidCastException("z cannot be cast to a double as it has a non-zero imaginary component");
            }
            return z.Re;
        }

        //basic operations
        public static Complex operator *(Complex comp1, Complex comp2)
        {
            Complex output = new Complex();
            output.ModArg = new double[] { comp1.ModArg[0] * comp2.ModArg[0], comp1.ModArg[1] + comp2.ModArg[1] };
            return output;
        }
        public static Complex operator *(double real, Complex comp2)
        {
            Complex output = new Complex();
            Complex comp1 = (Complex)real;
            output.ModArg = new double[] { comp1.ModArg[0] * comp2.ModArg[0], comp1.ModArg[1] + comp2.ModArg[1] };
            return output;
        }
        public static Complex operator *(Complex comp1, double real)
        {
            Complex output = new Complex();
            Complex comp2 = (Complex)real;
            output.ModArg = new double[] { comp1.ModArg[0] * comp2.ModArg[0], comp1.ModArg[1] + comp2.ModArg[1] };
            return output;
        }
        public static Complex operator /(Complex comp1, Complex comp2)
        {
            if(comp2.Modulus == 0)
            {
                throw new DivideByZeroException();
            }
            Complex output = new Complex();
            output.ModArg = new double[] { comp1.ModArg[0] / comp2.ModArg[0], comp1.ModArg[1] - comp2.ModArg[1] };
            return output;
        }
        public static Complex operator +(Complex comp1, Complex comp2)
        {
            Complex output = new Complex();
            output.Re = comp1.ReIm[0] + comp2.ReIm[0];
            output.Im = comp1.ReIm[1] + comp2.ReIm[1];
            return output;
        }
        public static Complex operator -(Complex comp1, Complex comp2)
        {
            Complex output = new Complex();
            output.Re = comp1.ReIm[0] - comp2.ReIm[0];
            output.Im = comp1.ReIm[1] - comp2.ReIm[1];
            return output;
        }

        static public Complex Conjugate(Complex comp)
        {
            return new Complex (comp.Re, -comp.Im );
        }

        //powers
        static public Complex Exp(Complex comp)
        {
            Complex output = new Complex()
            {
                ModArg = new double[] { Math.Exp(comp.ReIm[0]), comp.ReIm[1] }
            };
            return output;
        }
        static public Complex Ln(Complex comp)
        {
            Complex output = new Complex()
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
            output = (Exp(i * comp) - Exp((Complex)(-1) * i * comp)) / (Complex)2;
            return output;
        }
        public Complex Cos(Complex comp)
        {
            Complex output = new Complex();
            Complex i = new Complex { ReIm = new double[] { 0, 1 } };
            output = (Exp(i * comp) + Exp((Complex)(-1) * i * comp)) / (Complex)2;
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
            output = (Exp(comp) - Exp((Complex)(-1) * comp)) / (Complex)2;
            return output;
        }
        public Complex Cosh(Complex comp)
        {
            Complex output = new Complex();
            output = (Exp(comp) + Exp((Complex)(-1) * comp)) / (Complex)2;
            return output;
        }
        public Complex Tanh(Complex comp)
        {
            Complex output = new Complex();
            output = Sinh(comp) / Cosh(comp);
            return output;
        }

        public override string ToString()
        {
            return $"{ReIm[0]} + {ReIm[1]}i  (modulus = {ModArg[0]}, argument = {ModArg[1]})";
        }
    }
}
