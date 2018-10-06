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

        public Vector(int size)
        {
            this.size = size;
            this.elements = new double[size];
        }
        public Vector(double[] elements)
        {
            size = elements.Length;
            this.elements = elements;
        }
        public static Vector operator +(Vector vect1, Vector vect2)
        {
            if(vect1.size != vect2.size)
            {
                throw new InvalidOperationException("vectors are different dimensions");
            }
            Vector output = new Vector (vect1.size);
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
            Vector output = new Vector (vect1.size );
            output.elements = new double[output.size];
            for (int i = 0; i < vect1.size; i++)
            {
                output.elements[i] = vect1.elements[i] - vect2.elements[i];
            }
            return output;
        }
        public static Vector operator -(Vector vect)
        {
            Vector output = new Vector(vect.size);
            output.elements = new double[output.size];
            for (int i = 0; i < vect.size; i++)
            {
                output.elements[i] = -vect.elements[i];
            }
            return output;
        }
        public static Vector operator *(double scalar, Vector vect)
        {
            Vector output = new Vector(vect.size);
            output.elements = new double[output.size];
            for (int i = 0; i < vect.size; i++)
            {
                output.elements[i] = scalar * vect.elements[i];
            }
            return output;
        }
        public static Vector operator *(Vector vect, double scalar)
        {
            return scalar * vect;
        }

        public static double operator *(Vector vect1, Vector vect2)
        {
            double output = 0;
            for (int i = 0; i < vect1.size; i++)
            {
                output += vect1.elements[i] * vect2.elements[i];
            }
            return output;
        }
        public static Vector operator /(Vector vect, double scalar)
        {
            Vector output = new Vector(vect.size);
            for (int i = 0; i < vect.size; i++)
            {
                output.elements[i] = vect.elements[i] / scalar;
            }
            return output;
        }
       
        public double Mod
        {
            get
            {
                double mod = 0;
                for (int i = 0; i < size; i++)
                {
                    mod += Math.Pow(elements[i], 2);
                }
                mod = Math.Sqrt(mod);
                return mod;
            }
            
        }
        public Vector UnitVector
        {
            get
            {
                Vector output = new Vector (size);
                for(int i = 0; i < size; i++)
                {
                    output.elements[i] = elements[i] / Mod;
                }
                return output;
            }
            
        }
        public override string ToString()
        {
            string output = "{";
            for(int i = 0; i < size; i++)
            {
                output += elements[i];
                output += ", ";
            }
            output += "}";
            return output;
        }

        public static Func<Vector, Vector> Grad(Func<Vector, double> field, double epsilon)
        {
            return v =>
            {
                Vector v1 = new Vector(v.elements);
                Vector v2 = new Vector(v.elements);
                Vector v3 = new Vector(v.size);
                for (int i = 0; i < v.size; i++)
                {
                    v1.elements[i] -= epsilon;
                    v1.elements[i] += epsilon;
                    v3.elements[i] = field(v2) - field(v1) / (2 * epsilon);
                }
                return v3;
            };
        }

        public static Func<Vector, double> Divergence(Func<Vector, double> field, double epsilon)
        {
            return v =>
            {
                Vector v1 = new Vector(v.elements);
                Vector v2 = new Vector(v.elements);
                double div = 0;
                for (int i = 0; i < v.size; i++)
                {
                    v1.elements[i] -= epsilon;
                    v1.elements[i] += epsilon;
                    div += field(v2) - field(v1) / (2 * epsilon);
                }
                return div;
            };
        }
    }
}
