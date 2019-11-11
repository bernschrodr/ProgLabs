using System;

namespace ConsoleApp1.Exceptions
{
    public class ProductNotFoundException : Exception
    {
        public ProductNotFoundException() : base("Product Not Found") { }
    }
}
