namespace MedicationPlan.Entities.Models;

public class User : BaseEntity
{
    public string FIO { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public int Snils { get; set; }
    public int Polis { get; set; }
    public string PasswordHash { get; set; }
    
    public virtual ICollection<Pacient> Pacients { get; set; }
    public virtual ICollection<Doctor> Doctors { get; set; }
}