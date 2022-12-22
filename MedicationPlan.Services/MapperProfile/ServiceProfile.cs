using AutoMapper;
using MedicationPlan.Entity.Models;
using MedicationPlan.Services.Models;

namespace MedicationPlan.Services.MapperProfile;

public class ServicesProfile : Profile {

    public ServicesProfile () {
        #region Doctor
        CreateMap<Doctor, DoctorModel>().ReverseMap();
        CreateMap<Doctor, DoctorPreviewModel>()
            .ForMember(x => x.Univercity, y => y.MapFrom(u => u.Univercity))
            .ForMember(x => x.StartTraining, y => y.MapFrom(u => u.StartTraining))
            .ForMember(x => x.EndTraining, y => y.MapFrom(u => u.EndTraining))
            .ForMember(x => x.Specialization, y => y.MapFrom(u => u.Specialization))
            .ForMember(x => x.WorkExperience, y => y.MapFrom(u => u.WorkExperience));
        #endregion

        #region Medicament
        CreateMap<Medicament, MedicamentModel>().ReverseMap();
        CreateMap<Medicament, MedicamentPreviewModel>()
            .ForMember(x => x.Name, y => y.MapFrom(u => u.Name))
            .ForMember(x => x.Recomendation, y => y.MapFrom(u => u.Recomendation));
        #endregion

        #region Note
        CreateMap<Note, NoteModel>().ReverseMap();
        CreateMap<Note, NotePreviewModel>()
            .ForMember(x => x.DoseMedicament, y => y.MapFrom(u => u.DoseMedicament))
            .ForMember(x => x.StartingMedication, y => y.MapFrom(u => u.StartingMedication))
            .ForMember(x => x.EndingMedication, y => y.MapFrom(u => u.EndingMedication))
            .ForMember(x => x.IntervalMedication, y => y.MapFrom(u => u.IntervalMedication));
        #endregion

        #region Pacient
        CreateMap<Pacient, PacientModel>().ReverseMap();
        CreateMap<Pacient, PacientPreviewModel>();
        #endregion

        #region User
        CreateMap<User, UserModel>().ReverseMap();
        CreateMap<User, UserPreviewModel>()
            .ForMember(x => x.FIO, y => y.MapFrom(u => u.Name))
            .ForMember(x => x.PhoneNumber, y => y.MapFrom(u => u.PhoneNumber))
            .ForMember(x => x.Email, y => y.MapFrom(u => u.Email))
            .ForMember(x => x.Snils, y => y.MapFrom(u => u.Snils))
            .ForMember(x => x.Polis, y => y.MapFrom(u => u.Polis))
            .ForMember(x => x.PasswordHash, y => y.MapFrom(u => u.PasswordHash));
        #endregion
    }

}