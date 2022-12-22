namespace MedicationPlan.Entities.Models;

public class Pacient : BaseEntity
{
    public Guid UserId { get; set; }

    public virtual User User { get; set; }
    
    public virtual ICollection<Note> Notes { get; set; }
}