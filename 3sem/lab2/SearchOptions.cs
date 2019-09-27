namespace lab2
{
    public class SearchOptions
    {
        public int year;
        public CatalogueTypes type;
        public Genre genre;
        public string name;
        public SearchOptions(string name = null, CatalogueTypes type = CatalogueTypes.all, Genre genre = null, int year = -1)
        {
            this.name = name;
            this.type = type;
            this.genre = genre;
            this.year = year;
        }
    }
}