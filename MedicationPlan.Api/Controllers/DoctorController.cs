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
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorService DoctorService;
        private readonly IMapper mapper;

        /// <summary>
        /// Doctor controller
        /// </summary>
        public DoctorController(IDoctorService  DoctorService,IMapper mapper)
        {
            this.DoctorService=DoctorService;
            this.mapper=mapper;
        }

        
        /// <summary>
        /// Get Doctor by pages
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        
        public IActionResult GetDoctors([FromQuery] int limit = 20, [FromQuery] int offset = 0)
        {
            var pageModel =DoctorService.GetDoctors(limit,offset);

            return Ok(mapper.Map<PageResponse<DoctorResponse>>(pageModel));
        }
        /// <summary>
        /// Delete Doctor
        /// </summary>
    
        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteDoctor([FromRoute] Guid id)
        {
            try
            {
                DoctorService.DeleteDoctor(id);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        /// <summary>
        /// Get Doctor
        /// </summary>
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetDoctor([FromRoute] Guid id)
        {
            try
            {
                var DoctorModel =DoctorService.GetDoctor(id);
                return Ok(mapper.Map<DoctorResponse>(DoctorModel));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        /// <summary>
        /// Update Doctor
        /// </summary>
        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateDoctor([FromRoute] Guid id, [FromBody] UpdateDoctorRequest model)
        {
           var validationResult =model.Validate();
           if(!validationResult.IsValid)
           {
            return BadRequest(validationResult.Errors);
           }
           try
           {
            var resultModel =DoctorService.UpdateDoctor(id,mapper.Map<UpdateDoctorModel>(model));
            return Ok(mapper.Map<DoctorResponse>(resultModel));
           }
           catch(Exception ex)
           {
            return BadRequest(ex.ToString());
           }
        }

        /// <summary>
        /// create Doctor
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult CreateDoctor([FromBody] DoctorModel Doctor)
        {
            var response =DoctorService.CreateDoctor(Doctor);
            return Ok(response);
        }
          
    }

}