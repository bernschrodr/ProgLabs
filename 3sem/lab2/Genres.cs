namespace lab2{
    public class Genre : CatalogueItem
    {
        public Genre(string name) : base(name, CatalogueTypes.genre)
        {

        }
    }

    public class Rock : Genre
    {
        public Rock(string name = "Rock") : base(name)
        {

        }
    }

    public class AlternativeRock : Rock
    {
        public AlternativeRock() : base("Alternative Rock")
        {

        }
    }

    public class ThrashMetal : Rock
    {
        public ThrashMetal() : base("ThrashMetal")
        {

        }
    }

    public class Pop : Genre
    {
        public Pop(string name = "Pop") : base(name)
        {

        }
    }

    public class HipHop : Genre
    {
        public HipHop(string name = "Hip/Hop") : base(name)
        {

        }
    }
}