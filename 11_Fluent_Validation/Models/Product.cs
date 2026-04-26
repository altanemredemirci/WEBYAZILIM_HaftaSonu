using System.ComponentModel.DataAnnotations;

namespace _11_Fluent_Validation.Models
{
    public class Product
    {
        public int Id { get; set; }

        
        public string Name { get; set; }
        
        public decimal Price { get; set; }
        
        public int Stock { get; set; }
    }
}
