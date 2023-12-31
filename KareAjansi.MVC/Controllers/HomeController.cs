using KareAjansi.Common;
using KareAjansi.MVC.Models;
using KareAjansi.MVC.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Web;

namespace KareAjansi.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public HomeController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM register)
        {
            if (ModelState.IsValid)
            {
                IdentityUser user = new IdentityUser
                {
                    Email = register.Email,
                    UserName = register.Username
                };

                var result = await _userManager.CreateAsync(user,register.Password);
                if (result.Succeeded)
                {
                    var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    var encodeToken = HttpUtility.UrlEncode(token.ToString());
                    string confirmationLink = Url.Action("Confirmation", "Home", new {id =user.Id,token= encodeToken},Request.Scheme);
                    MailSender.SendEmail(register.Email, "Üyelik Aktivasyon", $"{register.Username} kayıt işleminiz başarılı! üyeliğinizi aktif hale getirebilmek için linke tıklayın: {confirmationLink}");
                    return RedirectToAction("Index");
                }
                else
                {
                    List<string> error = new List<string>();
                    foreach (var err in result.Errors)
                    {
                        error.Add(err.Description);
                    }
                    TempData["Error"] = error;
                }
            }
            return View(register);
        }

        public async Task<IActionResult> Confirmation(string? id,string? token)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                var decodeToken = HttpUtility.UrlDecode(token);
                var result = await _userManager.ConfirmEmailAsync(user, decodeToken);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction("Index");
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM login)
        {
            if (ModelState.IsValid)
            {
               IdentityUser user = await _userManager.FindByEmailAsync(login.Email);
               if (user != null)
               {
                    //todo: ispersistant tanımlanacak.
                    var result = await _signInManager.PasswordSignInAsync(user, login.Password, false, false);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index");
                    }
                }
            }
            return View(login);
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index");
        }
    }
}