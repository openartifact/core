using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace openartifact_core.Controllers
{
    [ApiController]
    public class LoginController : ControllerBase
    {
        [HttpGet]
        [Route("/login")]
        public ChallengeResult Login()
        {
            return Challenge(new AuthenticationProperties { RedirectUri = "/api/metadata" }, "Steam");
        }

        [HttpGet]
        [Route("/logout")]
        public SignOutResult Logout()
        {
            // Instruct the cookies middleware to delete the local cookie created
            // when the user agent is redirected from the external identity provider
            // after a successful authentication flow (e.g Google or Facebook).
            return SignOut(new AuthenticationProperties { },
                CookieAuthenticationDefaults.AuthenticationScheme);
        }
    }
}
