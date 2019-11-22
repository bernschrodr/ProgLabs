namespace lab6{
    public class Client{
        public string FirstName{get;}
        public string SecondName{get;}
        public string Adress{get;}
        public int? Passport{get;}
        public Client(string FirstName, string SecondName,string Adress,int? Passport){
            this.FirstName = FirstName;
            this.SecondName = SecondName;
            this.Adress = Adress;
            this.Passport = Passport;
        }
    }
}