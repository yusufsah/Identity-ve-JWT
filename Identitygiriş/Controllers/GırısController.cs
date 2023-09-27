using Entity.cont;
using Identitygiriş.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Framework;
using System.Security.Claims;

namespace Identitygiriş.Controllers
{
    public class GırısController : Controller
    {

        private readonly SignInManager<appuser> _signInManager;
        private readonly UserManager<appuser> _userManager;

        public GırısController(SignInManager<appuser> signInManager, UserManager<appuser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }




        /// <summary>
        /// /////////////////////////////////////////////////////////
        [HttpGet]
        public IActionResult Index()
        {
            return View();


        }
        [HttpPost]
        public async Task<IActionResult> Index(LoginviewModel p)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(p.username);
                if (user != null &&
                    await _userManager.CheckPasswordAsync(user, p.password))
                {
                  
                   
                    return RedirectToAction("Index", "Profile");
                }
            }
            return View();
        }
    }
}


































//[HttpPost]
//public async Task<IActionResult> Index(LoginviewModel loginviewModel)
//{
//    var result = await _signInManager.PasswordSignInAsync(loginviewModel.username, loginviewModel.password
//        , false, false);

//    if (result.Succeeded)
//    {
//        var user = await _userManager.FindByNameAsync(loginviewModel.username);

//        return RedirectToAction("Index", "açılış");
//    }

//    return View();
//}
//    }