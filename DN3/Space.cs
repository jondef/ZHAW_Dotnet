using System;
using System.Collections.Generic;
using System.Text;
using System;
using System.IO;

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
            Vector omega = unitVector * 2 * Math.PI / (24 * 60 * 60);
            omegaEarth = omega;
            omegaSun = omega / 27;
            omegaGalaxy = omega / (24 * 365);
        }
        
        public static void InitRVectors(out Vector rEarth, out Vector rSun, out Vector rGalaxy) {
            Vector unitVector = new Vector(1, 0, 0);
            Vector r = unitVector * 1.5E11;
            rEarth = r;
            rSun = r * 3.3E5;
            rGalaxy = r * 2.5E17;
        }

        public static double CalcSpeed(Vector omegaEarth,Vector omegaSun, Vector omegaGalaxy,Vector rEarth, Vector rSun, Vector rGalaxy) {
            return 0;
        }
    }
}