using Entity.cont;
using Identitygiriş.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Identitygiriş.Controllers
{
    public class ConfirmMailController : Controller
    {


        private readonly UserManager<appuser> _userManager;

        public ConfirmMailController(UserManager<appuser> userManager)
        {
            _userManager = userManager;
        }


        /// <summary>
        /// //////////////////////////////////////////////////////////////////////////////

        [HttpGet]
        public IActionResult Index()
        {
            var valuse = TempData["Mail"];
            ViewBag.V = valuse;
           // confirmviewmodel.meil= valuse.ToString();


            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(confirmviewmodel confirmviewmodel)
        {
            var valuse = "kahya.yusufsahin@gmail.com";


            var user = await _userManager.FindByEmailAsync(confirmviewmodel.Email);


            if (user.confirmcode == confirmviewmodel.confirmCode)
            {
                user.EmailConfirmed = true;
                await _userManager.UpdateAsync(user); 
                return RedirectToAction("Index", "açılış");
            }
            else
            {
                return RedirectToAction("Index", "açılış");
            }



            return View();
        }
    }
}