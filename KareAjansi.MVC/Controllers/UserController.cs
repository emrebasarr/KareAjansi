using KareAjansi.MVC.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace KareAjansi.MVC.Controllers
{
    //[Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager) 
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(RegisterVM register, List<string> roles)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser
                {
                    Email = register.Email,
                    UserName = register.Username
                };

                var result = await _userManager.CreateAsync(user,register.ConfirmPassword);
                if (result.Succeeded)
                {
                    if (roles.Count > 0)
                    {
                        foreach (var role in roles)
                        {
                            await _userManager.AddToRoleAsync(user, role);
                        }
                    }
                    return RedirectToAction("Index");
                }
            }
            return View();
        }

        public IActionResult Index()
        {
            var viewModelUser = new UserVM
            {
                Users = _userManager.Users.ToList(),
                UserRoles = new Dictionary<string, List<string>>()
            };

            foreach (var user in viewModelUser.Users)
            {
                var userRole = _userManager.GetRolesAsync(user).Result;
                viewModelUser.UserRoles[user.Id] = userRole.ToList();
            }
            ViewBag.Roles = _roleManager.Roles.ToList();
            return View(viewModelUser);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                var result = await _userManager.DeleteAsync(user);
                if (result.Succeeded)
                {
                    TempData["Result"] = "Kullanıcı başarıyla silindi.";
                }
                else
                {
                    TempData["Result"] = "Kullanıcı silinirken hata oluştu.";
                }
            }
            else
            {
                TempData["Result"] = "Kullanıcı bulunamadı.";
            }
            return RedirectToAction("Index");
        }
    }
}