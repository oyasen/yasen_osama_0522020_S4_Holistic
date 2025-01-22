using yasen_osama_0522020_S4_Holistic.Data;
using yasen_osama_0522020_S4_Holistic.Dto.ClassDtos;
using yasen_osama_0522020_S4_Holistic.Models;

namespace yasen_osama_0522020_S4_Holistic.Repo.ClassRepo
{
    public class ClassRepo : IClassRepo
    {
        private readonly AppDbContext _context;
        public ClassRepo(AppDbContext context)
        {
            _context = context;
        }

        public void Post(ClassDto classDto)
        {
            var clas = new Class
            {
                Name = classDto.Name,
                Students = classDto.Students.Select(st => new Student
                {
                    Name = st.Name,
                    Email = st.Email,
                    Grads = st.Grads.Select(g=> new Grad
                    {
                        Year = g.Year,
                        Grade = g.Grade,
                    }).ToList(),
                    Subjects = st.Subjects.Select(su=> new Subject
                    {
                        Duration = su.Duration,
                    }).ToList(),
                }).ToList(),
                Teacher = new Teacher
                {
                    Name= classDto.Teacher.Name,
                    Phone = classDto.Teacher.Phone,
                    Email = classDto.Teacher.Email,
                }
            };
            _context.Classes.Add(clas);
            _context.SaveChanges();
        }

        public void Post(ClassDtoPost classDto)
        {
            List<Student> students = new List<Student>();
            foreach(var st in classDto.StudentIds)
            {
                var student = _context.Students.Find(st) ?? throw new NullReferenceException("Student Id NotFound");
                students.Add(student);
            }
            var clas = new Class
            {
                Name = classDto.Name,
                Students = students,
                TeacherId = classDto.TeacherId,
            };
            _context.Classes.Add(clas);
            _context.SaveChanges();
        }
    }
}
