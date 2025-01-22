using System.ComponentModel.DataAnnotations;

namespace yasen_osama_0522020_S4_Holistic.Dto.SubjectDtos
{
    public class SubjectDtoStudent
    {
        public int Id { get; set; }
        [Required, MaxLength(10)]
        public string Duration { get; set; }
    }
}
