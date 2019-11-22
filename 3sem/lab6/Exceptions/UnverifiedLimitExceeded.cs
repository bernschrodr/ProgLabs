using System;
namespace lab6
{
    public class UnverifiedLimitExceeded : Exception
    {
        public UnverifiedLimitExceeded() : base("Unverified Limit Exceeded") { }
    }
}