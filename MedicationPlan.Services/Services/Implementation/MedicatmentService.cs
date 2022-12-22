using AutoMapper;
using MedicationPlan.Entity.Models;
using MedicationPlan.Repository;
using MedicationPlan.Services.Abstract;
using MedicationPlan.Services.Models;

namespace MedicationPlan.Services.Implementation;

public class MedicamentService : IMedicamentService
{
    private readonly IRepository<Medicament> MedicamentRepository;
    private readonly IMapper mapper;
    public MedicamentService(IRepository<Medicament> MedicamentRepository, IMapper mapper)
    {
        this.MedicamentRepository = MedicamentRepository;
        this.mapper = mapper;
    }

    public void DeleteMedicament(Guid id)
    {
        var MedicamentToDelete = MedicamentRepository.GetById(id);
        if (MedicamentToDelete == null)
        {
            throw new Exception("Medicament not found");
        }

        MedicamentRepository.Delete(MedicamentToDelete);
    }

    public MedicamentModel GetMedicament(Guid id)
    {
        var Medicament = MedicamentRepository.GetById(id);
        return mapper.Map<MedicamentModel>(Medicament);
    }

    public PageModel<MedicamentPreviewModel> GetMedicaments(int limit = 20, int offset = 0)
    {
        var Medicaments = MedicamentRepository.GetAll();
        int totalCount = Medicaments.Count();
        var chunk = Medicaments.OrderBy(x => x.Name).Skip(offset).Take(limit);

        return new PageModel<MedicamentPreviewModel>()
        {
            Items = mapper.Map<IEnumerable<MedicamentPreviewModel>>(Medicaments),
            TotalCount = totalCount
        };
    }

    public MedicamentModel UpdateMedicament(Guid id, UpdateMedicamentModel Medicament)
    {
        var existingMedicament = MedicamentRepository.GetById(id);
        if (existingMedicament == null)
        {
            throw new Exception("Medicament not found");
        }

        existingMedicament.Name = Medicament.Name;
        existingMedicament.Recomendation = Medicament.Recomendation;

        existingMedicament = MedicamentRepository.Save(existingMedicament);
        return mapper.Map<MedicamentModel>(existingMedicament);
    }

    MedicamentModel IMedicamentService.CreateMedicament(MedicationPlan.Services.Models.MedicamentModel MedicamentModel)
    {
      MedicamentRepository.Save(mapper.Map<Entity.Models.Medicament>(MedicamentModel));
        return MedicamentModel;
    }
}