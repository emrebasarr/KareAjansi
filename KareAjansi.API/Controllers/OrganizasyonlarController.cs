using KareAjansi.BLL.DTOs;
using KareAjansi.BLL.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KareAjansi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrganizasyonlarController : ControllerBase
    {
        private readonly IOrganizasyonRepository _organizasyonRepository;

        public OrganizasyonlarController(IOrganizasyonRepository organizasyonRepository) 
        {
            _organizasyonRepository = organizasyonRepository;
        }

        [HttpGet]
        [Route("getAllOrganizasyonlar")]
        public IActionResult GetAllOrganizasyonlar()
        {
            var organizasyonlar = _organizasyonRepository.GetAllOrganizasyonlar();
            return Ok(organizasyonlar);
        }

        [HttpPost]
        [Route("addorganizasyon")]
        public IActionResult AddOrganizasyon([FromBody] OrganizasyonDTO organizasyon)
        {
            if (organizasyon == null)
            {
                return BadRequest("Organizasyon bilgileri boş olamaz");
            }
            else
            {
                _organizasyonRepository.AddOrganizasyon(organizasyon);
                return Ok("Organizasyon Başarıyla Eklendi");
            }
        }

        [HttpGet]
        [Route("getorganizasyon/{id}")]
        public IActionResult GetOrganizasyon(int id)
        {
            var organizasyon = _organizasyonRepository.GetOrganizasyonById(id);
            if (organizasyon == null)
            {
                return NotFound();
            }
            return Ok(organizasyon);
        }

        [HttpDelete]
        [Route("deleteorganizasyon/{id}")]
        public IActionResult DeleteOrganizasyon(int id)
        {
            var deletedManken = _organizasyonRepository.DeleteOrganizasyon(id);

            if (deletedManken == null)
            {
                return NotFound();
            }

            return Ok(deletedManken);
        }

        [HttpPut]
        [Route("updateorganizasyon")]
        public IActionResult UpdateOrganizasyon([FromBody] OrganizasyonDTO updatedOrganizasyon)
        {
            var organizasyon = _organizasyonRepository.UpdateOrganizasyon(updatedOrganizasyon);
            if (organizasyon != null)
            {
                return Ok(organizasyon);
            }
            else
            {
                return NotFound("Belirtilen ID'ye sahip organizasyon bulunamadı veya güncelleme başarısız oldu.");
            }
        }

        [HttpGet]
        [Route("searchOrganizasyon/{data}")]
        public IActionResult SearchOrganizasyon(string data)
        {
            return Ok(_organizasyonRepository.SearchOrganizasyon(data));
        }

    }
}