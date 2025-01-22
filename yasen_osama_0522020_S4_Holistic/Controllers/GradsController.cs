using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using yasen_osama_0522020_S4_Holistic.Dto.GradDtos;
using yasen_osama_0522020_S4_Holistic.Dto.TeacherDtos;
using yasen_osama_0522020_S4_Holistic.Repo.GradRepo;
using yasen_osama_0522020_S4_Holistic.Repo.TeacherRepo;

namespace yasen_osama_0522020_S4_Holistic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GradsController : ControllerBase
    {
        private readonly IGradRepo _repo;
        public GradsController(IGradRepo repo)
        {
            _repo = repo;
        }
        [HttpPost]
        public IActionResult Post(GradDtoStudent gradDto)
        {
            try
            {
                _repo.Post(gradDto);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
