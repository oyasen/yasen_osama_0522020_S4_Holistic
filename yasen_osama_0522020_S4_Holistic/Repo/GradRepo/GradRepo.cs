using Microsoft.EntityFrameworkCore;
using yasen_osama_0522020_S4_Holistic.Data;
using yasen_osama_0522020_S4_Holistic.Dto.GradDtos;
using yasen_osama_0522020_S4_Holistic.Dto.TeacherDtos;
using yasen_osama_0522020_S4_Holistic.Models;

namespace yasen_osama_0522020_S4_Holistic.Repo.GradRepo
{
    public class GradRepo : IGradRepo
    {
        private readonly AppDbContext _context;
        public GradRepo(AppDbContext context)
        {
            _context = context;
        }

        public void Post(GradDtoStudent gradDto)
        {
            var Grad = new Grad
            {
                Grade = gradDto.Grade,
                StudentId = gradDto.StudentId,
                Year = gradDto.Year,
            };
            _context.Grads.Add(Grad);
            _context.SaveChanges();
        }
    }
}
