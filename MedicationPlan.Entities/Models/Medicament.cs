namespace MedicationPlan.Entities.Models;

public class Medicament : BaseEntity
{
    public string Name { get; set; }
    public string Recomendation { get; set; }
    
    public virtual ICollection<Note> Notes { get; set; }
}