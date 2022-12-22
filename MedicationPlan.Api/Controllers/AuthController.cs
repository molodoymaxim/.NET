using AutoMapper;
using MedicationPlan.Services.Abstract;
using MedicationPlan.Services.Models;
using MedicationPlan.WebAPI.Models;
using IdentityModel.Client;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CityForum.WebApi.Controllers
{
    /// <summary>
    /// Auth endpoints
    /// </summary>
    [ProducesResponseType(200)]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService authService;
        private readonly IMapper mapper;

        /// <summary>
        /// Auth controller
        /// </summary>
        public AuthController(IAuthService authService, IMapper mapper)
        {
            this.authService = authService;
            this.mapper = mapper;
        }

        [HttpPost]
        [Route("RegisterUser")]
        public async Task<IActionResult> RegisterUser([FromBody] RegisterStudentRequest request)
        {
            var validationResult = request.Validate();
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            try
            {
                RegisterStudentModel registerModel = mapper.Map<RegisterStudentModel>(request);
                StudentModel result = await authService.RegisterUser(registerModel);
                StudentResponse response = mapper.Map<StudentResponse>(result);
                return Ok(response);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [Route("LoginUser")]
        public async Task<IActionResult> LoginUser([FromBody] LoginStudentRequest request)
        {
            var validationResult = request.Validate();
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            try
            {
                LoginStudentModel loginModel = mapper.Map<LoginStudentModel>(request);
                TokenResponse response = await authService.LoginUser(loginModel);
                return Ok(response);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}