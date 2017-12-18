using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.Collections.Generic;

namespace DCSerializer
{
    class Program
    {
        static void Main(string[] args)
        {
            using (FileStream fs = new FileStream("d:\\serialized.dat", FileMode.Create))
            {
                List<object> myList = new List<object>();
                myList.Add("Hello");
                myList.Add("World");

                DataContractSerializer serializer = new DataContractSerializer(myList.GetType());
                serializer.WriteObject(fs, myList);
                System.Console.WriteLine("Initial Message: " + myList.ToString());
            }
        }
    }
}
