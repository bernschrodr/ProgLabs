using System;

namespace ConsoleApp1.Exceptions
{
    public class ShopNotFoundException : Exception
    {
        public ShopNotFoundException() : base("Shop Not Found") { }
    }
}
