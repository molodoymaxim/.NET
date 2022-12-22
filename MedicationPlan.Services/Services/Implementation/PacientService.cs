using AutoMapper;
using MedicationPlan.Entity.Models;
using MedicationPlan.Repository;
using MedicationPlan.Services.Abstract;
using MedicationPlan.Services.Models;

namespace MedicationPlan.Services.Implementation;

public class PacientService : IPacientService
{
    private readonly IRepository<Pacient> PacientRepository;
    private readonly IMapper mapper;
    public PacientService(IRepository<Pacient> PacientRepository, IMapper mapper)
    {
        this.PacientRepository = PacientRepository;
        this.mapper = mapper;
    }

    public void DeletePacient(Guid id)
    {
        var PacientToDelete = PacientRepository.GetById(id);
        if (PacientToDelete == null)
        {
            throw new Exception("Pacient not found");
        }

        PacientRepository.Delete(PacientToDelete);
    }

    public PacientModel GetPacient(Guid id)
    {
        var Pacient = PacientRepository.GetById(id);
        return mapper.Map<PacientModel>(Pacient);
    }

    public PageModel<PacientPreviewModel> GetPacients(int limit = 20, int offset = 0)
    {
        var Pacients = PacientRepository.GetAll();
        int totalCount = Pacients.Count();
        var chunk = Pacients.OrderBy(x => x.Name).Skip(offset).Take(limit);

        return new PageModel<PacientPreviewModel>()
        {
            Items = mapper.Map<IEnumerable<PacientPreviewModel>>(Pacients),
            TotalCount = totalCount
        };
    }

    public PacientModel UpdatePacient(Guid id, UpdatePacientModel Pacient)
    {
        var existingPacient = PacientRepository.GetById(id);
        if (existingPacient == null)
        {
            throw new Exception("Pacient not found");
        }

        existingPacient = PacientRepository.Save(existingPacient);
        return mapper.Map<PacientModel>(existingPacient);
    }

    PacientModel IPacientService.CreatePacient(MedicationPlan.Services.Models.PacientModel PacientModel)
    {
      PacientRepository.Save(mapper.Map<Entity.Models.Pacient>(PacientModel));
        return PacientModel;
    }
}