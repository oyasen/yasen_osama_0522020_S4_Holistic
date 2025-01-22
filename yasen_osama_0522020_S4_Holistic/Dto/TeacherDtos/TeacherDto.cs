using System.ComponentModel.DataAnnotations;
using yasen_osama_0522020_S4_Holistic.Dto.ClassDtos;

namespace yasen_osama_0522020_S4_Holistic.Dto.TeacherDtos
{
    public class TeacherDto
    {
        [Required,MaxLength(100)]
        public string Name { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        public string Phone { get; set; } = string.Empty;
        public ClassDtoTeacher Class { get; set; }
    }
}
