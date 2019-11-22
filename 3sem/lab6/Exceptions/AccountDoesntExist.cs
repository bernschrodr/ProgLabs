using System;
namespace lab6
{
    public class AccountDoesntExist : Exception
    {
        public AccountDoesntExist() : base("Account Does Not Exist") { }
    }
}