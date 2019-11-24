using System;
using System.IO;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Data.SqlClient;



namespace lab5
{
    [Serializable]
    public class Triangle : ISerialize
    {
        public Vector2D A { get; set; }
        public Vector2D B { get; set; }
        public Vector2D C { get; set; }

        public Triangle() { }
        public Triangle(Vector2D a, Vector2D b, Vector2D c)
        {
            A = a;
            B = b;
            C = c;
        }

        public void Clone(Triangle triangle)
        {
            A = triangle.A;
            B = triangle.B;
            C = triangle.C;
        }

        public void XmlSerialize(StreamWriter filename)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Triangle));
            serializer.Serialize(filename, this);
        }

        public void XmlDeserialize(StreamReader filename)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Triangle));
            if (!(serializer.Deserialize(filename) is Triangle serializedTriange))
            {
                throw new BadFileException();
            }
            Clone(serializedTriange);
        }

        public void BinSerialize(FileStream filename)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(filename, this);

        }

        public void BinDeserialize(FileStream filename)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            if (!(formatter.Deserialize(filename) is Triangle triangle))
            {
                throw new BadFileException();
            }
            Clone(triangle);
        }

        public void DBSerialize(string connectionString, int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO SerializeDB.dbo.Triangles (Id,A,B,C) VALUES ({id}, '{A.x},{A.y}', '{B.x},{B.y}', '{C.x},{C.y}')";
                SqlCommand command = new SqlCommand(query,connectionString);
            };
        }


        public void DBDeserialize(string connectionString)
        {

        }

        public static bool operator !=(Triangle left, Triangle right)
        {
            if (left.A == right.A && left.B == right.B && left.C == right.C)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public static bool operator ==(Triangle left, Triangle right)
        {
            if (left.A == right.A && left.B == right.B && left.C == right.C)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}