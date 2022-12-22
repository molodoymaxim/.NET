using MedicationPlan.Entities.Models;
namespace MedicationPlan.Services.Models;
public class DoctorModel : BaseModel
{
    public Guid UnicGuid { get; set; }
    public string Univercity { get; set; }
    public DateTime StartTraining { get; set; }
    public DateTime EndTraining { get; set; }
    public string Specialization { get; set; }
    public int WorkExperience { get; set; }
    public Guid UserId { get; set; }
}