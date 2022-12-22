using AutoMapper;
using MedicationPlan.Entity.Models;
using MedicationPlan.Repository;
using MedicationPlan.Services.Abstract;
using MedicationPlan.Services.Models;

namespace MedicationPlan.Services.Implementation;

public class DoctorService : IDoctorService
{
    private readonly IRepository<Doctor> DoctorRepository;
    private readonly IMapper mapper;
    public DoctorService(IRepository<Doctor> DoctorRepository, IMapper mapper)
    {
        this.DoctorRepository = DoctorRepository;
        this.mapper = mapper;
    }

    public void DeleteDoctor(Guid id)
    {
        var DoctorToDelete = DoctorRepository.GetById(id);
        if (DoctorToDelete == null)
        {
            throw new Exception("Doctor not found");
        }

        DoctorRepository.Delete(DoctorToDelete);
    }

    public DoctorModel GetDoctor(Guid id)
    {
        var Doctor = DoctorRepository.GetById(id);
        return mapper.Map<DoctorModel>(Doctor);
    }

    public PageModel<DoctorPreviewModel> GetDoctors(int limit = 20, int offset = 0)
    {
        var Doctors = DoctorRepository.GetAll();
        int totalCount = Doctors.Count();
        var chunk = Doctors.OrderBy(x => x.Name).Skip(offset).Take(limit);

        return new PageModel<DoctorPreviewModel>()
        {
            Items = mapper.Map<IEnumerable<DoctorPreviewModel>>(Doctors),
            TotalCount = totalCount
        };
    }

    public DoctorModel UpdateDoctor(Guid id, UpdateDoctorModel Doctor)
    {
        var existingDoctor = DoctorRepository.GetById(id);
        if (existingDoctor == null)
        {
            throw new Exception("Doctor not found");
        }

        existingDoctor.Univercity = Doctor.Univercity;
        existingDoctor.StartTraining = Doctor.StartTraining;
        existingDoctor.EndTraining = Doctor.EndTraining;
        existingDoctor.Specialization = Doctor.Specialization;
        existingDoctor.WorkExperience = Doctor.WorkExperience;

        existingDoctor = DoctorRepository.Save(existingDoctor);
        return mapper.Map<DoctorModel>(existingDoctor);
    }

    DoctorModel IDoctorService.CreateDoctor(MedicationPlan.Services.Models.DoctorModel DoctorModel)
    {
      DoctorRepository.Save(mapper.Map<Entity.Models.Doctor>(DoctorModel));
        return DoctorModel;
    }
}