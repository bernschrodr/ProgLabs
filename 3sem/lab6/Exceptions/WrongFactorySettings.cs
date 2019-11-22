using System;
namespace lab6
{
    public class WrongFactorySettings : Exception
    {
        public WrongFactorySettings() : base("Wrong Factory Settings") { }
    }
}