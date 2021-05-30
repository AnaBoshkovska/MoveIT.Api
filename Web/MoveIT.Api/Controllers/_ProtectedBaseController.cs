using System.Security.Claims;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MoveIT.Api.Controllers
{
    [Authorize]
    public class _ProtectedBaseController : ControllerBase
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        protected string AuthenticatedUserId =>  _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;

        public _ProtectedBaseController(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
    }
}
