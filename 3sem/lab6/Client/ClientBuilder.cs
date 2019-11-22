namespace lab6
{
    public class ClientBuilder : IClientBuilder
    {

        string firstName, secondName, adress;
        int? passport;
        public Client CreateClient()
        {
            if (firstName != "" && secondName != "")
            {
                return new Client(firstName, secondName, adress, passport);
            }
            else
            {
                throw new NotCorrectObjectException();
            }
        }

        public void Reset()
        {
            firstName = "";
            secondName = "";
            adress = "";
            passport = null;
        }

        public void SetFirstName(string name)
        {
            firstName = name;
        }
        public void SetSecondName(string name)
        {
            secondName = name;
        }
        public void SetAdress(string adress)
        {
            this.adress = adress;
        }
        public void SetPassport(int? number)
        {
            this.passport = number;
        }


    }
}