using System;

namespace ConsoleApp1.Exceptions
{
    class ProductNotFoundException : Exception
    {
        public ProductNotFoundException() : base("Product Not Found") { }
    }
}
