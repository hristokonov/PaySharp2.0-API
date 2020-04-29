using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaySharp.API.Services.Contracts;

namespace PaySharp.API.Controllers.User
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAuthorizationManager authorizationManager;
        private readonly IHttpContextAccessor contextAccessor;
        private readonly IAccountService accountService;
        
        public AccountController(IAuthorizationManager authorizationManager,
            IHttpContextAccessor contextAccessor,
            IAccountService accountService)
        {
            this.authorizationManager = authorizationManager ?? throw new ArgumentNullException(nameof(authorizationManager));
            this.contextAccessor = contextAccessor ?? throw new ArgumentNullException(nameof(contextAccessor));
            this.accountService = accountService ?? throw new ArgumentNullException(nameof(accountService));
        }
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetUserAccounts()

        {
            var claims = contextAccessor.HttpContext.User.Identity as ClaimsIdentity;
            var userID =long.Parse(claims.FindFirst("userId").Value);

            var allUserAccounts = await accountService.GetUserAccountsAsync(userID);

            return Ok(allUserAccounts);
        }


    }
}