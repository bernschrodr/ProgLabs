namespace lab6
{
    public interface IAccount
    {
         public float Money{get;}
         public void Withdraw(float money);
         public void Replenish(float money);
         public void Transfer();
    }
}