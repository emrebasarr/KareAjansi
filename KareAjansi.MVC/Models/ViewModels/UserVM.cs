using Microsoft.AspNetCore.Identity;

namespace KareAjansi.MVC.Models.ViewModels
{
    public class UserVM
    {
        public List<IdentityUser> Users { get; set; }
        public Dictionary<string, List<string>> UserRoles { get; set; }
    }
}