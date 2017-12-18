using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace HelloWorldDeserialization
{
    class Program
    {
        static void Main(string[] args)
        {
            using (FileStream fs = new FileStream("d:\\serialized.dat", FileMode.Create))
            {
                Message myMessage = new Message();
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(fs, myMessage);
                System.Console.WriteLine("Initial Message: " + myMessage.message);
            }            
        }
    }
}
