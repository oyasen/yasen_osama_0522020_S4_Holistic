using System.ComponentModel.DataAnnotations;
using yasen_osama_0522020_S4_Holistic.Dto.StudentDtos;

namespace yasen_osama_0522020_S4_Holistic.Dto.SubjectDtos
{
    public class SubjectDto
    {
        [Required, MaxLength(10)]
        public string Duration { get; set; }
        public List<StudentDtoSubject> Students { get; set; }
        
        
    }
}
