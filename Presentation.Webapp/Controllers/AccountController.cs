using Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Presentation.Webapp.ViewModels;

namespace Presentation.Webapp.Controllers
{
    public class AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager) : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager = userManager;
        
        // Registration for new users
        [HttpGet]
        [Route("account/register")]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [Route("account/register")]
        public async Task<IActionResult> Register(RegisterViewModel register)
        {
            if (!ModelState.IsValid)
            {
                return View(register);
            }
            return RedirectToAction("SetPassword", new { email = register.Email });
        }

        // Password for new users
        [HttpGet]
        [Route("account/setpassword")]
        public IActionResult SetPassword(string email)
        {
            var newEmail = new RegisterViewModel
            {
                Email = email
            };
            return View(newEmail);
        }
        [HttpPost]
        [Route("account/setpassword")]
        public async Task<IActionResult> SetPassword(SetPasswordViewModel setPassword)
        {             
            if (!ModelState.IsValid)
            {
                return View(setPassword);
            }

            var user = new ApplicationUser
            {
                UserName = setPassword.Email,
                Email = setPassword.Email,
            };

            var result = await _userManager.CreateAsync(user, setPassword.Password);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return View(setPassword);
            }

            await _userManager.AddToRoleAsync(user, "Member");

            return RedirectToAction("SignIn");
        }

        // Sign in for existing users
        [HttpGet]
        [Route("account/signin")]
        public IActionResult SignIn()
        {
            return View();
        }
    }
}
