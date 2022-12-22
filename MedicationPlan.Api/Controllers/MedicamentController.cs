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
    public class MedicamentController : ControllerBase
    {
        private readonly IMedicamentService MedicamentService;
        private readonly IMapper mapper;

        /// <summary>
        /// Medicament controller
        /// </summary>
        public MedicamentController(IMedicamentService  MedicamentService,IMapper mapper)
        {
            this.MedicamentService=MedicamentService;
            this.mapper=mapper;
        }

        
        /// <summary>
        /// Get Medicament by pages
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        
        public IActionResult GetMedicaments([FromQuery] int limit = 20, [FromQuery] int offset = 0)
        {
            var pageModel =MedicamentService.GetMedicaments(limit,offset);

            return Ok(mapper.Map<PageResponse<MedicamentResponse>>(pageModel));
        }
        /// <summary>
        /// Delete Medicament
        /// </summary>
    
        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteMedicament([FromRoute] Guid id)
        {
            try
            {
                MedicamentService.DeleteMedicament(id);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        /// <summary>
        /// Get Medicament
        /// </summary>
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetMedicament([FromRoute] Guid id)
        {
            try
            {
                var MedicamentModel =MedicamentService.GetMedicament(id);
                return Ok(mapper.Map<MedicamentResponse>(MedicamentModel));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        /// <summary>
        /// Update Medicament
        /// </summary>
        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateMedicament([FromRoute] Guid id, [FromBody] UpdateMedicamentRequest model)
        {
           var validationResult =model.Validate();
           if(!validationResult.IsValid)
           {
            return BadRequest(validationResult.Errors);
           }
           try
           {
            var resultModel =MedicamentService.UpdateMedicament(id,mapper.Map<UpdateMedicamentModel>(model));
            return Ok(mapper.Map<MedicamentResponse>(resultModel));
           }
           catch(Exception ex)
           {
            return BadRequest(ex.ToString());
           }
        }

        /// <summary>
        /// create Medicament
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult CreateMedicament([FromBody] MedicamentModel Medicament)
        {
            var response =MedicamentService.CreateMedicament(Medicament);
            return Ok(response);
        }
          
    }

}