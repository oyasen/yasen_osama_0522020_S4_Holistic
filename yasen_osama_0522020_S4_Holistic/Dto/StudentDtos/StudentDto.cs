using System.ComponentModel.DataAnnotations;
using yasen_osama_0522020_S4_Holistic.Dto.ClassDtos;
using yasen_osama_0522020_S4_Holistic.Dto.GradDtos;
using yasen_osama_0522020_S4_Holistic.Dto.SubjectDtos;

namespace yasen_osama_0522020_S4_Holistic.Dto.StudentDtos
{
    public class StudentDto
    {
        [Required,MaxLength(100)]
        public string Name { get; set; }
        [Required,EmailAddress]
        public string Email { get; set; }
        public ClassDtoStudent Class { get; set; }
        public List<GradDtoStudent> Grads { get; set; }
        public List<SubjectDtoStudent> Subjects { get; set; }
    }
}
