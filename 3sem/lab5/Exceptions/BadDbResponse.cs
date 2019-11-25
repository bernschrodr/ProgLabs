using System;
namespace lab5
{
    public class BadDbResponse : Exception
    {
        public BadDbResponse() : base("Bad Response") { }
    }
}