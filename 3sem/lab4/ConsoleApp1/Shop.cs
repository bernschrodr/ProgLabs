using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsoleApp1
{
    public class Shop
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Product> Products {get; set;} = new List<Product>();
        
        public Shop() { }

        public Shop(int ShopId, string Name)
        {
            this.Id = ShopId;
            this.Name = Name;
        }
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}