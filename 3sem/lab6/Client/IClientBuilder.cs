namespace lab6{
    interface IClientBuilder{
        public Client CreateClient();
        public void Reset();
        public void SetFirstName(string name);
        public void SetSecondName(string name);
        public void SetAdress(string adress);
        public void SetPassport(int? number);
    } 
}