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
            string accountType = "";
            for (var i = 0; i < 1; i++)
            {


                accountType = accountType == "" && expiresInDay != null && percent != null
                            ? "Deposit"
                            : "";
                if (accountType != "") { break; }
                accountType = accountType == "" && accrualPeriod != null && percent != null
                            ? "Standart"
                            : "";
                if (accountType != "") { break; }
                accountType = accountType == "" && tax != null && limit != null
                            ? "Credit"
                            : "";
                if (accountType != "") { break; }

            }
            if (accountType == "")
            {
                throw new WrongFactorySettings();
            }

            return accountType switch
            {
                "Deposit" => new DepositAccount((int)expiresInDay, (float)percent, client),
                "Standart" => new StandartAccount((float)percent, (int)accrualPeriod, client),
                "Credit" => new CreditAccount((float)tax, (float)limit, client),
                _ => throw new WrongFactorySettings(),
            };
        }
    }
}