using yasen_osama_0522020_S4_Holistic.Dto.ClassDtos;
using yasen_osama_0522020_S4_Holistic.Dto.TeacherDtos;

namespace yasen_osama_0522020_S4_Holistic.Repo.TeacherRepo
{
    public interface ITeacherRepo
    {
        void Post(TeacherDtoClass teacherDto);
        TeacherDto? Get(int id);
        List<TeacherDto> Get();
    }
}
