using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using yasen_osama_0522020_S4_Holistic.Dto.StudentDtos;
using yasen_osama_0522020_S4_Holistic.Dto.TeacherDtos;
using yasen_osama_0522020_S4_Holistic.Repo.StudentRepo;
using yasen_osama_0522020_S4_Holistic.Repo.TeacherRepo;

namespace yasen_osama_0522020_S4_Holistic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentRepo _repo;
        public StudentsController(IStudentRepo repo)
        {
            _repo = repo;
        }
        [HttpPost]
        public IActionResult Post(StudentDtoPost studentDto)
        {
            try
            {
                _repo.Post(studentDto);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        public IActionResult Put(StudentDto studentDto,int id)
        {
            try
            {
                _repo.Put(studentDto,id);
                return Ok();
            }
            catch(NullReferenceException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                _repo.Delete(id);
                return Ok();
            }
            catch (NullReferenceException ex)
            {
                return NotFound(ex.Message);
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
                if (teacher == null)
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
                if (teacher == null || teacher.Count == 0)
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

