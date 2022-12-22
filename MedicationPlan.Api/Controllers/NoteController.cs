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
    public class NoteController : ControllerBase
    {
        private readonly INoteService NoteService;
        private readonly IMapper mapper;

        /// <summary>
        /// Note controller
        /// </summary>
        public NoteController(INoteService  NoteService,IMapper mapper)
        {
            this.NoteService=NoteService;
            this.mapper=mapper;
        }

        
        /// <summary>
        /// Get Note by pages
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        
        public IActionResult GetNotes([FromQuery] int limit = 20, [FromQuery] int offset = 0)
        {
            var pageModel =NoteService.GetNotes(limit,offset);

            return Ok(mapper.Map<PageResponse<NoteResponse>>(pageModel));
        }
        /// <summary>
        /// Delete Note
        /// </summary>
    
        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteNote([FromRoute] Guid id)
        {
            try
            {
                NoteService.DeleteNote(id);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        /// <summary>
        /// Get Note
        /// </summary>
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetNote([FromRoute] Guid id)
        {
            try
            {
                var NoteModel =NoteService.GetNote(id);
                return Ok(mapper.Map<NoteResponse>(NoteModel));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        /// <summary>
        /// Update Note
        /// </summary>
        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateNote([FromRoute] Guid id, [FromBody] UpdateNoteRequest model)
        {
           var validationResult =model.Validate();
           if(!validationResult.IsValid)
           {
            return BadRequest(validationResult.Errors);
           }
           try
           {
            var resultModel =NoteService.UpdateNote(id,mapper.Map<UpdateNoteModel>(model));
            return Ok(mapper.Map<NoteResponse>(resultModel));
           }
           catch(Exception ex)
           {
            return BadRequest(ex.ToString());
           }
        }

        /// <summary>
        /// create Note
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult CreateNote([FromBody] NoteModel Note)
        {
            var response =NoteService.CreateNote(Note);
            return Ok(response);
        }
          
    }

}