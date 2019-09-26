using System.Collections.Generic;

namespace lab2
{
    public enum CatalogueTypes
    {
        artist,
        album,
        track,
        genre,
        all
    }

    public class CatalogueItem
    {
        string name;
        public string Name
        {
            get => name;
            private set => name = value;
        }
        CatalogueTypes type;
        public CatalogueTypes Type
        {
            get => type;
            private set => type = value;
        }

        public override string ToString()
        {
            return $"{this.name}";
        }

        public CatalogueItem(string name, CatalogueTypes type)
        {
            this.name = name;
            this.type = type;
        }


    }

    public class Artist : CatalogueItem
    {
        List<Album> albums;
        Genre genre;
        public Genre Genre
        {
            get => genre;
        }
        public Artist(string name, Genre genre) : base(name, CatalogueTypes.artist)
        {
            albums = new List<Album>();
            this.genre = genre;
        }

        public Artist(string name) : base(name, CatalogueTypes.artist)
        {
            albums = new List<Album>();
        }

        public void AddAlbum(ref Album album)
        {
            if (album.Genre != null)
                this.albums.Add(album);
            else
            {
                album.Genre = this.genre;
            }
        }



    }

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
        public List<Track> tracks;

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

    }

    public class Track : CatalogueItem
    {
        Album album;
        public Album Album
        {
            get => album;
        }
        Artist artist;
        Genre genre;

        public Genre Genre
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

        public Track(string name, Artist artist, Album album, Genre genre) : base(name, CatalogueTypes.track)
        {
            this.artist = artist;
            this.album = album;
            this.genre = genre;
        }
    }

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
        public HipHop(string name = "HipHop") : base(name)
        {

        }
    }

}