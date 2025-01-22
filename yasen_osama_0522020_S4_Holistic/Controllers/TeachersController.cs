using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using yasen_osama_0522020_S4_Holistic.Dto.ClassDtos;
using yasen_osama_0522020_S4_Holistic.Dto.TeacherDtos;
using yasen_osama_0522020_S4_Holistic.Repo.ClassRepo;
using yasen_osama_0522020_S4_Holistic.Repo.TeacherRepo;

namespace yasen_osama_0522020_S4_Holistic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeachersController : ControllerBase
    {
        private readonly ITeacherRepo _repo;
        public TeachersController(ITeacherRepo repo)
        {
            _repo = repo;
        }
        [HttpPost]
        public IActionResult Post(TeacherDtoClass teacherDto)
        {
            try
            {
                _repo.Post(teacherDto);
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
                var teacher = _repo.Get(id);
                if(teacher == null)
                    return NotFound();
                return Ok(teacher);
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
                var teacher = _repo.Get();
                if(teacher == null || teacher.Count == 0)
                    return NotFound();
                return Ok(teacher);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
