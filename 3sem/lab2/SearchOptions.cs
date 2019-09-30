namespace lab2
{
    public class SearchOptions
    {
        public int year;
        public CatalogueTypes type;
        public string genre;
        public string name;
        public SearchOptions(string name = null, CatalogueTypes type = CatalogueTypes.all, string genre = null, int year = -1)
        {
            this.name = name;
            this.type = type;
            this.genre = genre;
            this.year = year;
        }
    }
}