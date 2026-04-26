using System.ComponentModel.DataAnnotations;

namespace _04_ViewToController.Models
{
    public class Product
    {
        [Required(ErrorMessage ="Ürün Adı boş geçilemez")] //Boş geçilemez
        [MaxLength(50)] //Max 50 karakter sınırı
        [DataType(DataType.Text)]
        public string UrunAdi { get; set; }

        [StringLength(50)] //Max 50 karakter sınırı
        public string? Aciklama { get; set; } // ? : null(boş) geçilebilir.

        [Range(1,1000)]
        public decimal UrunFiyat { get; set; }
        
        public int UrunStok { get; set; }
    }
}
