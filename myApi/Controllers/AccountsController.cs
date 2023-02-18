using AutoMapper;
using Data.DTOs;
using Data.IRepository;
using Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace Controllers
{
    [ApiController]
    [Route("Api/[controller]")]
    public class AccountsController : Controller
    {
        private readonly ILogger<AccountsController> _logger;
        private readonly IMapper _mapper;
        private readonly UserManager<ApiUser> _userManager;
        // private readonly SignInManager<ApiUser> _signInManager;
        private readonly IAuthManager _authManager;
        public AccountsController(
            UserManager<ApiUser> userManager,
            ILogger<AccountsController> logger,
            IMapper mapper,
            IAuthManager authManager)
        {
            _logger = logger;
            _mapper = mapper;
            _userManager = userManager;
            // _signInManager = signInManager;
            _authManager = authManager;
        }
        [HttpPost]
        [Route("Register")]

        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Register([FromBody] UserDTO userDTO)
        {
            _logger.LogInformation($"Registeration attempt from {userDTO.Email} ");
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var user = _mapper.Map<ApiUser>(userDTO);
                user.UserName = user.Email;
                var result = await _userManager.CreateAsync(user, userDTO.Password);
                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(error.Code, error.Description);
                        return BadRequest(ModelState);
                    }
                }

                try
                {
                    result = await _userManager.AddToRolesAsync(user, userDTO.Roles);


                }
                catch (System.Exception ex)
                {
                    await _userManager.DeleteAsync(user);
                    _logger.LogError(ex, $"Somthing went Wrong in {nameof(Register)} in Roles ");
                    return Problem("Intenal Server Error. Please Try Again Later", statusCode: 500);
                }
                return Accepted();
                // return result.Succeeded ? Accepted() : BadRequest("Registeration attempt failed");
            }
            catch (System.Exception ex)
            {

                _logger.LogError(ex, $"Somthing went Wrong in {nameof(Register)} ");
                return Problem("Intenal Server Error. Please Try Again Later", statusCode: 500);
                // return StatusCode(500, "Intenal Server Error. Please Try Again Later");
            }
        }
        [HttpPost]
        [Route("Login")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Login([FromBody] LoginUserDTO userDTO)
        {
            _logger.LogInformation($"Login attempt from {userDTO.Email} ");
            if (!ModelState.IsValid)
            {
                _logger.LogError($"failed Login attempt from {userDTO.Email} ");
                return BadRequest(ModelState);
            }
            try
            {
                var result = await _authManager.ValidateUser(userDTO);
                return result ? Accepted(new { Token = await _authManager.CreateToken() }) : Unauthorized(userDTO);
            }
            catch (System.Exception ex)
            {

                _logger.LogError(ex, $"Somthing went Wrong in {nameof(Login)} ");
                return Problem("Intenal Server Error. Please Try Again Later", statusCode: 500);
                // return Problem(ex.ToString(), statusCode: 500);
                // return StatusCode(500, "Intenal Server Error. Please Try Again Later");
            }
        }


    }


}