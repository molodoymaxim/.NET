using AutoMapper;
using MedicationPlan.Entity.Models;
using MedicationPlan.Repository;
using MedicationPlan.Services.Abstract;
using MedicationPlan.Services.Models;

namespace MedicationPlan.Services.Implementation;

public class NoteService : INoteService
{
    private readonly IRepository<Note> NoteRepository;
    private readonly IMapper mapper;
    public NoteService(IRepository<Note> NoteRepository, IMapper mapper)
    {
        this.NoteRepository = NoteRepository;
        this.mapper = mapper;
    }

    public void DeleteNote(Guid id)
    {
        var NoteToDelete = NoteRepository.GetById(id);
        if (NoteToDelete == null)
        {
            throw new Exception("Note not found");
        }

        NoteRepository.Delete(NoteToDelete);
    }

    public NoteModel GetNote(Guid id)
    {
        var Note = NoteRepository.GetById(id);
        return mapper.Map<NoteModel>(Note);
    }

    public PageModel<NotePreviewModel> GetNotes(int limit = 20, int offset = 0)
    {
        var Notes = NoteRepository.GetAll();
        int totalCount = Notes.Count();
        var chunk = Notes.OrderBy(x => x.Name).Skip(offset).Take(limit);

        return new PageModel<NotePreviewModel>()
        {
            Items = mapper.Map<IEnumerable<NotePreviewModel>>(Notes),
            TotalCount = totalCount
        };
    }

    public NoteModel UpdateNote(Guid id, UpdateNoteModel Note)
    {
        var existingNote = NoteRepository.GetById(id);
        if (existingNote == null)
        {
            throw new Exception("Note not found");
        }

        existingNote.DoseMedicament = Note.DoseMedicament;
        existingNote.StartingMedication = Note.StartingMedication;
        existingNote.EndingMedication = Note.EndingMedication;
        existingNote.IntervalMedication = Note.IntervalMedication;

        existingNote = NoteRepository.Save(existingNote);
        return mapper.Map<NoteModel>(existingNote);
    }

    NoteModel INoteService.CreateNote(MedicationPlan.Services.Models.NoteModel NoteModel)
    {
        NoteRepository.Save(mapper.Map<Entity.Models.Note>(NoteModel));
        return NoteModel;
    }
}