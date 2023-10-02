using System;
using System.Collections.Generic;
using System.Text;

namespace DN3 {
    public class Space {
        
        static void Main(string[] args) {
            Vector omegaEarth,omegaSun, omegaGalaxy;
            Vector rEarth, rSun, rGalaxy;
            
            InitOmegaVectors(out omegaEarth,out omegaSun, out omegaGalaxy);
            InitRVectors(out rEarth, out rSun, out rGalaxy);
            double speed = CalcSpeed(omegaEarth,omegaSun, omegaGalaxy,rEarth, rSun, rGalaxy);
            Console.WriteLine("Speed is "+speed+" km/s");
            Console.ReadLine();
        }
        
        public static void InitOmegaVectors(out Vector omegaEarth, out Vector omegaSun, out Vector omegaGalaxy) {
            Vector unitVector = new Vector(0, 1, 0); 
            // Beispielwerte; tatsächliche Werte können je nach Anwendung variieren
            omegaEarth = new Vector(0, 7.27220521664304E-05, 0);  // Rad/s
            omegaSun = new Vector(0, 1.991021277657232E-07, 0);  // Rad/s
            omegaGalaxy = new Vector(0, 8.848983456254364E-16, 0);  // Rad/s
        }
        
        public static void InitRVectors(out Vector rEarth, out Vector rSun, out Vector rGalaxy) {
            Vector unitVector = new Vector(1, 0, 0);
            // Beispielwerte; tatsächliche Werte können je nach Anwendung variieren
            rEarth = new Vector(6370, 0, 0);  // km
            rSun = new Vector(1.496e8, 0, 0);  // km
            rGalaxy = new Vector(2.3650000000000003E+17, 0, 0);  // km
        }

        public static double CalcSpeed(Vector omegaEarth,Vector omegaSun, Vector omegaGalaxy,Vector rEarth, Vector rSun, Vector rGalaxy) {
            Vector vEarth = omegaEarth * rEarth;
            Vector vSun = omegaSun * rSun;
            Vector vGalaxy = omegaGalaxy * rGalaxy;
            
            Vector vTotal = new Vector(
                vEarth[0] + vSun[0] + vGalaxy[0], 
                vEarth[1] + vSun[1] + vGalaxy[1], 
                vEarth[2] + vSun[2] + vGalaxy[2]
            );
            
            return Math.Sqrt(vTotal[0] * vTotal[0] + vTotal[1] * vTotal[1] + vTotal[2] * vTotal[2]);
        }
    }
}