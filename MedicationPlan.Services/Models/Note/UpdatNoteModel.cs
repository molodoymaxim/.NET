using MedicationPlan.Entities.Models;
namespace MedicationPlan.Entities.Models;

public class Note : BaseModel
{
    public string DoseMedicament { get; set; }
    public DateTime StartingMedication { get; set; }
    public DateTime EndingMedication { get; set; }
    public TimeSpan IntervalMedication { get; set; }
}