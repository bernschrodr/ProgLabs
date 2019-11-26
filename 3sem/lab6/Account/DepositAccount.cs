using System;
namespace lab6
{
    public class DepositAccount : AbstractAccount
    {
        public DepositAccount(int expires, float percent, Client client) : base(client)
        {
            Expires = new DateTime(DateTime.Now.Ticks + expires * TimeSpan.TicksPerDay);
            Percent = percent;
        }
        public DepositAccount(int expires)
        {
            /*
            Добавляем к времени в данный момент время, через которое можно будет снять деньги
            и конвертируем все значения в тики
            */
            Expires = new DateTime(DateTime.Now.Ticks + expires * TimeSpan.TicksPerDay);
        }
        public float Percent { get; }
        public DateTime Expires { get; }
        override public void Withdraw(float money)
        {
            if (this.Money - money < 0)
            {
                throw new NotEnoughException();
            }
            if (this.Expires > DateTime.Now)
            {
                throw new NotExpiredYet();
            }
            this.Money -= money;
        }
    }
}