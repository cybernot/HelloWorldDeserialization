using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.Collections.Generic;

namespace DCDeserializer
{
    class Program
    {
        static void Main(string[] args)
        {
            using (FileStream fs = new FileStream("c:\\temp\\serialized.dat", FileMode.Open))
            {
                StreamReader reader = new StreamReader(fs);
                
                List<object> myList = new List<object>();
                DataContractSerializer serializer = new DataContractSerializer(myList.GetType());
                myList = (List<object>)serializer.ReadObject(fs);
                foreach (var item in myList)
                    Console.WriteLine("Item: " + item.ToString());
            }
        System.Console.WriteLine("Waiting for your input to continue");
        System.Console.ReadLine();
        }
    }
}
