using System.ComponentModel.DataAnnotations;

namespace _15_AutoMapper.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }
        
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool IsActive { get; set; }

        //Veritabanında tuttuğumuz ama kullanıcıya göstermek istemediğimiz hasas bilgi
        public string InternalNotes { get; set; }
    }
}
