using System.ComponentModel.DataAnnotations;

namespace yasen_osama_0522020_S4_Holistic.Dto.GradDtos
{
    public class GradDtoStudent
    {
        public int Id { get; set; }
        [Required]
        public int Year { get; set; }
        [Required, MaxLength(10)]
        public string Grade { get; set; }
        public int StudentId { get; set; }
    }
}
