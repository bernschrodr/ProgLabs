namespace lab6
{
    public class WithdrawTaxHandler : AbstractHandler
    {
        public override object Handle(object request)
        {
            if (request is CreditAccount)
            {
                var account = request as CreditAccount;
                account.Withdraw(account.Tax);
                return NextHandler.Handle(request);
            }
            else
            {
                return base.Handle(request);
            }
        }
    }
}