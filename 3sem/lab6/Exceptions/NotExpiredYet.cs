using System;
namespace lab6
{
    public class NotExpiredYet : Exception
    {
        public NotExpiredYet() : base("Not Expired Yet") { }
    }
}