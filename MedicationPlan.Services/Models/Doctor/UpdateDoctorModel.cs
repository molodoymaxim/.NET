using MedicationPlan.Entities.Models;
namespace MedicationPlan.Services.Models;
public class UpdateDoctorModel : BaseModel
{
    public string Univercity { get; set; }
    public DateTime StartTraining { get; set; }
    public DateTime EndTraining { get; set; }
    public string Specialization { get; set; }
    public int WorkExperience { get; set; }
    
}