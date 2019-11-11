using System;

namespace ConsoleApp1.Exceptions
{
    public class ProductNotEnoughException : Exception
    {
        public ProductNotEnoughException() : base("Not enough Products") { }
    }
}
