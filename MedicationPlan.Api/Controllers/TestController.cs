using MedicationPlan.Entities.Models;
using MedicationPlan.Repository;
using Microsoft.AspNetCore.Mvc;

namespace MedicationPlan.Api.Controllers;
[ProducesResponseType(200)]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
public class TestController : ControllerBase
{
    private IRepository<User> _repository;

    /// <summary>
    /// Users controller
    /// </summary>
    public TestController(IRepository<User> repository)
    {
        _repository = repository;
    }

    /// <summary>
    /// Get users
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public IActionResult GetUsers()
    {
        User user = new User();
        user.PhoneNumber = "79223432";
        user.Email = "email";
        user.FIO = "Maxim mma sdf";
        user.PasswordHash = "dfasdfasdfasdfasdf";
        user.Polis = 234234;
        user.Snils = 23423;
        _repository.Save(user);

        _repository.Save(user);


        return Ok(_repository.GetAll().First());
    }
}
