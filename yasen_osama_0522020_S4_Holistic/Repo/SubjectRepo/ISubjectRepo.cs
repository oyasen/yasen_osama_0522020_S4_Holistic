using yasen_osama_0522020_S4_Holistic.Dto.SubjectDtos;
using yasen_osama_0522020_S4_Holistic.Dto.TeacherDtos;

namespace yasen_osama_0522020_S4_Holistic.Repo.SubjectRepo
{
    public interface ISubjectRepo
    {
        void Post(SubjectDto subjectDto);
        SubjectDto? Get(int id);
        List<SubjectDto> Get();
    }
}
