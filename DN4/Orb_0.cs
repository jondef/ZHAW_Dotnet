using System;
using System.Collections.Generic;
using System.Drawing;
using DN3;

namespace DN4 {
	
    public abstract class Orb {
        public const double G = 30; //6.673e-11
        
        private const double dt = 1.5;
        protected Bitmap bitmap;
        
        private Vector pos;
        private Vector v;
        private string name;
        private double mass;

        public Vector Pos {
            // TODO Implement
        }
		
        public Vector Velocity {
            // TODO Implement
        }
		
        public double Mass { 
            // TODO Implement
        }
		
        public string Name { 
            // TODO Implement
        }
			
        public abstract void Draw(Graphics g);
		
        public Orb(string name,double x, double y, double vx, double vy, double m) {
            if (name != "") {
                bitmap = (Bitmap)Image.FromFile(name+".gif");
                bitmap.MakeTransparent(bitmap.GetPixel(1, 1));
            }
            Pos = new Vector(x,y,0);
            v = new Vector(vx,vy,0);
            mass = m;
            this.name = name;
        }
		
        public virtual void CalcVelocity(IList<Orb> space) {
            Vector a = new Vector(0,0,0); //für Gesamtbeschleunigung
            // TODO Implement
            v = v + a;
        }
		
        public void Move() {
            Pos += v * dt;
        }
		
        public override string ToString() {
            return name;
        }
		

		
    }
}