using System;
namespace lab6
{
    public class FactoryAccount
    {
        public AbstractAccount CreateAccount(float? percent = null, float? tax = null,
        float? limit = null, int? expiresInDay = null, int? accrualPeriod = null)
        {
            string accountType = "";
            accountType = accountType == "" && expiresInDay != null && percent != null
                        ? "Deposit"
                        : "";
            accountType = accountType == "" && accrualPeriod != null && percent != null
                        ? "Standart"
                        : "";
            accountType = accountType == "" && tax != null && limit != null
                        ? "Credit"
                        : "";

            if (accountType == "")
            {
                throw new WrongFactorySettings();
            }

            return accountType switch
            {
                "Deposit" => new DepositAccount((int)expiresInDay),
                "Standart" => new StandartAccount((float)percent, (int)accrualPeriod),
                "Credit" => new CreditAccount((float)tax, (float)limit),
                _ => throw new WrongFactorySettings(),
            };
        }
    }
}