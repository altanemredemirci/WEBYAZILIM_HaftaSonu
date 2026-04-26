using System.ComponentModel.DataAnnotations;

namespace _04_ViewToController.Models
{
    public class Category
    {
        [Required(ErrorMessage ="Kategori adı boş geçilemez")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Kategori açıklaması boş geçilemez")]
        public string Description { get; set; }
    }
}
