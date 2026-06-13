namespace _18_WebAPI.DTOs
{
    public class ProductListDTO
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public decimal Price { get; set; }
        public string? Category { get; set; }
        public bool IsActive { get; set; }
    }
}
