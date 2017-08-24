using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AE.AdvancedMaths
{
    public class Vector3D
    {
        public double x, y, z;

        public static Vector3D operator +(Vector3D vect1, Vector3D vect2)
        {
            Vector3D output = new Vector3D();
            output.x = vect1.x + vect2.x;
            output.y = vect1.y + vect2.y;
            output.z = vect1.z + vect2.z;
            return output;
        }
        public static Vector3D operator -(Vector3D vect1, Vector3D vect2)
        {
            Vector3D output = new Vector3D();
            output.x = vect1.x - vect2.x;
            output.y = vect1.y - vect2.y;
            output.z = vect1.z - vect2.z;
            return output;
        }
        public static Vector3D operator *(double scalar, Vector3D vect)
        {
            Vector3D output = new Vector3D();
            output.x = scalar * vect.x;
            output.y = scalar * vect.y;
            output.z = scalar * vect.z;
            return output;
        }
        public static Vector3D operator /(Vector3D vect, double scalar)
        {
            Vector3D output = new Vector3D();
            output.x = vect.x / scalar;
            output.y = vect.y / scalar;
            output.z = vect.z / scalar;
            return output;
        }
        public double DotProduct(Vector3D vect1, Vector3D vect2)
        {
            return vect1.x * vect2.x + vect1.y * vect2.y + vect1.z * vect2.z;
        }
        public Vector3D CrossProduct(Vector3D vect1, Vector3D vect2)
        {
            Vector3D output = new Vector3D();
            output.x = vect1.y * vect2.z - vect1.z * vect2.y;
            output.y = vect1.z * vect2.x - vect1.x * vect2.z;
            output.z = vect1.x * vect2.y - vect1.y * vect2.x;
            return output;
        }
        double Mod
        {
            get
            {
                return Math.Sqrt(x * x + y * y + z * z);
            }
        }
        public Vector3D UnitVector(Vector3D vect)
        {
            Vector3D output = new Vector3D();
            output.x = vect.x / Mod(vect);
            output.y = vect.y / Mod(vect);
            output.z = vect.z / Mod(vect);
            return output;
        }
        //convert between coordinate systems
        //ToString override
    }
}
