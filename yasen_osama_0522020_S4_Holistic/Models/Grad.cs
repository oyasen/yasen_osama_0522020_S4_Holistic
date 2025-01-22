namespace yasen_osama_0522020_S4_Holistic.Models
{
    public class Grad
    {
        public int Id { get; set; }
        public int Year { get; set; }
        public string Grade { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
    }
}
