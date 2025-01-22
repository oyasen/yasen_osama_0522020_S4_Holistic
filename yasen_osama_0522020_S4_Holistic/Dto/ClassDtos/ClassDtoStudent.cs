using System.ComponentModel.DataAnnotations;
using yasen_osama_0522020_S4_Holistic.Dto.TeacherDtos;

namespace yasen_osama_0522020_S4_Holistic.Dto.ClassDtos
{
    public class ClassDtoStudent
    {
        public int Id { get; set; }
        [Required, MaxLength(50)]
        public string Name { get; set; }
        public TeacherDtoClass Teacher { get; set; }
    }
}
