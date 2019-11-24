using System;
using System.IO;

namespace lab5
{
    class Program
    {
        static void Main()
        {
            Triangle tr = new Triangle(new Vector2D(0, 0), new Vector2D(0, 5), new Vector2D(5, 0));
            StreamWriter xmlFileWrite = new StreamWriter("./Triangle.xml");
            tr.XmlSerialize(xmlFileWrite);
            xmlFileWrite.Close();

            Triangle deserializedTriangle = new Triangle();
            StreamReader xmlFileRead = new StreamReader("./Triangle.xml");
            deserializedTriangle.XmlDeserialize(xmlFileRead);
            xmlFileRead.Close();
            string equal = "Objects Equal", notEqual = "Objects Not Equal";

            Console.WriteLine(tr == deserializedTriangle
                                    ? equal
                                    : notEqual);



            FileStream binFileWrite = new FileStream("./Triangle.bin", FileMode.Create);
            tr.BinSerialize(binFileWrite);
            binFileWrite.Close();

            deserializedTriangle = new Triangle();
            FileStream binFileRead = new FileStream("./Triangle.bin", FileMode.Open);
            deserializedTriangle.BinDeserialize(binFileRead);
            binFileRead.Close();

            Console.WriteLine(tr == deserializedTriangle
                                    ? equal
                                    : notEqual);

            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=SerializeDB;";
            tr.DBSerialize(connectionString, 2);

        }
    }
}
