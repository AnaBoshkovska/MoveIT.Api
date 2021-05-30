using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MoveIT.Api.Controllers
{
    
    [AllowAnonymous]
    public class _PublicBaseController : ControllerBase
    {
        public _PublicBaseController() : base()
        {

        }
    }
}
