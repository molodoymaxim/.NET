using MedicationPlan.Entities.Models;
namespace MedicationPlan.Entities.Models;

public interface INoteService
{
    NoteModel GetNote(Guid id);

    NoteModel UpdateNote(Guid id, UpdateNoteModel Note);

    void DeleteNote(Guid id);

    PageModel<NotePreviewModel> GetNotes(int limit = 20, int offset = 0);

    NoteModel CreateNote(NoteModel NoteModel);
}