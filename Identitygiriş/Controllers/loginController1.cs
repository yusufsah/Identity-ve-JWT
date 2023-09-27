using Entity.cont;
using Identitygiriş.Models;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using Org.BouncyCastle.Crypto.Macs;

namespace Identitygiriş.Controllers
{
	public class loginController1 : Controller
	{

		private readonly UserManager<appuser> _userManager;


		// crtl .  diyip constractor oluşturduk
        public loginController1(UserManager<appuser> userManager)
        {
            _userManager = userManager;
        }

		[HttpGet]
        public IActionResult Index()
		{
			return View();
		}

        [HttpPost]
        public async Task <IActionResult> Index(UsersinviewModel p)
        {
            if (ModelState.IsValid)
            {


                Random random = new Random();
                int code;
                code = random.Next(100000, 1000000);





                appuser user = new appuser()
                {
                    Email = p.mail,
                    UserName = p.UserName,
                    NameUsername = p.nameSurename,
                    İmageUrl = p.ımageurl,

                    confirmcode = code,
                   
                    

                };

                var resuat=await _userManager.CreateAsync(user, p.password);

                if (resuat.Succeeded)
                {
                    MimeMessage mimeMessage = new MimeMessage();

                    MailboxAddress mailboxAddressfrom = new MailboxAddress("easy cash admin","kahya.yusufsahin@gmail.com"); // kim göndericek
                    MailboxAddress mailboxAddressto = new MailboxAddress("user",user.Email);  // kime

                    mimeMessage.From.Add(mailboxAddressfrom); // kimden gidicek mailboxAddressfrom geleenden
                    mimeMessage.To.Add(mailboxAddressto);  // kime gidicek 

                    var bodyBuildir = new BodyBuilder();
                    bodyBuildir.TextBody = "kayıt işlemini gerçekleştirmek için  onay kodunuz " + code;

                    mimeMessage.Body=bodyBuildir.ToMessageBody();

                    mimeMessage.Subject = "easy cash  onay kodu ";


                    SmtpClient client = new SmtpClient();
                    client.Connect("smtp.gmail.com",587,false);
                    client.Authenticate("kahya.yusufsahin@gmail.com", "dtglybnzsmckvman");

                    client.Send(mimeMessage);
                    client.Disconnect(true);


                    TempData["Mail"] = p.mail;


                    return RedirectToAction("Index", "Gırıs");





                }
                else
                {
                    foreach (var item in resuat.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                        
                    }
                }

            }


            return View(p);
        }

    }
}
