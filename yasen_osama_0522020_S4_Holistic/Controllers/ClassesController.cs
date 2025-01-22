using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using yasen_osama_0522020_S4_Holistic.Dto.ClassDtos;
using yasen_osama_0522020_S4_Holistic.Repo.ClassRepo;

namespace yasen_osama_0522020_S4_Holistic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassesController : ControllerBase
    {
        private readonly IClassRepo _repo;
        public ClassesController(IClassRepo repo)
        {
            _repo = repo;
        }
        [HttpPost("Post New")]
        public IActionResult Post(ClassDto classDto)
        {
            try
            {
                _repo.Post(classDto);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }
        [HttpPost("Post Exist")]
        public IActionResult Post(ClassDtoPost classDto)
        {
            try
            {
                _repo.Post(classDto);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
