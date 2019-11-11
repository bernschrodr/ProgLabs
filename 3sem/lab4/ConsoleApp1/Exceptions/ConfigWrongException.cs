using System;

namespace ConsoleApp1.Exceptions
{
    public class ConfigWrongException : Exception
    {
        public ConfigWrongException() : base("Wrong Configs") { }
    }
}
