using System.Collections.Generic;

namespace lab2
{
    public class Album : CatalogueItem
    {
        Genre genre;
        public Genre Genre
        {
            set => genre = value;
            get => genre;
        }
        int year;
        public int Year
        {
            get => year;
            set => year = value;
        }

        Artist artist;
        public Artist Artist
        {
            get => artist;
            set => artist = value;
        }
        public List<Track> tracks = new List<Track>();

        public Album(string name, ref Artist artist, CatalogueTypes type = CatalogueTypes.album) : base(name, type)
        {
            this.artist = artist;

        }
        public Album(string name, ref Genre genre, ref Artist artist, CatalogueTypes type = CatalogueTypes.album) : base(name, type)
        {
            this.genre = genre;
            this.artist = artist;

        }
        public Album(string name, ref Genre genre, ref Artist artist, List<Track> tracks, CatalogueTypes type = CatalogueTypes.album) : base(name, type)
        {
            this.genre = genre;
            this.artist = artist;
            this.tracks = tracks;
        }

        public Album(string name, ref Genre genre, ref Artist artist, int year, List<Track> tracks, CatalogueTypes type = CatalogueTypes.album) : base(name, type)
        {
            this.genre = genre;
            this.artist = artist;
            this.tracks = tracks;
            this.year = year;
        }

        override public string ToString()
        {
            return $"[ALBUM]: {Name.ToString()} ";
        }

    }

}