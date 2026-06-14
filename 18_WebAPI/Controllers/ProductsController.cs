// Controller, HTTP isteklerini karşılayan ve yanıt döndüren sınıftır.
// ASP.NET Core'da controller'lar ControllerBase sınıfından türetilir.
//
// TEMEL KAVRAMLAR:
//
// [ApiController]: Bu attribute şu özellikleri otomatik sağlar:
//   - Model Validation: DTO'lardaki [Required] vb. kurallar otomatik
//     kontrol edilir. Geçersizse 400 Bad Request döner.
//   - Binding Source Inference: [FromBody], [FromRoute] gibi attribute'lar
//     otomatik çıkarılır (inference).
//   - ProblemDetails: Hata yanıtları RFC 7807 formatında döner.
//
// [Route]: URL şablonunu tanımlar.
//   - "api/[controller]" → sınıf adındaki "Controller" kısmını atar.
//   - ProductsController → "api/products" olur.
//
// HTTP METODLARi:
//   - GET    → Veri okumak için (idempotent, güvenli)
//   - POST   → Yeni kayıt oluşturmak için
//   - PUT    → Kaydı tamamen güncellemek için (idempotent)
//   - PATCH  → Kaydı kısmen güncellemek için
//   - DELETE → Kaydı silmek için (idempotent)
//
// STATUS KODLARI (HTTP Status Codes):
//   - 200 OK: İstek başarılı, veri döndürüldü.
//   - 201 Created: Kayıt oluşturuldu, Location header'ında URL var.
//   - 204 No Content: İşlem başarılı ama döndürülecek veri yok (DELETE).
//   - 400 Bad Request: İstemci hatası, gönderilen veri geçersiz.
//   - 404 Not Found: İstenen kaynak bulunamadı.
//   - 500 Internal Server Error: Sunucu hatası.
// =========================================================================

using _18_WebAPI.DTOs;
using _18_WebAPI.Models;
using _18_WebAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _18_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController(IProductService productService) : ControllerBase
    {
        //private readonly IProductService _productService;

        //public ProductsController(IProductService productService)
        //{
        //    _productService = productService;
        //}


        [HttpGet]
        [ProducesResponseType(typeof(ApiResponse<List<ProductListDTO>>), StatusCodes.Status200OK)]
        public async Task<ActionResult<List<ProductListDTO>>> GetAll()
        {
            var products = await productService.GetAllProductsAsync();

            return Ok(ApiResponse<List<ProductListDTO>>.SuccessResponse(
                products,//data
                $"{products.Count} adet ürün listelendi."//message
                ));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ApiResponse<ProductDetailDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<ProductDetailDTO>), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ApiResponse<ProductDetailDTO>>> GetById(int id)
        {
            var product = await productService.GetProductByIdAsync(id);

            if (product is null)
            {
                return NotFound(ApiResponse<ProductDetailDTO>.ErrorResponse(
                    $"ID={id} olan ürün bulunamadı"
                    ));
            }

            return Ok(ApiResponse<ProductDetailDTO>.SuccessResponse(product));
        }

        [HttpPost]
        public async Task<ActionResult<ApiResponse<ProductDetailDTO>>> Create([FromBody] CreateProductDTO dto)
        {
            var created = await productService.CreateProductAsync(dto);

            var response = ApiResponse<ProductDetailDTO>.SuccessResponse(created, "Ürün başarıyla eklendi");

            //return Ok();

            return CreatedAtAction(
                nameof(GetById),
                new { id = created.Id },
                response
                );
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] UpdateProductDTO dto)
        {
            var success = await productService.UpdateProductAsync(id, dto);

            if (!success)
            {
                return NotFound(ApiResponse<UpdateProductDTO>.ErrorResponse(
                    $"ID:{id} olan ürün bulunmadı, güncelleme yapılmadı"));
            }

            return NoContent(); //204: Başarılı, döndürülecek veri yok
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var success = await productService.DeleteProductAsync(id);

            if (!success)
            {
                return NotFound(ApiResponse<object>.ErrorResponse(
                    $"ID:{id} olan ürün bulunmadı, silme yapılmadı"));
            }

            return NoContent(); 
        }

        [HttpGet("category/{category}")]
        public async Task<ActionResult<ApiResponse<ProductListDTO>>> GetByCategory(string category)
        {
            var products = await productService.GetProductsByCategoryAsync(category);

            return Ok(ApiResponse<List<ProductListDTO>>.SuccessResponse(
                products,
                $"{category} kategorisinde {products.Count} adet ürün bulundu."));
        }

        [HttpGet("search")]
        public async Task<ActionResult<ApiResponse<ProductListDTO>>> Search([FromQuery] string q)
        {
            if (string.IsNullOrEmpty(q))
            {
                return BadRequest(ApiResponse<List<ProductListDTO>>.ErrorResponse(
                    "Arama terimi boş olamaz"
                    ));
            }

            var products = await productService.SearchProductAsync(q);

            return Ok(ApiResponse<List<ProductListDTO>>.SuccessResponse(
             products,
             $"{q} araması için {products.Count} adet ürün bulundu."));
        }
    }
}
