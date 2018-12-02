using System;

namespace AE.AdvancedMaths
{
    public class Vector3D
    {
        Vector compositionVector;
        public Vector3D()
        {
            this.compositionVector = new Vector(3);
        }
        public Vector3D(double x, double y, double z)
        {
            this.compositionVector = new Vector(new double[] { x, y, z });
        }

        private Vector3D(Vector compositionVector)
        {
            this.compositionVector = compositionVector;
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
        public double z
        {
            get
            {
                return this.compositionVector.elements[2];
            }
            set
            {
                this.compositionVector.elements[2] = value;
            }
        }

        public static Vector3D operator +(Vector3D vect1, Vector3D vect2)
        {
            return new Vector3D(vect1.compositionVector + vect2.compositionVector);
        }
        public static Vector3D operator -(Vector3D vect1, Vector3D vect2)
        {
            Vector newVect = vect1.compositionVector - vect2.compositionVector;
            return new Vector3D(newVect);
        }
        public static Vector3D operator -(Vector3D vect1)
        {
            return new Vector3D(-vect1.compositionVector);
        }
        public static Vector3D operator *(double scalar, Vector3D vect)
        {
            Vector3D output = new Vector3D(scalar * vect.compositionVector);
            return output;
        }
        public static Vector3D operator *(Vector3D vect, double scalar)
        {
            Vector3D output = new Vector3D(scalar * vect.compositionVector);
            return output;
        }
        public static Vector3D operator /(Vector3D vect, double scalar)
        {
            Vector3D output = new Vector3D(vect.compositionVector / scalar);
            return output;
        }
        public static double operator *(Vector3D vect1, Vector3D vect2)
        {
            return vect1.compositionVector * vect2.compositionVector;
        }
        public static Vector3D CrossProduct(Vector3D vect1, Vector3D vect2)
        {
            Vector3D output = new Vector3D(vect1.y * vect2.z - vect1.z * vect2.y,
                                           vect1.z * vect2.x - vect1.x * vect2.z,
                                           vect1.x * vect2.y - vect1.y * vect2.x);
            return output;
        }
        public double Mod
        {
            get
            {
                return this.compositionVector.Mod;
            }
        }
        public Vector3D UnitVector
        {
            get
            {
                return new Vector3D(this.compositionVector.UnitVector);
            }
        }
        public override string ToString()
        {
            return "{" + x.ToString() + ", " + y.ToString() + ", " + z.ToString() + "}";
        }

        public static Func<Vector3D, Vector3D> Curl(Func<Vector3D, double> field, double epsilon)
        {
            return v =>
            {
                //z-y
                //x-z
                //y-x
                return new Vector3D(
                    field(v + new Vector3D(0, 0, epsilon)) - field(v - new Vector3D(0, 0, epsilon)) - (field(v + new Vector3D(0, epsilon, 0)) - field(v - new Vector3D(0, epsilon, 0))),
                    field(v + new Vector3D(epsilon, 0, 0)) - field(v - new Vector3D(epsilon, 0, 0)) - (field(v + new Vector3D(0, 0, epsilon)) - field(v - new Vector3D(0, 0, epsilon))),
                    field(v + new Vector3D(0, epsilon, 0)) - field(v - new Vector3D(0, epsilon, 0)) - (field(v + new Vector3D(epsilon, 0, 0)) - field(v - new Vector3D(epsilon, 0, 0)))) / (2 * epsilon);
            };
        }
    }
}
