namespace lab2{
     public enum CatalogueTypes
    {
        artist,
        album,
        compilation,
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
            set => type = value;
        }

        public override string ToString()
        {
            return $"{this.name}";
        }

        public override int GetHashCode(){
            return name.ToLower().GetHashCode();
        }

        public CatalogueItem(string name, CatalogueTypes type)
        {
            this.name = name;
            this.type = type;
        }


    }
}