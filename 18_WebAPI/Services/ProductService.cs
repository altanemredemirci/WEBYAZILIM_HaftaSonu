using _18_WebAPI.DTOs;
using _18_WebAPI.Models;

namespace _18_WebAPI.Services
{
    public class ProductService(ILogger<ProductService> logger) : IProductService
    {
        private static readonly List<Product> _products =
        [
            new Product {Id=1,Name="Laptop",Description="16GB RAM, 512GB SSD",Price=45999.99m,Stock=25,Category="Elektronik"},
            new Product{Id=2,Name="Kulaklık",Description="Bluetooth, ANC Destekli",Price=4599.99m,Stock=25,Category="Elektronik"},
            new Product{Id=3,Name="Progralama Kitabı",Description="C# ile .Net Core",Price=459,Stock=25,Category="Kitap"},
            new Product{Id=4,Name="Mekanik Klavye",Description="RGB, Cherry Mx Blue",Price=3599.99m,Stock=25,Category="Elektronik"},
            new Product{Id=5,Name="Monitör",Description="27 inç, 4K, IPS Panel",Price=12999.99m,Stock=25,Category="Elektronik"}
        ];

        private static int _nextId = 6;

        public Task<ProductDetailDTO> CreateProductAsync(CreateProductDTO dto)
        {
            var product = new Product
            {
                Id = _nextId++,
                Name = dto.Name,
                Description = dto.Description,
                Price = dto.Price,
                Stock = dto.Stock,
                Category = dto.Category,
                CreatedAt = DateTime.Now,
                IsActive = true
            };

            _products.Add(product);

            logger.LogInformation("Yeni ürün oluşturuldu. ID:{Id}, Ad:{Name}", product.Id, product.Name);

            var resultDto = new ProductDetailDTO
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Stock = product.Stock,
                Category = product.Category,
                CreatedAt = product.CreatedAt,
                IsActive = product.IsActive
            };

            return Task.FromResult(resultDto);
        }

        public Task<bool> DeleteProductAsync(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id && p.IsActive);

            if(product is null)
            {
                logger.LogWarning("Silinecek ürün bulunamadı. ID:{Id}", id);
                return Task.FromResult(false);
            }

            product.IsActive = false; //Soft Delete
            logger.LogInformation("Ürün silindi (soft delete) ID:{Id}", id);

            return Task.FromResult(true);

        }

        public Task<List<ProductListDTO>> GetAllProductsAsync()
        {
            logger.LogInformation("Tüm ürünler listeleniyor. Toplam {Count}", _products.Count);

            var result = _products
                .Where(i => i.IsActive)
                .Select(p => new ProductListDTO
                {
                    Id = p.Id,
                    Name = p.Name,
                    Category = p.Category,
                    IsActive = p.IsActive,
                    Price = p.Price
                }).ToList();

            return Task.FromResult(result);
        }

        public Task<ProductDetailDTO?> GetProductByIdAsync(int id)
        {
            logger.LogInformation("Ürün aranıyor. Id:", id);

            var product = _products.FirstOrDefault(i => i.Id == id);

            if(product is null)
            {
                logger.LogWarning("Ürün bulunamadı. ID:", id);
                return Task.FromResult<ProductDetailDTO?>(null);
            }

            var dto = new ProductDetailDTO
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Stock = product.Stock,
                Category = product.Category,
                CreatedAt = product.CreatedAt,
                IsActive = product.IsActive
            };

            return Task.FromResult<ProductDetailDTO?>(dto);
        }

        public Task<List<ProductListDTO>> GetProductsByCategoryAsync(string category)
        {
            var result = _products
                .Where(p => p.IsActive &&
                           p.Category != null &&
                           p.Category.Equals(category, StringComparison.OrdinalIgnoreCase))
                .Select(p => new ProductListDTO
                {
                    Id = p.Id,
                    Name = p.Name,
                    Category = p.Category,
                    IsActive = p.IsActive,
                    Price = p.Price
                }).ToList();

            logger.LogInformation("Kategoriye göre filtrelendi: {Category}. Bulunan:{Count}", category, result.Count);

            return Task.FromResult(result);
        }

        public Task<List<ProductListDTO>> SearchProductAsync(string searchTerm)
        {
            var result = _products
                .Where(p => p.IsActive &&
                           p.Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
                .Select(p => new ProductListDTO
                {
                    Id = p.Id,
                    Name = p.Name,
                    Category = p.Category,
                    IsActive = p.IsActive,
                    Price = p.Price
                }).ToList();

            logger.LogInformation("Arama yapıldı: '{SearchTerm}'. Bulunan:{Count}", searchTerm, result.Count);

            return Task.FromResult(result);
        }

        public Task<bool> UpdateProductAsync(int id, UpdateProductDTO dto)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);

            if (product is null)
            {
                logger.LogWarning("Ürün bulunamadı. ID:", id);
                return Task.FromResult(false);
            }

            product.Name = dto.Name;
            product.Stock = dto.Stock;
            product.Price = dto.Price;
            product.Description = dto.Description;
            product.Category = dto.Category;

            logger.LogInformation("Ürün güncellendi. ID: {id}", id);

            return Task.FromResult(true);
        }
    }
}
