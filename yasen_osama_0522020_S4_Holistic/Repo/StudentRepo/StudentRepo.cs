using Microsoft.EntityFrameworkCore;
using yasen_osama_0522020_S4_Holistic.Data;
using yasen_osama_0522020_S4_Holistic.Dto.ClassDtos;
using yasen_osama_0522020_S4_Holistic.Dto.GradDtos;
using yasen_osama_0522020_S4_Holistic.Dto.StudentDtos;
using yasen_osama_0522020_S4_Holistic.Dto.SubjectDtos;
using yasen_osama_0522020_S4_Holistic.Dto.TeacherDtos;
using yasen_osama_0522020_S4_Holistic.Models;

namespace yasen_osama_0522020_S4_Holistic.Repo.StudentRepo
{
    public class StudentRepo : IStudentRepo
    {
        private readonly AppDbContext _context;
        public StudentRepo(AppDbContext context)
        {
            _context = context;
        }

        public void Delete(int id)
        {
            var student = _context.Students
                .FirstOrDefault(t => t.Id == id) ?? throw new NullReferenceException("Student NotFound");
            _context.Students.Remove(student);
            _context.SaveChanges();
        }

        public StudentDto? Get(int id)
        {
            var student = _context.Students.Include(x=>x.Grads).Include(x => x.Class).ThenInclude(x => x.Teacher).Include(x => x.Subjects).FirstOrDefault(t => t.Id == id);
            return new StudentDto
            {
                Email = student.Email,
                Name = student.Name,
                Class = new ClassDtoStudent
                {
                    Name = student.Class.Name,
                    Teacher = new TeacherDtoClass
                    {
                        Email = student.Class.Teacher.Email,
                        Name = student.Class.Teacher.Name,
                        Phone = student.Class.Teacher.Phone,
                    },
                },
                Grads = student.Grads.Select(g => new GradDtoStudent
                {
                    Grade = g.Grade,
                    Year = g.Year,
                }).ToList(),
                Subjects = student.Subjects.Select(s=> new SubjectDtoStudent
                {
                    Duration = s.Duration,
                }).ToList()
            };
        }

        public List<StudentDto> Get()
        {
            return _context.Students.Include(x => x.Grads).Include(x => x.Class).Select(student=> new StudentDto
            {
                Email = student.Email,
                Name = student.Name,
                Class = new ClassDtoStudent
                {
                    Name = student.Class.Name,
                    Teacher = new TeacherDtoClass
                    {
                        Email = student.Class.Teacher.Email,
                        Name = student.Class.Teacher.Name,
                        Phone = student.Class.Teacher.Phone,
                    },
                },
                Grads = student.Grads.Select(g => new GradDtoStudent
                {
                    Grade = g.Grade,
                    Year = g.Year,
                }).ToList(),
                Subjects = student.Subjects.Select(s => new SubjectDtoStudent
                {
                    Duration = s.Duration,
                }).ToList()
            }).ToList();
        }

        public void Post(StudentDtoPost studentDto)
        {
            var student = new Student
            {
                Email = studentDto.Email,
                Name = studentDto.Name,
                Class = new Class
                {
                    Name = studentDto.Class.Name,
                    Teacher = new Teacher
                    {
                        Email = studentDto.Class.Teacher.Email,
                        Name = studentDto.Class.Teacher.Name,
                        Phone = studentDto.Class.Teacher.Phone,
                    }
                }
            };
            _context.Add(student);
            _context.SaveChanges();
        }

        public void Put(StudentDto studentDto, int id)
        {
            var student = _context.Students
                .Include(x => x.Grads)
                .Include(x => x.Class)
                .ThenInclude(x => x.Teacher)
                .Include(x => x.Subjects)
                .FirstOrDefault(t => t.Id == id) ?? throw new NullReferenceException("Student NotFound");
            student.Email = studentDto.Email;
            student.Name = studentDto.Name;
            student.Subjects = studentDto.Subjects.Select(s => new Subject
            {
                Id = s.Id,
                Duration = s.Duration,
            }).ToList();
            student.Grads = studentDto.Grads.Select(g => new Grad
            {
                Id= g.Id,
                Grade = g.Grade,
                Year = g.Year,
            }).ToList();
            student.Class = new Class
            {
                Id = studentDto.Class.Id,
                Name = studentDto.Class.Name,
                Teacher = new Teacher
                {
                    Id = studentDto.Class.Teacher.Id,
                    Email=studentDto.Class.Teacher.Email,
                    Name=studentDto.Class.Teacher.Name,
                    Phone=studentDto.Class.Teacher.Phone
                }
            };
            _context.Update(student);
            _context.SaveChanges();
        }
    }
}
