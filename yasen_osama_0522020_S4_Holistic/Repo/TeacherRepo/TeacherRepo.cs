using Microsoft.EntityFrameworkCore;
using yasen_osama_0522020_S4_Holistic.Data;
using yasen_osama_0522020_S4_Holistic.Dto.ClassDtos;
using yasen_osama_0522020_S4_Holistic.Dto.GradDtos;
using yasen_osama_0522020_S4_Holistic.Dto.StudentDtos;
using yasen_osama_0522020_S4_Holistic.Dto.SubjectDtos;
using yasen_osama_0522020_S4_Holistic.Dto.TeacherDtos;
using yasen_osama_0522020_S4_Holistic.Models;

namespace yasen_osama_0522020_S4_Holistic.Repo.TeacherRepo
{
    public class TeacherRepo : ITeacherRepo
    {
        private readonly AppDbContext _context;
        public TeacherRepo(AppDbContext context)
        {
            _context = context;
        }

        public TeacherDto? Get(int id)
        {
            var teacher = _context.Teachers.Include(x=>x.Class).ThenInclude(x=>x.Students).ThenInclude(x=>x.Subjects).Include(x=>x.Class).ThenInclude(x => x.Students).ThenInclude(x => x.Grads).FirstOrDefault(t=>t.Id == id);
            return new TeacherDto
            {
                Email = teacher.Email,
                Name = teacher.Name,
                Phone = teacher.Phone,
                Class = new ClassDtoTeacher
                {
                    Name = teacher.Class.Name,
                    Students = teacher.Class.Students.Select(st=> new StudentDtoClass
                    {
                        Name=st.Name,
                        Email=st.Email,
                        Subjects=st.Subjects.Select(su=> new SubjectDtoStudent
                        {
                            Duration=su.Duration,
                        }).ToList(),
                        Grads = st.Grads.Select(g=> new GradDtoStudent
                        {
                            Grade=g.Grade,
                            Year=g.Year,
                        }).ToList(),
                    }).ToList()
                }
            };
        }

        public List<TeacherDto> Get()
        {
            return _context.Teachers.Select(t=> new TeacherDto
            {
                Email = t.Email,
                Name = t.Name,
                Phone = t.Phone,
                Class = new ClassDtoTeacher
                {
                    Name = t.Class.Name,
                    Students = t.Class.Students.Select(st => new StudentDtoClass
                    {
                        Name = st.Name,
                        Email = st.Email,
                        Subjects = st.Subjects.Select(su => new SubjectDtoStudent
                        {
                            Duration = su.Duration,
                        }).ToList(),
                        Grads = st.Grads.Select(g => new GradDtoStudent
                        {
                            Grade = g.Grade,
                            Year = g.Year,
                        }).ToList(),
                    }).ToList()
                }
            }).ToList();
        }

        public void Post(TeacherDtoClass teacherDto)
        {
            var teacher = new Teacher
            {
                Name = teacherDto.Name,
                Email = teacherDto.Email,
                Phone = teacherDto.Phone,
            };
            _context.Teachers.Add(teacher);
            _context.SaveChanges();
        }
    }
}
