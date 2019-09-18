using System.Collections.Generic;

namespace lab2
{

    public class SearchOptions
    {
        public int year;
        public CatalogueTypes type;
        public Genre genre;
        public string name;
        SearchOptions(string name = null, CatalogueTypes type = CatalogueTypes.all, Genre genre = null, int year = -1)
        {
            this.name = name;
            this.type = type;
            this.genre = genre;
            this.year = year;
        }
    }
    public class Catalogue
    {

        Dictionary<int, List<CatalogueItem>> items;

        public Catalogue()
        {
            items = new Dictionary<int, List<CatalogueItem>>();

        }

        public void AddItem(CatalogueItem item)
        {
            List<CatalogueItem> list;
            if (items.TryGetValue(item.GetHashCode(), out list))
            {
                list.Add(item);
            }
        }


        public List<CatalogueItem> Search(string name)
        {
            List<CatalogueItem> result = new List<CatalogueItem>();
            List<CatalogueItem> list;
            if (items.TryGetValue(name.GetHashCode(), out list))
            {
                result = list;
            }


            return result;

        }
        public List<CatalogueItem> Search(SearchOptions options)
        {
            List<CatalogueItem> result = new List<CatalogueItem>();
            List<CatalogueItem> list = new List<CatalogueItem>();

            if (items.TryGetValue(options.name.GetHashCode(), out list))
            {
                foreach (var item in list)
                {
                    if (item.Type == options.type)
                    {
                        result.Add(item);
                    }
                }
            }

            return result;
        }
    }
}