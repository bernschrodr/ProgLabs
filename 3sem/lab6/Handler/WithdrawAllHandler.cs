namespace lab6
{
    public class WithdrawAllHandler : AbstractHandler
    {
        public override object Handle(object request)
        {
            if (request is CreditAccount || request is DepositAccount || request is StandartAccount)
            {
                var account = request as AbstractAccount;
                account.Withdraw(account.Money);
                if (NextHandler != null)
                {
                    return NextHandler.Handle(request);
                }
                else
                {
                    return account;
                }
            }
            else
            {
                return base.Handle(request);
            }
        }
    }
}