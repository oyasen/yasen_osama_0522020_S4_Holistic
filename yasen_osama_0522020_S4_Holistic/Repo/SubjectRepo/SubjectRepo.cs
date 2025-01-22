using Microsoft.EntityFrameworkCore;
using yasen_osama_0522020_S4_Holistic.Data;
using yasen_osama_0522020_S4_Holistic.Dto.ClassDtos;
using yasen_osama_0522020_S4_Holistic.Dto.GradDtos;
using yasen_osama_0522020_S4_Holistic.Dto.StudentDtos;
using yasen_osama_0522020_S4_Holistic.Dto.SubjectDtos;
using yasen_osama_0522020_S4_Holistic.Dto.TeacherDtos;
using yasen_osama_0522020_S4_Holistic.Models;


namespace yasen_osama_0522020_S4_Holistic.Repo.SubjectRepo
{
    public class SubjectRepo : ISubjectRepo
    {
        private readonly AppDbContext _context;
        public SubjectRepo(AppDbContext context)
        {
            _context = context;
        }

        public SubjectDto? Get(int id)
        {
            var subject = _context.Subjects
                .Include(x => x.Students).ThenInclude(x => x.Grads).
                Include(x=>x.Students).ThenInclude(x=>x.Class).ThenInclude(x=>x.Teacher)
                .FirstOrDefault(t => t.Id == id);
            return new SubjectDto
            {
                Duration= subject.Duration,
                Students = subject.Students.Select(s=>new StudentDtoSubject
                {
                    Email = s.Email,
                    Name = s.Name,
                    Grads = s.Grads.Select(g=> new GradDtoStudent
                    {
                        Grade = g.Grade,
                        Year = g.Year,
                    }).ToList(),
                    Class =new ClassDtoStudent
                    {
                        Name = s.Class.Name,
                        Teacher = new TeacherDtoClass
                        {
                            Name = s.Class.Teacher.Name,
                            Email = s.Class.Teacher.Email,
                            Phone = s.Class.Teacher.Phone,
                        }
                    }
                    
                }).ToList()
            };
        }

        public List<SubjectDto> Get()
        {
            return _context.Subjects.Select(subject => new SubjectDto
            {
                Duration = subject.Duration,
                Students = subject.Students.Select(s => new StudentDtoSubject
                {
                    Email = s.Email,
                    Name = s.Name,
                    Grads = s.Grads.Select(g => new GradDtoStudent
                    {
                        Grade = g.Grade,
                        Year = g.Year,
                    }).ToList(),
                    Class = new ClassDtoStudent
                    {
                        Name = s.Class.Name,
                        Teacher = new TeacherDtoClass
                        {
                            Name = s.Class.Teacher.Name,
                            Email = s.Class.Teacher.Email,
                            Phone = s.Class.Teacher.Phone,
                        }
                    }
                }).ToList()
            }).ToList();
        }

        public void Post(SubjectDto subjectDto)
        {
            var subject = new Subject
            {
                Duration = subjectDto.Duration,
                Students = subjectDto.Students.Select(s=> new Student
                {
                    Name = s.Name,
                    Email = s.Email,
                    Grads = s.Grads.Select(g => new Grad
                    {
                        Grade = g.Grade,
                        Year = g.Year,
                    }).ToList(),
                    Class = new Class
                    {
                        Name = s.Class.Name,
                        Teacher = new Teacher
                        {
                            Email = s.Class.Teacher.Email,
                            Name = s.Class.Teacher.Name,
                            Phone = s.Class.Teacher.Phone
                        }
                    }
                }).ToList()
            };
            _context.Subjects.Add(subject);
            _context.SaveChanges();
        }
    }
}
