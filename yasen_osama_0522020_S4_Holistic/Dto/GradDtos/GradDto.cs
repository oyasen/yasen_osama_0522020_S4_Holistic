using System.ComponentModel.DataAnnotations;
using yasen_osama_0522020_S4_Holistic.Dto.StudentDtos;

namespace yasen_osama_0522020_S4_Holistic.Dto.GradDtos
{
    public class GradDto
    {
        [Required]
        public int Year { get; set; }
        [Required, MaxLength(10)]
        public string Grade { get; set; }
        public int StudentId { get; set; }
        public StudentDtoGrad Student { get; set; }
    }
}
