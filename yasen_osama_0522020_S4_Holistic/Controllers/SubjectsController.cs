using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using yasen_osama_0522020_S4_Holistic.Dto.SubjectDtos;
using yasen_osama_0522020_S4_Holistic.Dto.TeacherDtos;
using yasen_osama_0522020_S4_Holistic.Repo.SubjectRepo;
using yasen_osama_0522020_S4_Holistic.Repo.TeacherRepo;

namespace yasen_osama_0522020_S4_Holistic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectsController : ControllerBase
    {
        private readonly ISubjectRepo _repo;
        public SubjectsController(ISubjectRepo repo)
        {
            _repo = repo;
        }
        [HttpPost]
        public IActionResult Post(SubjectDto SubjectDto)
        {
            try
            {
                _repo.Post(SubjectDto);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var Subject = _repo.Get(id);
                if (Subject == null)
                    return NotFound();
                return Ok(Subject);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var Subject = _repo.Get();
                if (Subject == null || Subject.Count == 0)
                    return NotFound();
                return Ok(Subject);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
