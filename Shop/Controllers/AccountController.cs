using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using Shop.Models;
using Shop.ViewModels;

namespace Shop.Controllers
{
    public class AccountController : Controller
    {
        private readonly TreatContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public AccountController (UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, TreatContext db)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _db = db;
        }
        public ActionResult Index()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Register (RegisterViewModel model)
        {
            var user = new ApplicationUser { UserName = model.Name, Email = model.Email };
            IdentityResult result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
    }
}