using System.ComponentModel.DataAnnotations;
using yasen_osama_0522020_S4_Holistic.Dto.StudentDtos;
using yasen_osama_0522020_S4_Holistic.Dto.TeacherDtos;

namespace yasen_osama_0522020_S4_Holistic.Dto.ClassDtos
{
    public class ClassDtoPost
    {
        [Required, MaxLength(50)]
        public string Name { get; set; }
        public int TeacherId { get; set; }
        public List<int> StudentIds { get; set; }
    }
}
