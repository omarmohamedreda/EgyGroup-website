using Egygroup.DAL.Models;
using Egygroup.PL.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVC05_MVC06.DAL.Models.Auth;

namespace Egygroup.PL.Controllers
{
    [Route("account")]
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        // GET /account/login
        [HttpGet("login")]
        public IActionResult Login(string? returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        // POST /account/login
        [HttpPost("login")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel vm, string? returnUrl = null)
        {
            if (!ModelState.IsValid) return View(vm);

            var result = await _signInManager.PasswordSignInAsync(
                vm.Email, vm.Password, vm.RememberMe, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                    return Redirect(returnUrl);

                // Redirect admin to admin panel
                var user = await _userManager.FindByEmailAsync(vm.Email);
                if (user != null && await _userManager.IsInRoleAsync(user, "Admin"))
                    return RedirectToAction("Index", "AdminBrands");

                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError(string.Empty, "Invalid email or password.");
            return View(vm);
        }

        // GET /account/register
        [HttpGet("register")]
        public IActionResult Register() => View();

        // POST /account/register
        [HttpPost("register")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel vm)
        {
            if (!ModelState.IsValid) return View(vm);

            var user = new ApplicationUser
            {
                FirstName = vm.FirstName,
                LastName = vm.LastName,
                UserName = vm.Email,
                Email = vm.Email
            };

            var result = await _userManager.CreateAsync(user, vm.Password);

            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, isPersistent: false);
                return RedirectToAction("Index", "Home");
            }

            foreach (var error in result.Errors)
                ModelState.AddModelError(string.Empty, error.Description);

            return View(vm);
        }

        // POST /account/logout
        [HttpPost("logout")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        // GET /account/access-denied
        [HttpGet("access-denied")]
        public IActionResult AccessDenied() => View();
    }
}