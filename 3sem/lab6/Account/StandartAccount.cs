using System;
namespace lab6
{
    public class StandartAccount : AbstractAccount
    {
        public StandartAccount(float percent, int accrualPeriodInDays,Client client) : base(client)
        {
            Percent = percent;
            AccrualPeriodInDays = accrualPeriodInDays;
            AccrualPeriodInDateTime = new DateTime(DateTime.Now.Ticks + accrualPeriodInDays * TimeSpan.TicksPerDay);
        }
        public float Percent { get; }
        public int AccrualPeriodInDays { get; }
        public DateTime AccrualPeriodInDateTime { get; }
        override public void Withdraw(float money)
        {
            if (this.Money < money)
            {
                throw new NotEnoughException();
            }
            this.Money -= money;
        }
    }
}