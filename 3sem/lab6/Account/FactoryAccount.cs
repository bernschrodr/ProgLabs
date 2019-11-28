namespace lab6
{
    public static class FactoryAccount
    {
        public static AbstractAccount CreateAccount(float? percent = null, float? tax = null,
        float? limit = null, int? expiresInDay = null, int? accrualPeriod = null, Client client = null)
        {
            if (client == null)
            {
                throw new WrongFactorySettings();
            }

            AccountType? accountType = null;
            bool accountTypeSelected = false;

            if (!accountTypeSelected && expiresInDay.HasValue && percent.HasValue)
            {
                accountType = AccountType.DepositAccount;
            }

            if (!accountTypeSelected && accrualPeriod.HasValue && percent.HasValue)
            {
                accountType = AccountType.StandartAccount;
            }
            if (!accountTypeSelected && tax.HasValue && limit.HasValue)
            {
                accountType = AccountType.CreditAccount;
            }
            if (!accountType.HasValue)
            {
                throw new WrongFactorySettings();
            }

            switch (accountType)
            {
                case AccountType.DepositAccount:
                    return new DepositAccount(expiresInDay.Value, percent.Value, client);
                case AccountType.StandartAccount:
                    return new StandartAccount(percent.Value, accrualPeriod.Value, client);
                case AccountType.CreditAccount:
                    return new CreditAccount(tax.Value, limit.Value, client);
                default:
                    throw new WrongFactorySettings();
            };
        }
    }
}