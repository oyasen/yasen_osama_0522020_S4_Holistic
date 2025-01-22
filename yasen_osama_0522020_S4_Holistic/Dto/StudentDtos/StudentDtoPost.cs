using System.ComponentModel.DataAnnotations;
using yasen_osama_0522020_S4_Holistic.Dto.ClassDtos;

namespace yasen_osama_0522020_S4_Holistic.Dto.StudentDtos
{
    public class StudentDtoPost
    {
        [Required, MaxLength(100)]
        public string Name { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        public ClassDtoStudent Class { get; set; }
    }
}
