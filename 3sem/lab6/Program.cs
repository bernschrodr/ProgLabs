using System;

namespace lab6
{
    class Program
    {
        static void Main()
        {
            //Билдер
            ClientBuilder builder = new ClientBuilder();
            builder.Reset();
            builder.SetAdress("Spb,Kronversky 49");
            builder.SetFirstName("Andrey");
            builder.SetPassport(12390213);
            builder.SetSecondName("Ivanov");
            Client client = builder.CreateClient();
            builder.Reset();
            builder.SetAdress("Spb,Kronversky 49");
            builder.SetFirstName("Ivan");
            builder.SetSecondName("Fedorov");
            Client client2 = builder.CreateClient();

            //Фабрика
            AbstractAccount account = FactoryAccount.CreateAccount(tax: 300, client: client, limit: 20000);
            AbstractAccount account2 = FactoryAccount.CreateAccount(expiresInDay: 30, percent: (float)1.1, client: client2);
            AbstractAccount account3 = FactoryAccount.CreateAccount(percent: (float)1.2, accrualPeriod: 30, client: client);
            AbstractAccount account4 = FactoryAccount.CreateAccount(tax: 300, client: client2, limit: 2000);
            //шаблонный метод
            account.Replenish(40_000);
            account2.Replenish(24_002);
            account3.Replenish(1_000_000);
            account.Transfer(account3, 2000);
            //Декоратор
            UnverifiedDecoratorAccount unverifiedAccount = new UnverifiedDecoratorAccount(account4, 1000);
            try
            {
                unverifiedAccount.Withdraw(1200);
            }
            catch (UnverifiedLimitExceeded e)
            {
                Console.WriteLine(e);
            }
            //Цепочка обязанностей
            AccrueInterestHandler accrueHandler = new AccrueInterestHandler();
            WithdrawTaxHandler taxHandler = new WithdrawTaxHandler();
            WithdrawAllHandler withdrawAll = new WithdrawAllHandler();

            var buffer = accrueHandler.Handle(account3);

            accrueHandler.SetNext(withdrawAll);
            var buffer2 = accrueHandler.Handle(account3);

            var buffer3 = taxHandler.Handle(account);
        }
    }
}
