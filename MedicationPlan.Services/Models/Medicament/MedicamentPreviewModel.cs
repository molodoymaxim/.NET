using MedicationPlan.Entities.Models;
namespace MedicationPlan.Entities.Models;

public class Medicament : BaseEntity
{
    public string Name { get; set; }
    public string Recomendation { get; set; }
    
}