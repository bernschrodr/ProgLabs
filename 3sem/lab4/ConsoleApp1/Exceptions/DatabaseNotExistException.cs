using System;

namespace ConsoleApp1.Exceptions
{
    public class DatabaseNotExistException : Exception
    {
        public DatabaseNotExistException() : base("Database doesn't exist") { }
    }
}
