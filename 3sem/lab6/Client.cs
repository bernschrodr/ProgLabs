namespace lab6{
    public class Client{
        string FirstName{get;}
        string SecondName{get;}
        string Adress{get;}
        int Passport{get;}
        public Client(string FirstName, string SecondName,string Adress,int Passport){
            this.FirstName = FirstName;
            this.SecondName = SecondName;
            this.Adress = Adress;
            this.Passport = Passport;
        }
    }
}