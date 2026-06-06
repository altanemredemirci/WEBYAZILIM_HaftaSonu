using _15_AutoMapper.Context;
using _15_AutoMapper.Dtos;
using _15_AutoMapper.Models;
using _15_AutoMapper.Profiles;
using _15_AutoMapper.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace _15_AutoMapper.Controllers
{
    public class HomeController : Controller
    {
        private static List<Student> students = new List<Student>()
        {
            new Student()
            {
                Id=1,
                FirstName="Ahmet",
                LastName="Yılmaz",
                Email="ahmetyilmaz@gmail.com",
                DateOfBirth= new DateTime(2000,5,30),
                PhoneNumber="0532 555 23 36",
                Address="İstanbul",
                CreatedDate=DateTime.Now.AddDays(-30),
                IsActive=true,
                InternalNotes="Bu not kullanıcıya gösterilmemeli"
            },

            new Student()
            {
                Id=2,
                FirstName="Ayşe",
                LastName="Demir",
                Email="aysedemir@gmail.com",
                DateOfBirth= new DateTime(1999,8,22),
                PhoneNumber="0532 555 23 43",
                Address="Ankara",
                CreatedDate=DateTime.Now.AddDays(-15),
                IsActive=false,
                InternalNotes="Pasif öğrenci - özel notlar"
            }

        };

        private readonly IMapper _mapper;
        private readonly DataContext context = new DataContext();
        //Injection
        public HomeController(IMapper mapper)
        {
            _mapper = mapper;
        }
        //public IActionResult Index(Student student)
        public IActionResult Index()
        {
            List<Student> students = context.Students.ToList();

            var _students = _mapper.Map<List<StudentDisplayViewModel>>(students);

            return View(_students);
        }

        public IActionResult CreateStudent()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateStudent(StudentCreateViewModel studentCreateViewModel)
        {
            Student student = _mapper.Map<Student>(studentCreateViewModel);
            context.Students.Add(student);
            context.SaveChanges();

            return View();
        }

        [HttpGet]
        public IActionResult GetStudentApi()
        {
            var studentDtos = _mapper.Map<List<StudentDto>>(students);
            return Json(studentDtos);

        }

        public IActionResult IndexWithoutAutoMapper()
        {
            var studentViewModels = students.Select(s => new StudentDisplayViewModel
            {
                Id = s.Id,
                FullName = $"{s.FirstName} {s.LastName}",
                Email = s.Email,
                PhoneNumber = s.PhoneNumber,
                Age = CalculateAge(s.DateOfBirth),
                Address = s.Address,
                StatusText = s.IsActive ? "Aktif" : "Pasif",
                CreatedDateFormatted = s.CreatedDate.ToString("dd,MM,yyyy")
            }).ToList();

            return View("IndexWithoutAutoMapper", studentViewModels);
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
