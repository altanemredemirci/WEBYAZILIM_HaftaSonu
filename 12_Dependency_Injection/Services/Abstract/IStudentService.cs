using _12_Dependency_Injection.Models;

namespace _12_Dependency_Injection.Services.Abstract
{
    public interface IStudentService
    {
        void Create();
        void Update();
        void Delete();
        List<Student> GetStudents();
        Student GetStudentById();
    }
}
