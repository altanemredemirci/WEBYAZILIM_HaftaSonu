using _15_AutoMapper.Models;
using _15_AutoMapper.ViewModels;
using AutoMapper;

namespace _15_AutoMapper.Profiles
{
    public class StudentProfile: Profile //AutoMapper paketi kuruldu
    {
        public StudentProfile()
        {
            CreateMap<Student, StudentDisplayViewModel>()
                .ForMember(dest => dest.FullName,
                opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"))
                .ForMember(dest => dest.StatusText,
                opt => opt.MapFrom(src => src.IsActive ? "Aktif" : "Pasif"))
                .ForMember(dest => dest.CreatedDateFormatted,
                opt => opt.MapFrom(src => src.CreatedDate.ToString("dd,MM,yyyy")))
                .ForMember(dest => dest.Age,
                opt => opt.MapFrom(src => CalculateAge(src.DateOfBirth)));
        }

        private static int CalculateAge(DateTime birthDate)
        {
            var today = DateTime.Today;
            var age = today.Year - birthDate.Year;
            if (birthDate.Date > today.AddYears(-age)) age--;
            return age;
        }
    }
}
