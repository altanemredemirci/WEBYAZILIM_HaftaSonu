using System.ComponentModel.DataAnnotations;

namespace _18_WebAPI.DTOs
{
    public class UpdateProductDTO
    {
        [Required(ErrorMessage ="Ürün adı zorunludur.")]
        [StringLength(200,MinimumLength =2,ErrorMessage ="Ürün adı 2-200 karakter arasında olmalıdır.")]
        public required string Name { get; set; }

        [MaxLength(1000)]
        public string? Description  { get; set; }

        [Required(ErrorMessage ="Fiyat zorunludur.")]
        [Range(0.01,999999.99)]
        public decimal Price { get; set; }
        
        [Range(0,int.MaxValue)]
        public int Stock { get; set; }

        public string? Category { get; set; }
    }
}
