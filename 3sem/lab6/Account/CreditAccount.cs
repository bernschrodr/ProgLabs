namespace lab6
    public class CreditAccount : AbstractAccount
    {   
        public CreditAccount(float tax, float limit){
            Tax = tax;
            Limit = limit;
        }
        public float Tax{get;}
        public float Limit{get;}
        override public void Withdraw(float money){
            if(Money - money < Limit){
                throw new NotEnoughException();
            }
            this.Money -= money;
        }
    }
}