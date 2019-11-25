using System;
namespace lab5
{
    public class WrongDbData : Exception
    {
        public WrongDbData() : base("Wrong DB Data") { }
    }
}