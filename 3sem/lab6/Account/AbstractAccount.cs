using System;
namespace lab6
{
    public abstract class AbstractAccount
    {
        public AbstractAccount(){}
        public AbstractAccount(Client client){
            Client = client;
        }
        public AbstractAccount(Client client,float money)
        {
            this.Money = money;
            Client = client;
        }
        
        public float Money { get; protected set; }
        public Client Client { get; }
        public abstract void Withdraw(float money);
        public virtual void Replenish(float money)
        {
            Money += money;
        }
        public virtual void Transfer(AbstractAccount account, float money)
        {
            if (!(Client == account.Client))
            {
                throw new NotYourAccountException();
            }

            try
            {
                Withdraw(money);
                account.Replenish(money);
            }
            catch (NotEnoughException e)
            {
                Console.WriteLine(e);
            }
            catch (NotExpiredYet e)
            {
                Console.WriteLine(e);
            }
        }
    }
}