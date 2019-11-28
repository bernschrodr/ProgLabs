using System;
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

            AccountType accountType = AccountType.DoesntMatch;
            bool accountTypeSelected = false;

            if(!accountTypeSelected && expiresInDay.HasValue && percent.HasValue){
                accountType = AccountType.DepositAccount;
            }
            
            if(!accountTypeSelected && accrualPeriod.HasValue && percent.HasValue){
                accountType = AccountType.StandartAccount;
            }
            if(!accountTypeSelected && tax.HasValue && limit.HasValue){
                accountType = AccountType.CreditAccount;
            }
            
            if (accountType == AccountType.DoesntMatch)
            {
                throw new WrongFactorySettings();
            }

            return accountType switch
            {
                AccountType.DepositAccount => new DepositAccount(expiresInDay.Value, percent.Value, client),
                AccountType.StandartAccount => new StandartAccount(percent.Value, accrualPeriod.Value, client),
                AccountType.CreditAccount => new CreditAccount(tax.Value, limit.Value, client),
                _ => throw new WrongFactorySettings(),
            };
        }
    }
}