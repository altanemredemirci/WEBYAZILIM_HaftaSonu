namespace _18_WebAPI.DTOs
{
    //Tek bir ürün detay sayfasını için tüm bilgiler.
    public class ProductDetailDTO
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string? Category { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsActive { get; set; }
    }
}
