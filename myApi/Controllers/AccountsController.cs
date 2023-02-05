using AutoMapper;
using Data.DTOs;
using Data.IRepository;
using Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
namespace Controllers
{
    [ApiController]
    [Route("Api/[controller]")]
    public class AccountsController : Controller
    {
        private readonly ILogger<AccountsController> _logger;
        private readonly IMapper _mapper;
        private readonly UserManager<ApiUser> _userManager;
        private readonly SignInManager<ApiUser> _signInManager;
        public AccountsController(UserManager<ApiUser> userManager, SignInManager<ApiUser> signInManager, ILogger<AccountsController> logger, IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        [HttpPost]
        [Route("Register")]

        [ProducesResponseType(StatusCodes.Status202Accepted)]
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
                var result = await _userManager.CreateAsync(user, userDTO.Password);
                return result.Succeeded ? Accepted() : BadRequest("Registeration attempt failed");
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
        public async Task<IActionResult> Login([FromBody] LoginUserDTO userDTO)
        {
            _logger.LogInformation($"Login attempt from {userDTO.Email} ");
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var result = await _signInManager.PasswordSignInAsync(userDTO.Email, userDTO.Password, false, false);
                return result.Succeeded ? Accepted() : Unauthorized(userDTO);
            }
            catch (System.Exception ex)
            {

                _logger.LogError(ex, $"Somthing went Wrong in {nameof(Login)} ");
                return Problem("Intenal Server Error. Please Try Again Later", statusCode: 500);
                // return StatusCode(500, "Intenal Server Error. Please Try Again Later");
            }
        }


    }


}