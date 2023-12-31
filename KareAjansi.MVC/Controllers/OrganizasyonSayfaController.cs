using Microsoft.AspNetCore.Mvc;

namespace KareAjansi.MVC.Controllers
{
    public class OrganizasyonSayfaController : Controller
    {
        public IActionResult OrganizasyonListe()
        {
            return View();
        }

        public IActionResult OrganizasyonEkle()
        {
            return View();
        }

        public IActionResult OrganizasyonGuncelle()
        {
            return View();
        }
    }
}