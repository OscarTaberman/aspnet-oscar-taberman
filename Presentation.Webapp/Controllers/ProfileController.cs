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
            if (User.Identity?.IsAuthenticated != true)
            {
                return RedirectToAction("SignIn", "Account");
            }

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
                ExistingProfileImageUrl = string.IsNullOrEmpty(user.ProfileImageUrl) 
                                                ? "/images/profile-image.png" 
                                                : user.ProfileImageUrl,
            };

            return View(profileViewModel);
        }

        [HttpPost]
        [Route("profile")]
        public async Task<IActionResult> UpdateProfile(ProfileViewModel updateUser)
        {
            var currentUser = await userManager.GetUserAsync(User);
            if (currentUser == null)
            {
                return NotFound("User not found.");
            }

            currentUser.FirstName = updateUser.FirstName ?? string.Empty;
            currentUser.LastName = updateUser.LastName ?? string.Empty;
            currentUser.Email = updateUser.Email ?? string.Empty;
            currentUser.PhoneNumber = updateUser.PhoneNumber ?? string.Empty;
            currentUser.ProfileImageUrl = updateUser.ExistingProfileImageUrl ?? string.Empty;

            if (updateUser.ProfileImageUrl != null)
            {
                var fileName = $"{Guid.NewGuid()}_{updateUser.ProfileImageUrl.FileName}";
                var filePath = Path.Combine("wwwroot/images/profiles", fileName);
                using (var stream = System.IO.File.Create(filePath))
                {
                    await updateUser.ProfileImageUrl.CopyToAsync(stream);
                }
                currentUser.ProfileImageUrl = $"/images/profiles/{fileName}";
            }

            var isUpdated = await userManager.UpdateAsync(currentUser);

            if (!isUpdated.Succeeded)
            {
                ModelState.AddModelError(string.Empty, "Failed to update profile.");
                return View("Index", updateUser);
            }

            await signInManager.RefreshSignInAsync(currentUser);

            return RedirectToAction("Index");
        }
    }
}
