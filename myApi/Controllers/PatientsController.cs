using AutoMapper;
using Data.DTOs;
using Data.IRepository;
using Data.Models;
using Microsoft.AspNetCore.Mvc;
namespace Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class PatientsController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<PatientsController> _logger;
        private readonly IMapper _mapper;
        public PatientsController(IUnitOfWork unitOfWork, ILogger<PatientsController> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetPatients()
        {
            try
            {
                var results = await _unitOfWork.patients.GetAll();
                var patients = _mapper.Map<ICollection<PatientDTO>>(results);
                return Ok(patients);
            }
            catch (System.Exception)
            {
                _logger.LogError($"somthing went wrong in the {nameof(PatientsController)}");
                return StatusCode(500, "Internal Server Error. Please Try Again Later");
            }
        }



    }
}