using AutoMapper;
using MedicationPlan.Services.Abstract;
using MedicationPlan.Services.Models;
using MedicationPlan.WebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace MedicationPlan.API.Controllers
{
    /// <summary>
    /// </summary>
    [ProducesResponseType(200)]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class PacientController : ControllerBase
    {
        private readonly IPacientService PacientService;
        private readonly IMapper mapper;

        /// <summary>
        /// Pacient controller
        /// </summary>
        public PacientController(IPacientService  PacientService,IMapper mapper)
        {
            this.PacientService=PacientService;
            this.mapper=mapper;
        }

        
        /// <summary>
        /// Get Pacient by pages
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        
        public IActionResult GetPacients([FromQuery] int limit = 20, [FromQuery] int offset = 0)
        {
            var pageModel =PacientService.GetPacients(limit,offset);

            return Ok(mapper.Map<PageResponse<PacientResponse>>(pageModel));
        }
        /// <summary>
        /// Delete Pacient
        /// </summary>
    
        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeletePacient([FromRoute] Guid id)
        {
            try
            {
                PacientService.DeletePacient(id);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        /// <summary>
        /// Get Pacient
        /// </summary>
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetPacient([FromRoute] Guid id)
        {
            try
            {
                var PacientModel =PacientService.GetPacient(id);
                return Ok(mapper.Map<PacientResponse>(PacientModel));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        /// <summary>
        /// Update Pacient
        /// </summary>
        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdatePacient([FromRoute] Guid id, [FromBody] UpdatePacientRequest model)
        {
           var validationResult =model.Validate();
           if(!validationResult.IsValid)
           {
            return BadRequest(validationResult.Errors);
           }
           try
           {
            var resultModel =PacientService.UpdatePacient(id,mapper.Map<UpdatePacientModel>(model));
            return Ok(mapper.Map<PacientResponse>(resultModel));
           }
           catch(Exception ex)
           {
            return BadRequest(ex.ToString());
           }
        }

        /// <summary>
        /// create Pacient
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult CreatePacient([FromBody] PacientModel Pacient)
        {
            var response =PacientService.CreatePacient(Pacient);
            return Ok(response);
        }
          
    }

}