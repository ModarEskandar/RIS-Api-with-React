using AutoMapper;
using Data.DTOs;
using Data.IRepository;
using Data.Models;
using Microsoft.AspNetCore.Authorization;
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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet]
        public async Task<IActionResult> GetPatients([FromQuery] RequestParams requestParams)
        {

            var results = await _unitOfWork.patients.GetAll(requestParams);
                var patients = _mapper.Map<ICollection<PatientDTO>>(results);
            return Ok(patients);
        }
        [Authorize]
        [HttpGet("{id:int}", Name = "GetPatientById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetPatientById(int id)
        {

            var result = await _unitOfWork.patients.GetById(id);
                var patient = _mapper.Map<PatientDTO>(result);
                return Ok(patient);

        }
        [Authorize("Administrator")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreatePatient([FromBody] CreatePatientDTO patientDTO)
        {
            _logger.LogInformation($"Create Patient attempt from {patientDTO} ");
            if (!ModelState.IsValid)
            {
                _logger.LogError($"failed Create patient attempt from {patientDTO} ");
                return BadRequest(ModelState);
            }

            var patient = _mapper.Map<Patient>(patientDTO);
                await _unitOfWork.patients.Insert(patient);
                await _unitOfWork.Save();
                return CreatedAtRoute("GetPatientById", new { id = patient.Id }, patient);


        }
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdatePatient(int id, [FromBody] CreatePatientDTO patientDTO)
        {
            _logger.LogInformation($"Update Patient attempt from {patientDTO} ");
            if (!ModelState.IsValid || id < 1)
            {
                _logger.LogError($"failed Update patient attempt from {patientDTO} ");
                return BadRequest(ModelState);
            }

            var patient = await _unitOfWork.patients.GetById(id);
                if (patient != null)
                {
                    _mapper.Map(patientDTO, patient);
                    _unitOfWork.patients.Update(patient);
                    await _unitOfWork.Save();
                    return NoContent();

                }
                _logger.LogError($"updated patient is not found {patientDTO} ");
                return BadRequest("Submitted Data is invalid");


        }
        [Authorize("user")]
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeletePatient(int id)
        {
            _logger.LogInformation($"Delete attempt for patient with id {id} ");
            if (id < 1)
            {
                _logger.LogError($"failed Delete  attempt for patient with id {id}  ");
                return BadRequest(ModelState);
            }

            var patient = await _unitOfWork.patients.GetById(id);
                if (patient != null)
                {
                    await _unitOfWork.patients.Delete(patient.Id);
                    await _unitOfWork.Save();
                    return NoContent();

                }
                _logger.LogError($"deleted patient with id {id} is not found");
                return BadRequest("Submitted Data is invalid");


        }


    }
}