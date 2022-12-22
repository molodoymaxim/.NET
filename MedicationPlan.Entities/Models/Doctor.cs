namespace MedicationPlan.Entities.Models;

public class Doctor : BaseEntity
{
    public Guid UnicGuid { get; set; }
    public string Univercity { get; set; }
    public DateTime StartTraining { get; set; }
    public DateTime EndTraining { get; set; }
    public string Specialization { get; set; }
    public int WorkExperience { get; set; }
    
    public Guid UserId { get; set; }
    public virtual User User { get; set; }
    
    public virtual ICollection<Note> Notes { get; set; }
}