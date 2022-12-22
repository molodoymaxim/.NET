using MedicationPlan.Entities.Models;
namespace MedicationPlan.Entities.Models;

public class Pacient : BaseModel
{
    public Guid UserId { get; set; }

    public virtual User User { get; set; }

}