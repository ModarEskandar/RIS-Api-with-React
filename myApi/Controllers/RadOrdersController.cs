using AutoMapper;
using Data.DTOs;
using Data.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace Controllers
{
    [ApiController]
    [Route("Api/[controller]")]
    public class RadOrdersController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<RadOrdersController> _logger;
        private readonly IMapper _mapper;
        public RadOrdersController(IUnitOfWork unitOfWork, ILogger<RadOrdersController> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetRadOrders()
        {
            try
            {
                var results = await _unitOfWork.radOrders.GetAll();
                var radOrders = _mapper.Map<ICollection<RadOrderDTO>>(results);
                return Ok(radOrders);
            }
            catch (System.Exception)
            {
                _logger.LogError($"somthing went wrong in the {nameof(RadOrdersController)}");
                return StatusCode(500, "Internal Server Error. Please Try Again Later");
            }

        }
    }
}