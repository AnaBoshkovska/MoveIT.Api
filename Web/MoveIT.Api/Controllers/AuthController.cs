using System.Threading.Tasks;

using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;

using MoveIT.Api.Dto;
using MoveIT.Core.Models;
using MoveIT.Core.Services;
using MoveIT.Api.Validators;

namespace MoveIT.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : _PublicBaseController
    {
        private readonly UserManager<User> _userManager;
        private readonly IAuthService _authenticationService;
        private readonly IMapper _mapper;
        
        public AuthController(UserManager<User> userManager, IAuthService authenticationService, IMapper mapper)
        {
            _userManager = userManager;
            _authenticationService = authenticationService;
            _mapper = mapper;   
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterUser registerUser)
        {
            var validator = ValidatorFactory.GetVaidator<RegisterUser>();
            var validatonResult = validator.Validate(registerUser);
            if (!validatonResult.IsValid)
            {
                return BadRequest(validatonResult.Errors);
            }

            var user = _mapper.Map<RegisterUser, User>(registerUser);
            var result = await _userManager.CreateAsync(user, registerUser.Password);

            if (result.Succeeded)
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginUser loginUser)
        {
            var token = await _authenticationService.Authenticate(loginUser.Email, loginUser.Password);

            if (!string.IsNullOrEmpty(token))
            {
                var result = _mapper.Map<LoginUser, AuthenticatedUser>(loginUser);
                result.Token = token;
                return Ok(result);
            }

            return BadRequest("Email or password is incorrect");
        }
    }
}
