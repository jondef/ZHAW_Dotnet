using System;

using DN4;


namespace DN5 {
    
    public class Program {
        public delegate void MyDelegate(string message);
    
        // Static Method
        public static void MyStaticMethod(string message) {
            Console.WriteLine(message);
        }

        // Instance Method
        public void MyInstanceMethod(string message) {
            Console.WriteLine(message);
        }

        public static void Main() {
            // Static Method
            MyDelegate myDelegate = MyStaticMethod;
            myDelegate("Hello, World!");

            // Instance Method
            Program program = new Program();
            myDelegate = program.MyInstanceMethod;
            myDelegate("Hello, World!");
        }
    }
}
