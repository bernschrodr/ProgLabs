namespace lab6
{
    public class UnverifiedDecoratorAccount : DecoratorAccount
    {
        public bool Verified { get; private set; }
        public float? UnverifiedLimit { get; private set; }
        public UnverifiedDecoratorAccount(AbstractAccount account,
                                          float? unverifiedLimit = null) : base(account)
        {
            UnverifiedLimit = unverifiedLimit;
            if (account.Client.Passport == null || account.Client.Adress == "")
            {
                Verified = false;
            }
            else
            {
                Verified = true;
            }
        }

        public UnverifiedDecoratorAccount(AbstractAccount account,
                                          Client client,
                                          float? unverifiedLimit = null) : base(account, client)
        {
            UnverifiedLimit = unverifiedLimit;
            if (account.Client.Passport == null || account.Client.Adress == "")
            {
                Verified = false;
            }
            else
            {
                Verified = true;
            }
        }

        public UnverifiedDecoratorAccount(AbstractAccount account,
                                          Client client,
                                          float money,
                                          float? unverifiedLimit = null) : base(account, client, money)
        {
            UnverifiedLimit = unverifiedLimit;
            if (account.Client.Passport == null || account.Client.Adress == "")
            {
                Verified = false;
            }
            else
            {
                Verified = true;
            }
        }
        override public void Withdraw(float money)
        {
            if (!Verified && money > UnverifiedLimit)
            {
                throw new UnverifiedLimitExceeded();
            }
            else
            {
                base.Withdraw(money);
            }
        }

        override public void Transfer(AbstractAccount Account, float money)
        {
            if (!Verified && money > UnverifiedLimit)
            {
                throw new UnverifiedLimitExceeded();
            }
            else
            {
                base.Transfer(Account, money);
            }
        }

    }
}