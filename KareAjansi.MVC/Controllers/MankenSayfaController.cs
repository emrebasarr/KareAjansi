using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KareAjansi.MVC.Controllers
{
    //[Authorize]
    public class MankenSayfaController : Controller
    {
        public IActionResult Liste()
        {
            return View();
        }

        public IActionResult Detay()
        {
            return View();
        }

        public IActionResult Ekle()
        {
            return View();
        }

        public IActionResult Guncelle()
        {
            return View();
        }
    }
}