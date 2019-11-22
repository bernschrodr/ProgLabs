using System;
namespace lab6
{
    public class NotEnoughException : Exception
    {
        public NotEnoughException() : base("Not Enough Money"){}
    }
}