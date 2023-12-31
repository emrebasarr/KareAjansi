using KareAjansi.BLL.DTOs;
using KareAjansi.BLL.Repositories;
using KareAjansi.BLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KareAjansi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrganizasyonMankenlerController : ControllerBase
    {
        private readonly IOrganizasyonMankenRepository _organizasyonMankenRepository;

        public OrganizasyonMankenlerController(IOrganizasyonMankenRepository organizasyonMankenRepository) 
        {
            _organizasyonMankenRepository = organizasyonMankenRepository;
        }

        [HttpGet]
        [Route("organizasyonmanken")]
        public IActionResult GetOrganizasyonMankenDetails()
        {
            try
            {
                var organizasyonMankenDetails = _organizasyonMankenRepository.GetOrganizasyonMankenDetails();
                return Ok(organizasyonMankenDetails);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpPost]
        [Route("addorganizasyonmanken")]
        public IActionResult AddManken([FromBody] OrganizasyonMankenDTO organizasyonMankenDTO)
        {
            if (organizasyonMankenDTO == null)
            {
                return BadRequest("OrganizasyonManken bilgileri boş olamaz");
            }
            else
            {
                _organizasyonMankenRepository.AddOrganizasyonManken(organizasyonMankenDTO);
                return Ok("OrganizasyonManken Başarıyla Eklendi");
            }
        }

        [HttpDelete]
        [Route("deleteorganizasyonmanken/{id}")]
        public IActionResult DeleteOrganizasyonManken(int id)
        {
            var deletedOrganizasyonManken = _organizasyonMankenRepository.DeleteOrganizasyonManken(id);
            if (deletedOrganizasyonManken == null)
            {
                return NotFound();
            }
            return Ok(deletedOrganizasyonManken);
        }

        [HttpGet]
        [Route("searchOrganizasyonManken/{data}")]
        public IActionResult SearchOrganizasyonManken(string data)
        {
            return Ok(_organizasyonMankenRepository.SearchOrganizasyonManken(data));
        }
    }
}