namespace lab6
{
    public abstract class DecoratorAccount : AbstractAccount
    {
        public DecoratorAccount(AbstractAccount account,
                                Client client) : base(client) => Account = account;
        public DecoratorAccount(AbstractAccount account,
                                Client client,
                                float money) : base(client, money) => Account = account;

        public DecoratorAccount(AbstractAccount account) => Account = account;

        public AbstractAccount Account { get; }
        new public Client Client { get => Account.Client; }
        new public float Money { get => Account.Money; }

        public override void Withdraw(float money)
        {
            if (Account != null)
            {
                Account.Withdraw(money);
            }
            else
            {
                throw new AccountDoesntExist();
            }
        }

        public override void Replenish(float money)
        {
            if (Account != null)
            {
                Account.Replenish(money);
            }
            else
            {
                throw new AccountDoesntExist();
            }

        }

        public override void Transfer(AbstractAccount Account,
                                      float money)
        {
            if (Account != null)
            {
                Account.Transfer(Account, money);
            }
            else
            {
                throw new AccountDoesntExist();
            }
        }
    }
}