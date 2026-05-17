using System.ComponentModel.DataAnnotations;

namespace _15_AutoMapper.ViewModels
{
    public class StudentDisplayViewModel
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int Age{ get; set; }
        public string Address { get; set; }
        public string StatusText { get; set; }
        public string CreatedDateFormatted { get; set; }
    }
}
