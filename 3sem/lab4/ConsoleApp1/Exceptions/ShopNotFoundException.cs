using System;

namespace ConsoleApp1.Exceptions
{
    class ShopNotFoundException : Exception
    {
        public ShopNotFoundException() : base("Shop Not Found") { }
    }
}
