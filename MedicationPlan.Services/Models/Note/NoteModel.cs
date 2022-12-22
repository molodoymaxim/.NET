using MedicationPlan.Entities.Models;
namespace MedicationPlan.Entities.Models;

public class Note : BaseModel
{
    public string DoseMedicament { get; set; }
    public DateTime StartingMedication { get; set; }
    public DateTime EndingMedication { get; set; }
    public TimeSpan IntervalMedication { get; set; }
    
    public Guid MedicamentId { get; set; }
    public virtual Medicament Medicament { get; set; }
    
    public Guid PacientId { get; set; }
    public virtual Pacient Pacient{ get; set; }
    
    public Guid Doctorid { get; set; }
    public virtual Doctor Doctor { get; set; }
}