namespace lab2
{
    public class Track : CatalogueItem
    {
        Album album;
        public Album Album
        {
            get => album;
        }
        Artist artist;
        public Artist Artist
        {
            get => artist;
        }
        string genre;

        public string Genre
        {
            get => genre;
        }

        int year;
        public int Year
        {
            get => year;
            private set => year = value;
        }

        public Track(string name) : base(name, CatalogueTypes.track)
        {

        }

        public Track(string name, Artist artist, Album album, string genre) : base(name, CatalogueTypes.track)
        {
            this.artist = artist;
            this.album = album;
            this.genre = genre;
        }

        public Track(string name, Artist artist, Album album, string    genre, int year) : base(name, CatalogueTypes.track)
        {
            this.artist = artist;
            this.album = album;
            this.genre = genre;
            this.year = year;
        }


        public override string ToString()
        {
            string str = "";
            if (artist != null)
            {
                str += $"{artist.ToString()}";
            }
            if (album != null)
            {
                str += $"{album.ToString()}";
            }
            return str += $"[TRACK]: {Name.ToString()} ";

        }
    }
}