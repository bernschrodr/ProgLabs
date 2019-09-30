using System.Collections.Generic;
using System.IO;
using System;
namespace lab2
{
    class Genre2
    {

        private Dictionary<string, List<string>> subgenres = new Dictionary<string, List<string>>();
        public Dictionary<string, List<string>> Subgenres{
            get => subgenres;
        }
        private List<string> genres = new List<string>();
        public List<string> Genres{
            get => genres;
        }
        
        public Genre2(StreamReader sr)
        {
            try
            {
                string[] separator = { "-" };
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] infoFromFile = line.Split(separator, StringSplitOptions.RemoveEmptyEntries);
                    for (var i = 0; i < infoFromFile.Length; i++)
                    {
                        infoFromFile[i] = infoFromFile[i].Trim(' ');
                    }
                    if (infoFromFile[0] == "")
                    {
                        continue;
                    }
                    List<string> listSubgenres = new List<string>();
                    genres.Add(infoFromFile[0].ToLower());
                    for(var i = 1; i < infoFromFile.Length; i++){
                        listSubgenres.Add(infoFromFile[i].ToLower());
                    }
                    subgenres.Add(infoFromFile[0].ToLower(), listSubgenres);
                }
            }
            catch (System.Exception e)
            {
                Console.WriteLine("Bad File");
            }

        }
        public bool IsSubgenre(string genre, string subgenre)
        {
            List<string> outGenres;
            if (!subgenres.TryGetValue(genre.ToLower(),out outGenres))
            {
                return false;
            }
            foreach(var item in outGenres){
                if(item.ToLower() == subgenre.ToLower()){
                    return true;
                }
                if(IsSubgenre(item.ToLower(), subgenre.ToLower())){
                    return true;
                }
            }
            return false;
            
        }
    }
    
}