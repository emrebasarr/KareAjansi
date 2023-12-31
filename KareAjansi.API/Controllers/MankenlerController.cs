using KareAjansi.BLL.DTOs;
using KareAjansi.BLL.Repositories;
using KareAjansi.DAL.Models.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KareAjansi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MankenlerController : ControllerBase
    {
        private readonly IMankenRepository _mankenRepository;

        public MankenlerController(IMankenRepository mankenRepository) 
        {
            _mankenRepository = mankenRepository;
        }

        [HttpGet]
        [Route("getallmankenler")]
        public IActionResult GetAllMankenler()
        {
            var mankenler = _mankenRepository.GetAllMankenler();
            return Ok(mankenler);
        }

        [HttpGet]
        [Route("getmanken/{id}")]
        public IActionResult GetManken(int id)
        {
            var manken = _mankenRepository.GetMankenById(id);
            if (manken == null)
            {
                return NotFound(); 
            }
            return Ok(manken);
        }

        [HttpPost]
        [Route("addmanken")]
        public IActionResult AddManken([FromBody] MankenDTO manken)
        {
            if (manken == null)
            {
                return BadRequest("Manken bilgileri boş olamaz");
            }
            else
            {
                _mankenRepository.AddManken(manken);
                return Ok("Manken Başarıyla Eklendi");
            }
        }

        [HttpDelete]
        [Route("deletemanken/{id}")]
        public IActionResult DeleteManken(int id)
        {
            var deletedManken = _mankenRepository.DeleteManken(id);

            if (deletedManken == null)
            {
                return NotFound(); 
            }

            return Ok(deletedManken); 
        }

        [HttpPut]
        [Route("updatemanken")]
        public IActionResult UpdateManken([FromBody] MankenDTO updatedManken)
        {
            var updateManken = _mankenRepository.UpdateManken(updatedManken);
            if (updateManken != null)
            {
                return Ok(updateManken);
            }
            else
            {
                return NotFound("Belirtilen ID'ye sahip manken bulunamadı veya güncelleme başarısız oldu.");
            }
        }

        [HttpGet]
        [Route("searchmanken/{data}")]
        public IActionResult SearchManken(string data)
        {
            return Ok(_mankenRepository.SearchManken(data));
        }
    }
}