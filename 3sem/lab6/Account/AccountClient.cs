namespace lab6
{
    public class AccountClient : AbstractAccount
    {
        public AbstractAccount Account { get; }
        public AccountClient(AbstractAccount account)
        {
            Account = account;
        }

        public AccountClient(AbstractAccount account, Client client) : base(client)
        {
            Account = account;
        }

        public AccountClient(AbstractAccount account, Client client, float money) : base(client, money)
        {
            Account = account;
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
        public override void Transfer(AbstractAccount account, float money)
        {
            if (Account != null)
            {
                Account.Transfer(account, money);
            }
            else
            {
                throw new AccountDoesntExist();
            }
        }

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
    }
}