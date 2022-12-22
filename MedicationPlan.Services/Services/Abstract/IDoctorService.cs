using MedicationPlan.Entities.Models;
namespace MedicationPlan.Entities.Models;

public interface IDoctorService
{
    DoctorModel GetDoctor(Guid id);

    DoctorModel UpdateDoctor(Guid id, UpdateDoctorModel Doctor);

    void DeleteDoctor(Guid id);

    PageModel<DoctorPreviewModel> GetDoctors(int limit = 20, int offset = 0);

    DoctorModel CreateDoctor(DoctorModel DoctorModel);
}