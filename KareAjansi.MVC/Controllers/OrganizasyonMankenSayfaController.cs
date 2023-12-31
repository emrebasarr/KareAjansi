using Microsoft.AspNetCore.Mvc;

namespace KareAjansi.MVC.Controllers
{
    public class OrganizasyonMankenSayfaController : Controller
    {
        public IActionResult OrganizasyonMankenListe()
        {
            return View();
        }

        public IActionResult OrganizasyonMankenEkle()
        {
            return View();
        }
    }
}