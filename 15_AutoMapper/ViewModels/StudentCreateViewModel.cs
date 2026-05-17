using System.ComponentModel.DataAnnotations;

namespace _15_AutoMapper.ViewModels
{
    public class StudentCreateViewModel
    {
        [Required(ErrorMessage ="Ad alanı zorunludur.")]
        [Display(Name ="Ad")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Soyad alanı zorunludur.")]
        [Display(Name = "Soyad")]
        public string LastName { get; set; }

        [EmailAddress(ErrorMessage ="Geçerli bir email adresi giriniz")]
        [Display(Name ="Email")]
        [Required(ErrorMessage ="Email alanı zorunludur.")]
        public string Email { get; set; }
        
        [Display(Name = "Doğum Tarihi")]
        [Required(ErrorMessage = "Doğum tarihi alanı zorunludur.")]
        public DateTime DateOfBirth { get; set; }

        [Display(Name ="Telefon")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Adres")]
        public string Address { get; set; }
    }
}
