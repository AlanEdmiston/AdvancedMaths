using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AE.AdvancedMaths
{
    public class ComplexVector
    {
        public int size;
        Complex[] elements;
        void main()
        {
            elements = new Complex[size];
        }

        public static ComplexVector operator +(ComplexVector vect1, ComplexVector vect2)
        {
            ComplexVector output = new ComplexVector();
            for (int i = 0; i < vect1.size; i++)
            {
                output.elements[i] = vect1.elements[i] + vect2.elements[i];
            }
            return output;
        }
        public static ComplexVector operator -(ComplexVector vect1, ComplexVector vect2)
        {
            ComplexVector output = new ComplexVector();
            for (int i = 0; i < vect1.size; i++)
            {
                output.elements[i] = vect1.elements[i] - vect2.elements[i];
            }
            return output;
        }
        public static ComplexVector operator *(Complex scalar, ComplexVector vect)
        {
            ComplexVector output = new ComplexVector();
            for (int i = 0; i < vect.size; i++)
            {
                output.elements[i] = scalar * vect.elements[i];
            }
            return output;
        }
        public static ComplexVector operator /(ComplexVector vect, Complex scalar)
        {
            ComplexVector output = new ComplexVector();
            for (int i = 0; i < vect.size; i++)
            {
                output.elements[i] = vect.elements[i] / scalar;
            }
            return output;
        }

        public Complex DotProduct(ComplexVector vect1, ComplexVector vect2)
        {
            Complex output = new Complex { Im = 0, Re = 0};
            for (int i = 0; i < vect1.size; i++)
            {
                output += vect1.elements[i] * vect2.elements[i];
            }
            return output;
        }

        public ComplexVector Dagger(ComplexVector vect)
        {
            ComplexVector newVect = new ComplexVector();
            newVect.size = vect.size;
            for (int i = 0; i < vect.size; i++)
            {
                newVect.elements[i] = Complex.Conjugate(vect.elements[i]);
            }
            return newVect;
        }
        public double Mod(ComplexVector vect)
        {
            double mod;
            mod = DotProduct(Dagger(vect), vect).Re;
            return mod;
        }
        public ComplexVector Normalise(ComplexVector vect)
        {
            ComplexVector output = new ComplexVector();
            for (int i = 0; i < vect.size; i++)
            {
                output.elements[i] = vect.elements[i] / Complex.ToComplex(Mod(vect));
            }
            return output;
        }
    }
}
