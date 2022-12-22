namespace MedicationPlan.WebAPI.Models;
public class LoginStudentRequest : AuthStudentRequest
{
    public string ClientId { get; set; }
    public string ClientSecret { get; set; }
}