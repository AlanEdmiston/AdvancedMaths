using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AE.AdvancedMaths
{
    public class Vector
    {
        public int size;
        public double[] elements;

        void main()
        {
            elements = new double[size];
        }

        public static Vector operator +(Vector vect1, Vector vect2)
        {
            if(vect1.size != vect2.size)
            {
                throw new InvalidOperationException("vectors are different dimensions");
            }
            Vector output = new Vector { size = vect1.size};
            output.elements = new double[output.size];
            for (int i = 0; i < vect1.size; i++)
            {
                output.elements[i] = vect1.elements[i] + vect2.elements[i];
            }
            return output;
        }
        public static Vector operator -(Vector vect1, Vector vect2)
        {
            if (vect1.size != vect2.size)
            {
                throw new InvalidOperationException("vectors are different dimensions");
            }
            Vector output = new Vector { size = vect1.size };
            output.elements = new double[output.size];
            for (int i = 0; i < vect1.size; i++)
            {
                output.elements[i] = vect1.elements[i] - vect2.elements[i];
            }
            return output;
        }
        public static Vector operator *(double scalar, Vector vect)
        {
            Vector output = new Vector();
            output.elements = new double[output.size];
            for (int i = 0; i < vect.size; i++)
            {
                output.elements[i] = scalar * vect.elements[i];
            }
            return output;
        }
        public static Vector operator /(Vector vect, double scalar)
        {
            Vector output = new Vector();
            for (int i = 0; i < vect.size; i++)
            {
                output.elements[i] = vect.elements[i] / scalar;
            }
            return output;
        }

        public double DotProduct(Vector vect1, Vector vect2)
        {
            double output = 0;
            for (int i = 0; i < vect1.size; i++)
            {
                output += vect1.elements[i] * vect2.elements[i];
            }
            return output;
        }
        public double Mod(Vector vect)
        {
            double mod = 0;
            for (int i = 0; i < vect.size; i++)
            {
                mod += Math.Pow(vect.elements[i], 2);
            }
            mod = Math.Sqrt(mod);
            return mod;
        }
        public Vector UnitVector(Vector vect)
        {
            Vector output = new Vector();
            for(int i = 0; i < vect.size; i++)
            {
                output.elements[i] = vect.elements[i] / Mod(vect);
            }
            return output;
        }
        //convert between coordinate systems
        //tostring override
    }
}
