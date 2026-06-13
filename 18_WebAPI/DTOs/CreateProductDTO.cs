using System.ComponentModel.DataAnnotations;

namespace _18_WebAPI.DTOs
{
    //REQUEST DTO'ları: İstemciden API'ye gelen veri yapıları

    //Yeni ürün oluşturma isteği için kullanılan DTO.
    //Data Annotations ile doğrulama(validation) kuralları tanımlanmıştır.
    public class CreateProductDTO
    {
        [Required(ErrorMessage="Ürün adı zorunludur.")]
        [StringLength(200,MinimumLength =2, ErrorMessage ="Ürün adı 2-200 karakter arasında olmalıdır.")]
        public required string Name { get; set; }

        [MaxLength(1000,ErrorMessage ="Ürün açıklaması en fazla 1000 karakter olmalıdır.")]
        public string? Description { get; set; }

        [Required(ErrorMessage ="Fiyat alanı zorunludur.")]
        [Range(0.01,999999.99,ErrorMessage ="Fiyat 0.01 ile 999999.99 arasında olmalıdır.")]
        public decimal Price { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Stok negatif sayı olamaz.")]
        public int Stock { get; set; }

        public string?  Category { get; set; }
    }
}
