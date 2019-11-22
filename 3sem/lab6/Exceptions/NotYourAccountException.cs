using System;
namespace lab6
{
    public class NotYourAccountException : Exception
    {
        public NotYourAccountException():base("Not Your Account"){}
    }
}