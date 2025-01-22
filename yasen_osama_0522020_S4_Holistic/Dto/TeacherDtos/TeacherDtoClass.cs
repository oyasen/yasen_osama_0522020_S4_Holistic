using System.ComponentModel.DataAnnotations;

namespace yasen_osama_0522020_S4_Holistic.Dto.TeacherDtos
{
    public class TeacherDtoClass
    {
        public int Id { get; set; }
        [Required, MaxLength(100)]
        public string Name { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        public string Phone { get; set; } = string.Empty;
    }
}
