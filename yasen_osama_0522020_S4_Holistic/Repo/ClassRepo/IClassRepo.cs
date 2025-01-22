using yasen_osama_0522020_S4_Holistic.Dto.ClassDtos;

namespace yasen_osama_0522020_S4_Holistic.Repo.ClassRepo
{
    public interface IClassRepo
    {
        void Post(ClassDto classDto);
        void Post(ClassDtoPost classDto);
    }
}
