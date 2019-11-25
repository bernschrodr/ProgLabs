using System;
namespace lab5
{
    public class BadFileException : Exception
    {
        public BadFileException() : base("Bad File") { }
    }
}