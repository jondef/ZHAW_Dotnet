using System;
using System.Reflection;

namespace DN8 {
    
    class Source {
        public string S1;
        public int I1;
        public int X;
        
        public Source(string s1, int i1, int x) {
            this.S1 = s1;
            this.I1 = i1;
            this.X = x;
        }
        
        public override String ToString() {
            return String.Format("{0} {1} {2}",S1,I1,X);
        }
    }
    
    class Target {
        public string S1;
        public int I1;
        public string X;
    
        public override String ToString() {
            return String.Format("{0} {1} {2}",S1,I1,X);
        }
    }
    
    public class Copy {
        public static void copyCorresponding(object source, object target) {
            if (source == null || target == null) {
                throw new ArgumentNullException("Source und Target dürfen nicht null sein.");
            }
            
            var sourceFields = source.GetType().GetFields(BindingFlags.Public | BindingFlags.Instance);
            var targetFields = target.GetType().GetFields(BindingFlags.Public | BindingFlags.Instance);
            
            foreach (var sourceField in sourceFields) {
                var targetField = Array.Find(targetFields, f => f.Name == sourceField.Name);
                
                if (targetField != null && targetField.FieldType == sourceField.FieldType)
                    targetField.SetValue(target, sourceField.GetValue(source));
            }
        }
        
        public static void Main(string[] s) {
            object source = new Source("Hello",42,99);
            object target = new Target();
            copyCorresponding(source, target);
            Console.WriteLine("Source: "+source);
            Console.WriteLine("Target: "+target);
        } 
    }
}