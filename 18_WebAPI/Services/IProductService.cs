using _18_WebAPI.DTOs;

namespace _18_WebAPI.Services
{
    public interface IProductService
    {
        //Tüm ürünler listelenir
        Task<List<ProductListDTO>> GetAllProductsAsync();

        //Id'ye göre bir ürün detayı döndürür.
        //Bulunamazsa null döndürür. 
        Task<ProductDetailDTO?> GetProductByIdAsync(int id);

        Task<ProductDetailDTO> CreateProductAsync(CreateProductDTO dto);

        Task<bool> UpdateProductAsync(int id, UpdateProductDTO dto);

        Task<bool> DeleteProductAsync(int id);

        //Kategoriye göre ürünleri listeler
        Task<List<ProductListDTO>> GetProductsByCategoryAsync(string category);

        //Ürün adına göre ürünleri listeler
        Task<List<ProductListDTO>> SearchProductAsync(string searchTerm);
    }
}
