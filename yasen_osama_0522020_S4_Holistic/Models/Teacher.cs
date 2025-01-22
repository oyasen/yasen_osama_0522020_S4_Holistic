namespace yasen_osama_0522020_S4_Holistic.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; } = string.Empty;
        public Class Class { get; set; }
    }
}
