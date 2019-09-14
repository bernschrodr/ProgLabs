using System;
using System.Collections.Generic;

namespace lab2
{
    public enum CatalogueTypes
    {
        artist,
        album,
        track,
        genre
    }

    public class CatalogueItem
    {
        public string name;
        public CatalogueTypes type;

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

        Artist artist;
        public Artist Artist{
            get=>artist;
        }
        List<Track> tracks;

        public Album(string name,ref Artist artist, CatalogueTypes type = CatalogueTypes.album) : base(name, type)
        {
            this.artist = artist;

        }
        public Album(string name, ref Genre genre , ref Artist artist,CatalogueTypes type = CatalogueTypes.album) : base(name, type)
        {
            this.genre = genre;
            this.artist = artist;

        }
        public Album(string name, ref Genre genre, ref Artist artist, List<Track> tracks,CatalogueTypes type = CatalogueTypes.album) : base(name, type)
        {
            this.genre = genre;
            this.artist = artist;
            this.tracks = tracks;
        }

    }

    public class Track : CatalogueItem
    {
        Album album;
        Artist artist;
        Genre genre;

        int year;

        public Track(string name, CatalogueTypes type) : base(name, type)
        {
            
        }
    }

    public class Genre : CatalogueItem
    {
        public Genre(string name, CatalogueTypes type) : base(name, type)
        {

        }
    }

    public class Rock : Genre
    {
        public Rock(string name = "Rock") : base(name, CatalogueTypes.genre)
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
        public Pop(string name = "Pop") : base(name, CatalogueTypes.genre)
        {

        }
    }

    public class HipHop : Genre
    {
        public HipHop(string name = "HipHop") : base(name, CatalogueTypes.genre)
        {

        }
    }

    public class Catalogue
    {
        HashSet<Artist> artists;

        public Catalogue()
        {
            artists = new HashSet<Artist>();

        }

        public void AddGenre(Genre genre){
            genres.Add(genre);
        }

        public void AddAlbum(Album album){
            foreach(var artist in this.artists){
                if(String.Equals(artist.name, album.Artist.name,StringComparison.CurrentCultureIgnoreCase)){
                    artist.AddAlbum(ref album);
                }
            }
        }

        public void AddArtist(Artist artist){
            artists.Add(artist);
        }

        public void AddTrack(Track track){
            tracks.Add(track);

        }


        public List<Object> Search(string name)
        {
            int enumCount = Enum.GetValues(typeof(CatalogueTypes)).Length;
            List<Object> result = new List<object>();
            for (CatalogueTypes typeSearch = 0; (int)typeSearch < enumCount; typeSearch++)
            {
                result.AddRange(Search(typeSearch, name));
            }

            return result;

        }
        public List<Object> Search(CatalogueTypes whatSearch, string name)
        {
            List<Object> result = new List<Object>();
            switch (whatSearch)
            {
                case CatalogueTypes.artist:
                    foreach (var artist in this.artists)
                    {
                        if (artist.name == "name")
                            result.Add(artist);
                    }
                    break;
                case CatalogueTypes.album:
                    foreach (var album in this.albums)
                    {
                        if (album.name == "name")
                            result.Add(albums);
                    }
                    break;
                case CatalogueTypes.track:
                    foreach (var track in this.tracks)
                    {
                        if (track.name == "name")
                            result.Add(track);
                    }
                    break;
                case CatalogueTypes.genre:
                    foreach (var genre in this.genres)
                    {
                        if (genre.name == "name")
                            result.Add(genre);
                    }
                    break;
    
                default:
                break;
            }

            return result;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
