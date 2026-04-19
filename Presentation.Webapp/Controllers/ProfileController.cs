using Infrastructure.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Presentation.Webapp.ViewModels;

namespace Presentation.Webapp.Controllers
{
    [Authorize]
    public class ProfileController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager) : Controller
    {
        [HttpGet]
        [Route("profile")]
        public async Task<IActionResult> Index()
        {
            var user = await userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound("User not found.");
            }

            var profileViewModel = new ProfileViewModel
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email ?? string.Empty,
                PhoneNumber = user.PhoneNumber,
                ExistingProfileImageUrl = null,
            };

            return View(profileViewModel);
        }

        [HttpPost]
        [Route("profile")]
        public async Task<IActionResult> UpdateProfile()
        {
            var user = await userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound("User not found.");
            }

            var updateUser = new ProfileViewModel
            {
                FirstName = user.FirstName ?? string.Empty,
                LastName = user.LastName ?? string.Empty,
                Email = user.Email ?? string.Empty,
                PhoneNumber = user.PhoneNumber,
                ExistingProfileImageUrl = null,
            };

            return RedirectToAction("Index");
        }
    }
}
