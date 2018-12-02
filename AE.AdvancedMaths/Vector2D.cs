using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AE.AdvancedMaths
{
    public class Vector2D
    {
        Vector compositionVector;
        public Vector2D()
        {
            this.compositionVector = new Vector(3);
        }
        public Vector2D(double x, double y)
        {
            this.compositionVector = new Vector(new double[] { x, y });
        }
        private Vector2D(Vector compositionVector)
        {
            this.compositionVector = new Vector(new double[] { x, y });
        }
        public double x
        {
            get
            {
                return this.compositionVector.elements[0];
            }
            set
            {
                this.compositionVector.elements[0] = value;
            }
        }
        public double y
        {
            get
            {
                return this.compositionVector.elements[1];
            }
            set
            {
                this.compositionVector.elements[1] = value;
            }
        }

        public static Vector2D operator +(Vector2D vect1, Vector2D vect2)
        {
            return new Vector2D(vect1.compositionVector + vect2.compositionVector);
        }
        public static Vector2D operator -(Vector2D vect1, Vector2D vect2)
        {
            return new Vector2D(vect1.compositionVector - vect2.compositionVector);
        }
        public static Vector2D operator -(Vector2D vect1)
        {
            return new Vector2D(-vect1.compositionVector);
        }
        public static Vector2D operator *(double scalar, Vector2D vect)
        {
            Vector2D output = new Vector2D(scalar * vect.compositionVector);
            return output;
        }
        public static Vector2D operator *(Vector2D vect, double scalar)
        {
            Vector2D output = new Vector2D(scalar * vect.compositionVector);
            return output;
        }
        public static Vector2D operator /(Vector2D vect, double scalar)
        {
            Vector2D output = new Vector2D(vect.compositionVector / scalar);
            return output;
        }
        public static double operator *(Vector2D vect1, Vector2D vect2)
        {
            return vect1.compositionVector * vect2.compositionVector;
        }
        public double Mod
        {
            get
            {
                return this.compositionVector.Mod;
            }
        }
        public Vector2D UnitVector
        {
            get
            {
                return new Vector2D(this.compositionVector.UnitVector);
            }
        }
        //convert between coordinate systems
        public override string ToString()
        {
            return "{" + x.ToString() + ", " + y.ToString() + "}";
        }
    }
}
