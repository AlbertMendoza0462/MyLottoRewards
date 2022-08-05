using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Facebook;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyLotoRewards.DAL;
using MyLotoRewards.Models;
using System.Security.Claims;

namespace MyLotoRewards.Auth
{
    [Route("/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ILogger<AuthController> logger;
        private readonly Context _context;

        public AuthController(ILogger<AuthController> logger, Context context)
        {
            this.logger = logger;
            this._context = context;
        }

        //Authentication Methods
        /*[HttpGet("getcurrentuser")]
        public async Task<ActionResult<Usuarios>> GetCurrentUsuarios()
        {
            Usuarios currentUsuarios = new Usuarios();

            if (Usuarios.Identity.IsAuthenticated)
            {
                currentUsuarios.EmailAddress = Usuarios.FindFirstValue(ClaimTypes.Email);
                currentUsuarios = await _context.Usuarios.Where(u => u.EmailAddress == currentUsuarios.EmailAddress).FirstOrDefaultAsync();

                if (currentUsuarios == null)
                {
                    currentUsuarios = new Usuarios();
                    currentUsuarios.UsuarioId = _context.Usuarios.Max(user => user.UsuarioId) + 1;
                    currentUsuarios.EmailAddress = Usuarios.FindFirstValue(ClaimTypes.Email);
                    currentUsuarios.Password = Utility.Encrypt(currentUsuarios.EmailAddress);
                    currentUsuarios.Source = "EXTL";

                    _context.Usuarios.Add(currentUsuarios);
                    await _context.SaveChangesAsync();
                }
            }

            return await Task.FromResult(currentUsuarios);
        }*/

        [HttpGet("logout")]
        public async Task LogOutUsuarios()
        {
            await HttpContext.SignOutAsync(new AuthenticationProperties { RedirectUri = "/" });
            Response.Redirect("/");
        }

        [HttpGet("FacebookSignIn")]
        public async Task FacebookSignIn()
        {
            await HttpContext.ChallengeAsync(FacebookDefaults.AuthenticationScheme,
                new AuthenticationProperties { RedirectUri = "/" });
        }

        [HttpGet("GoogleSignIn")]
        public async Task GoogleSignIn()
        {
            await HttpContext.ChallengeAsync(GoogleDefaults.AuthenticationScheme,
                new AuthenticationProperties { RedirectUri = "/" });
        }
    }
}
