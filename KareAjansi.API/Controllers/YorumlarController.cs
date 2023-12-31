using KareAjansi.BLL.DTOs;
using KareAjansi.BLL.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KareAjansi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class YorumlarController : ControllerBase
    {
        private readonly IYorumRepository _yorumRepository;

        public YorumlarController(IYorumRepository yorumRepository) 
        {
            _yorumRepository = yorumRepository;
        }

        [HttpGet]
        [Route("getyorumlarbymankenid/{mankenId}")]
        public IActionResult GetYorumlarByMankenId(int mankenId)
        {
            var yorumlar = _yorumRepository.GetYorumlarByMankenId(mankenId);
            return Ok(yorumlar);
        }

        [HttpPost]
        [Route("addyorum")]
        public IActionResult AddYorum([FromBody] YorumDTO yorum)
        {
            if (yorum == null)
            {
                return BadRequest("Yorum bilgileri boş olamaz");
            }
            else
            {
                _yorumRepository.AddYorum(yorum);
                return Ok("Yorum Başarıyla Eklendi");
            }
        }

        [HttpDelete]
        [Route("deleteyorum/{id}")]
        public IActionResult DeleteYorum(int id)
        {
            var deletedYorum = _yorumRepository.DeleteYorum(id);

            if (deletedYorum == null)
            {
                return NotFound();
            }

            return Ok(deletedYorum);
        }

        [HttpPut]
        [Route("updateyorum")]
        public IActionResult UpdateYorum([FromBody] YorumDTO updatedYorum)
        {
            var updateYorum = _yorumRepository.UpdateYorum(updatedYorum);
            if (updateYorum != null)
            {
                return Ok(updateYorum);
            }
            else
            {
                return NotFound("Belirtilen ID'ye sahip yorum bulunamadı veya güncelleme başarısız oldu.");
            }
        }
    }
}
