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
    public class UserController : ControllerBase
    {
        private readonly IUserService UserService;
        private readonly IMapper mapper;

        /// <summary>
        /// User controller
        /// </summary>
        public UserController(IUserService  UserService,IMapper mapper)
        {
            this.UserService=UserService;
            this.mapper=mapper;
        }

        
        /// <summary>
        /// Get User by pages
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        
        public IActionResult GetUsers([FromQuery] int limit = 20, [FromQuery] int offset = 0)
        {
            var pageModel =UserService.GetUsers(limit,offset);

            return Ok(mapper.Map<PageResponse<UserResponse>>(pageModel));
        }
        /// <summary>
        /// Delete User
        /// </summary>
    
        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteUser([FromRoute] Guid id)
        {
            try
            {
                UserService.DeleteUser(id);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        /// <summary>
        /// Get User
        /// </summary>
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetUser([FromRoute] Guid id)
        {
            try
            {
                var UserModel =UserService.GetUser(id);
                return Ok(mapper.Map<UserResponse>(UserModel));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        /// <summary>
        /// Update User
        /// </summary>
        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateUser([FromRoute] Guid id, [FromBody] UpdateUserRequest model)
        {
           var validationResult =model.Validate();
           if(!validationResult.IsValid)
           {
            return BadRequest(validationResult.Errors);
           }
           try
           {
            var resultModel =UserService.UpdateUser(id,mapper.Map<UpdateUserModel>(model));
            return Ok(mapper.Map<UserResponse>(resultModel));
           }
           catch(Exception ex)
           {
            return BadRequest(ex.ToString());
           }
        }

        /// <summary>
        /// create User
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult CreateUser([FromBody] UserModel User)
        {
            var response =UserService.CreateUser(User);
            return Ok(response);
        }
          
    }

}