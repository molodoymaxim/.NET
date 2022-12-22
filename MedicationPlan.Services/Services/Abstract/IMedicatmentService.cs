using MedicationPlan.Entities.Models;
namespace MedicationPlan.Entities.Models;

public interface IMedicamentService
{
    MedicamentModel GetMedicament(Guid id);

    MedicamentModel UpdateMedicament(Guid id, UpdateMedicamentModel Medicament);

    void DeleteMedicament(Guid id);

    PageModel<MedicamentPreviewModel> GetMedicaments(int limit = 20, int offset = 0);

    MedicamentModel CreateMedicament(MedicamentModel MedicamentModel);
}