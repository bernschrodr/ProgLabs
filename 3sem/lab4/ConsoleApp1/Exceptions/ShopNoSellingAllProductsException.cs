using System;

namespace ConsoleApp1.Exceptions
{
    class ShopNoSellingAllProductsException : Exception
    {
        public ShopNoSellingAllProductsException() : base("There are no shops selling these products") { }
    }
}
