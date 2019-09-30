using System.Collections.Generic;

namespace lab2
{
    public class Artist : CatalogueItem
    {
        List<Album> albums;
        string genre;
        public string Genre
        {
            get => genre;
        }
        public Artist(string name, string genre) : base(name, CatalogueTypes.artist)
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

        public override string ToString()
        {
            return $"[ARTIST]: {Name.ToString()} ";
        }

    }
}