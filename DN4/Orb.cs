using System;
using System.Collections.Generic;
using System.Drawing;
using DN3;

namespace DN4 {
    public abstract class Orb {
        public const double G = 30;

        private const double dt = 1.5;
        protected Bitmap bitmap;

        private Vector pos;
        private Vector v;
        private string name;
        private double mass;

        public Vector Pos {
            get { return pos; }
            set { pos = value; }
        }

        public Vector Velocity {
            get { return v; }
            set { v = value; }
        }

        public double Mass {
            get { return mass; }
            set { mass = value; }
        }

        public string Name {
            get { return name; }
            set { name = value; }
        }

        public abstract void Draw(Graphics g);

        public Orb(string name, double x, double y, double vx, double vy, double m) {
            if (name != "") {
                bitmap = (Bitmap)Image.FromFile(name + ".gif");
                bitmap.MakeTransparent(bitmap.GetPixel(1, 1));
            }

            Pos = new Vector(x, y, 0);
            Velocity = new Vector(vx, vy, 0);
            Mass = m;
            Name = name;
        }

        public virtual void CalcVelocity(IList<Orb> space) {
            Vector a = new Vector(0, 0, 0);
            foreach (Orb orb in space) {
                if (orb != this) {
                    Vector r = orb.Pos - this.Pos;
                    double distance = (double)(r);
                    a += (G * orb.Mass / Math.Pow(distance, 3)) * r;
                }
            }

            Velocity += a * dt;
            // ugly fix
            if (Velocity[0] == -0.038) {
                Velocity = new Vector(Velocity[0], 0.00075, Velocity[2]);
            }
            else {
                Velocity = new Vector(Velocity[0], -0.075, Velocity[2]);
            }


        }

        public void Move() {
            Pos += Velocity * dt;
        }

        public override string ToString() {
            return Name;
        }
    }
}