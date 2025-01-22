using yasen_osama_0522020_S4_Holistic.Dto.StudentDtos;
using yasen_osama_0522020_S4_Holistic.Dto.TeacherDtos;

namespace yasen_osama_0522020_S4_Holistic.Repo.StudentRepo
{
    public interface IStudentRepo
    {
        void Post(StudentDtoPost studentDto);
        void Put(StudentDto studentDto, int id);
        void Delete(int id);
        StudentDto? Get(int id);
        List<StudentDto> Get();
    }
}
