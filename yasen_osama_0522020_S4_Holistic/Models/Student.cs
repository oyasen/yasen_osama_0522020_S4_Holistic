namespace yasen_osama_0522020_S4_Holistic.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int ClassId { get; set; }
        public Class Class { get; set; }
        public List<Grad> Grads { get; set; }
        public List<Subject> Subjects { get; set; }
    }
}
