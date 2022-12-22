using MedicationPlan.Entities.Models;
namespace MedicationPlan.Entities.Models;

public interface IPacientService
{
    PacientModel GetPacient(Guid id);

    PacientModel UpdatePacient(Guid id, UpdatePacientModel Pacient);

    void DeletePacient(Guid id);

    PageModel<PacientPreviewModel> GetPacients(int limit = 20, int offset = 0);

    PacientModel CreatePacient(PacientModel PacientModel);
}