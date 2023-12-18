using System;
using System.Collections.Generic;
using System.Drawing;
using DN3;

namespace DN4 {

    public delegate void CollisionHandler(Orb o1);

    public abstract class Orb {

        public event CollisionHandler Collision;
        const double CollisionDistance = 15;
        private const double Dt = 1.5;

        public const double G = 30; //6.673e-11


        protected Bitmap bitmap;

        public Vector Pos { get; set; }

        public Vector Velocity { get; set; }

        public double Mass { get; set; }

        public string Name { get; set; }

        public abstract void Draw(Graphics g);

        public Orb(string name, double x, double y, double vx, double vy, double m) {
            Pos = new Vector(x, y, 0);
            Velocity = new Vector(vx, vy, 0);
            Mass = m;
            Name = name;
        }

        public virtual void CalcVelocity(IList<Orb> space) {
            var initV = new Vector(0, 0, 0);

            foreach (Orb otherOrb in space)
            {
                Thread.Sleep(10);
                if (otherOrb == this) continue;
                var direction = otherOrb.Pos - this.Pos;
                var distance = (double)direction;

                if (distance < CollisionDistance) {
                    Collision?.Invoke(this.Mass < otherOrb.Mass ? this : otherOrb);
                }

                var forceMagnitude = (G * this.Mass * otherOrb.Mass) / (distance * distance);

                var forceDirection = direction / distance; // Normalize the direction vector
                var acceleration = forceDirection * (forceMagnitude / this.Mass);
                initV += acceleration;
            }

            Velocity += initV;
        }

        public void Move() => Pos += Velocity * Dt;

        public override string ToString() => Name;
    }
}