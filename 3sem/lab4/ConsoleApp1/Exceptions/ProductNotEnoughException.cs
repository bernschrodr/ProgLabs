using System;

namespace ConsoleApp1.Exceptions
{
    class ProductNotEnoughException : Exception
    {
        public ProductNotEnoughException() : base("Not enough Products") { }
    }
}
