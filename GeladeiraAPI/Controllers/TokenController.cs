using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using Domain.Resources;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GeladeiraAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        ILoginService _loginService;

        public TokenController(ILoginService loginService)
        {
            _loginService = loginService;
        }
        
        [HttpPost("Login")]
        public IActionResult Login([FromBody] LoginResource userLogin)
        {
            if (userLogin.Nome == null && userLogin.Senha == "password")
            {
                var token = _loginService.GenerateJwtToken(userLogin.Nome);
                return Ok(new { token });
            }
            return Unauthorized();
        }

       
    }
}
