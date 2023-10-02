using System;

namespace DN3 {
    public struct Vector {
        double x, y, z;

        //Konstruktor
        public Vector(double x, double y, double z) {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public override string ToString() {
            //return "["+x+" "+y+" "+z+"]";
            return $"[{x},{y},{z}]";
        }

        public static Vector operator +(Vector a, Vector b) {
            return new Vector(a.x + b.x, a.y + b.y, a.z + b.z);
        }

        public static Vector operator -(Vector a, Vector b) {
            return new Vector(a.x - b.x, a.y - b.y, a.z - b.z);
        }

        public static Vector operator *(Vector a, Vector b) {
            return new Vector(
                a.y * b.z - a.z * b.y,
                a.z * b.x - a.x * b.z,
                a.x * b.y - a.y * b.x
            );
        }

        public static Vector operator *(Vector a, double b) {
            return new Vector(a.x * b, a.y * b, a.z * b);
        }

        public static Vector operator *(double b, Vector a) {
            return new Vector(a.x * b, a.y * b, a.z * b);
        }

        public static Vector operator /(Vector a, double b) {
            return new Vector(a.x / b, a.y / b, a.z / b);
        }

        public double this[int index] {
            get {
                if (index < 0 || index > 2) {
                    throw new IndexOutOfRangeException("Index must be within [0, 2]");
                }

                return index == 0 ? x : index == 1 ? y : z;
            }
            set {
                if (index < 0 || index > 2) {
                    throw new IndexOutOfRangeException("Index must be within [0, 2]");
                }

                if (index == 0) {
                    x = value;
                }
                else if (index == 1) {
                    y = value;
                }
                else {
                    z = value;
                }
            }
        }

        public static explicit operator double(Vector v) {
            return Math.Sqrt(v[0] * v[0] + v[1] * v[1] + v[2] * v[2]);
        }

        public static implicit operator Vector(double s) {
            return new Vector(s, 0, 0);
        }

        // Equality and inequality operators
        public static bool operator ==(Vector a, Vector b) {
            return Math.Abs(a.x - b.x) < 1e-9 && Math.Abs(a.y - b.y) < 1e-9 && Math.Abs(a.z - b.z) < 1e-9;
        }

        public static bool operator !=(Vector a, Vector b) {
            return !(a == b);
        }

        // Override Equals method
        public override bool Equals(object obj) {
            if (obj is Vector) {
                Vector v = (Vector)obj;
                return this == v;
            }
            return false;
        }

        // Override GetHashCode
        public override int GetHashCode() {
            return x.GetHashCode() ^ y.GetHashCode() ^ z.GetHashCode();
        }
    }

    internal class MainClass {
        public static void Test() {
            Vector a = new Vector(1, 2, 3);
            Vector b = new Vector(4, 5, 6);
            Vector c = a * b;
            Console.WriteLine(c);
        }

        public static void Mainn(string[] args) {
            Test();
        }
    }
}