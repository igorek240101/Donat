using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonatAbstract
{
    public struct Vector
    {
        int x;
        int y;
        int z;

        public Vector(int x, int y, int z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }
        public int Z { get => z; set => z = value; }

        public static Vector operator -(Vector vector) => new Vector(-vector.x, -vector.y, -vector.z);
        public static Vector operator +(Vector vector1, Vector vector2) => new Vector(vector1.x + vector2.x, vector1.y + vector2.y, vector1.z + vector2.z);
        public static Vector operator -(Vector vector1, Vector vector2) => new Vector(vector1.x - vector2.x, vector1.y - vector2.y, vector1.z - vector2.z);
        public static Vector operator *(Vector vector, double m) => new Vector((int)Math.Round(vector.x * m), (int)Math.Round(vector.y * m), (int)Math.Round(vector.z * m));

        public Vector Abs() => new Vector(Math.Abs(x), Math.Abs(y), Math.Abs(z));

        public double Distance() => Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2) + Math.Pow(z, 2));

        public static double Distance(Vector vector1, Vector vector2) => Math.Sqrt(Math.Pow(vector1.x - vector2.x, 2) + Math.Pow(vector1.y - vector2.y, 2) + Math.Pow(vector1.z - vector2.z, 2));
    }
}
