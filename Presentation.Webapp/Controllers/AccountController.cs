using Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Presentation.Webapp.ViewModels;

namespace Presentation.Webapp.Controllers
{
    public class AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager) : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager = userManager;
        private readonly SignInManager<ApplicationUser> _signInManager = signInManager;
        
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
            if (string.IsNullOrWhiteSpace(email))
            {
                return RedirectToAction("Register");
            }

            var newEmail = new SetPasswordViewModel
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

        [HttpPost]
        [Route("account/signin")]
        public async Task<IActionResult> SignIn(SignInViewModel signIn)
        {
            if (!ModelState.IsValid)
            {
                return View(signIn);
            }

            var result = await _signInManager.PasswordSignInAsync(signIn.Email, signIn.Password, false, false);

            if (!result.Succeeded)
            {
                ModelState.AddModelError(nameof(SignInViewModel.Password), "Invalid login attempt.");
                return View(signIn);
            }

            return RedirectToAction("Index", "Profile");
        }

        [HttpPost]
        [Route("account/signout")]
        public async Task<IActionResult> SignOutUser()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
