using jwt_core_token.DAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace jwt_core_token.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class unutmaAPIcontroller : ControllerBase
    {
        [HttpGet("[action]")]
        public IActionResult login()
        {



            return Created("",new bulidToken().creatToken());
        }
        [Authorize]
        [HttpGet("[action]")]
        public IActionResult page1()
        {

            return Ok("sayda 1 girişiniz başarlı ");
        }

    }
}
