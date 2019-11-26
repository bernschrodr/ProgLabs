namespace lab6
{
    public class AccrueInterestHandler : AbstractHandler
    {
        public override object Handle(object request)
        {
            if (request is DepositAccount)
            {
                var account = request as DepositAccount;
                account.Replenish(account.Money * account.Percent);
                return NextHandler.Handle(request);
            }
            else
            {
                if (request is StandartAccount)
                {
                    var account = request as StandartAccount;
                    account.Replenish(account.Money * account.Percent);
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
}