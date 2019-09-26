using System.Collections.Generic;
using System.IO;
using System;

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
    public class Catalogue
    {

        Dictionary<int, Artist> artists = new Dictionary<int, Artist>();
        Dictionary<int, Album> albums = new Dictionary<int, Album>();
        Dictionary<int, Track> tracks = new Dictionary<int, Track>();
        Dictionary<int, Genre> genres = new Dictionary<int, Genre>();

        public Catalogue()
        {

        }

        public Catalogue(StreamReader sr)
        {
            try
            {
                string[] separator = { "-" };
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] trackInFile = line.Split(separator, StringSplitOptions.None);
                    for (var i = 0; i < trackInFile.Length; i++)
                    {
                        trackInFile[i] = trackInFile[i].Trim(' ');
                    }
                    if (trackInFile.Length < 3 || trackInFile[0] == "" || trackInFile[2] == "")
                    {
                        continue;
                    }

                    Genre outGenre = new Genre("none");
                    if (trackInFile[3] != "" && !this.genres.TryGetValue(trackInFile[3].GetHashCode(), out outGenre))
                    {
                        this.genres.Add(trackInFile[3].GetHashCode(), (outGenre = new Genre(trackInFile[3])));
                    }

                    Artist artist = new Artist(trackInFile[0], outGenre);
                    if (trackInFile[2] == "")
                    {
                        trackInFile[2] = trackInFile[3];
                    }
                    Album album = new Album(trackInFile[2], ref artist);
                    artist.AddAlbum(ref album);
                    Track track = new Track(trackInFile[3], artist, album, outGenre);
                    AddTrack(track);
                }
            }
            catch (System.Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }

        public bool AddTrack(Track track)
        {
            Track outTrack;
            if (!this.tracks.TryGetValue(track.GetHashCode(), out outTrack))
            {
                AddAlbum(track.Album);
                Album outAlbum;
                if (this.albums.TryGetValue(track.Album.GetHashCode(), out outAlbum))
                {
                    outAlbum.tracks.Add(track);
                }
                this.tracks.Add(track.GetHashCode(), outTrack);
                return true;

            }
            else
            {
                return false;
            }
        }

        public bool AddAlbum(Album album)
        {


            if (AddArtist(album.Artist))
            {
                Album outAlbum;
                if (this.albums.TryGetValue(album.GetHashCode(), out outAlbum))
                {
                    return false;
                }
                this.albums.Add(album.GetHashCode(), album);
                return true;
            }
            else
            {
                Artist outArtist;
                if (!this.artists.TryGetValue(album.Artist.GetHashCode(), out outArtist))
                {
                    System.Console.WriteLine("artist not found");
                    return false;
                }
                album.Artist = outArtist;
                outArtist.AddAlbum(ref album);
                this.albums.Add(album.GetHashCode(), album);
                return true;
            }

        }

        public bool AddArtist(Artist artist)
        {
            Artist outArtist;
            if (!this.artists.TryGetValue(artist.GetHashCode(), out outArtist))
            {
                this.artists.Add(artist.GetHashCode(), artist);
                return true;
            }
            else
            {
                return false;
            }
        }


        public void Search(SearchOptions options)
        {
            List<CatalogueItem> result = new List<CatalogueItem>();
            Artist artistsResultByWord;
            Album albumsResultByWord;
            Track tracksResultByWord;
            Genre genre = options.genre;
            int year = options.year;
            string name = options.name;


            if (options.type == CatalogueTypes.artist || options.type == CatalogueTypes.all)
            {
                if (artists.TryGetValue(name.GetHashCode(), out artistsResultByWord))
                {
                    System.Console.WriteLine(artistsResultByWord);
                }
            }

            if (options.type == CatalogueTypes.album || options.type == CatalogueTypes.all)
            {
                if (albums.TryGetValue(name.GetHashCode(), out albumsResultByWord))
                {
                    if (genre != null && albumsResultByWord.Genre == genre && year != -1
                    && albumsResultByWord.Year == year)
                    {
                        System.Console.WriteLine(albumsResultByWord);
                    }
                }
            }

            if (options.type == CatalogueTypes.track || options.type == CatalogueTypes.all)
            {
                if (tracks.TryGetValue(name.GetHashCode(), out tracksResultByWord))
                {
                    if (genre != null && tracksResultByWord.Genre == genre && year != -1 && tracksResultByWord.Year == year)
                    {
                        System.Console.WriteLine(tracksResultByWord);
                    }

                }
            }

        }


    }
}

