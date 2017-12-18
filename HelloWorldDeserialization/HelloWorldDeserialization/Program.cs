using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace HelloWorldDeserialization
{
    class Program
    {
        static void Main(string[] args)
        {
            using (FileStream fs = new FileStream("d:\\serialized.dat", FileMode.Open))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                Object myDeserializeObject = formatter.Deserialize(fs);
                Message myDeserializedMessage = (Message)myDeserializeObject;
                System.Console.WriteLine("Deserialized Message: " + myDeserializedMessage.message);
            }
            System.Console.WriteLine("Waiting for your input to continue");
            System.Console.ReadLine();
        }
    }
}
