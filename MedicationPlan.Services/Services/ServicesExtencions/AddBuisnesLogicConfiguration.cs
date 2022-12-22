using MedicationPlan.Services.Abstract;
using MedicationPlan.Services.Implementation;
using MedicationPlan.Services.MapperProfile;
using Microsoft.Extensions.DependencyInjection;

namespace MedicationPlan.Services;

public static partial class ServicesExtentions
{
    public static void AddBusinessLogicConfiguration(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(ServicesProfile));

        services.AddScoped<IDoctorService, DoctorService>();
        services.AddScoped<IMedicamentService, MedicamentService>();
        services.AddScoped<INoteService, NoteService>();
        services.AddScoped<IPacientService, PacientService>();
        services.AddScoped<IUserService, UserService>();
    }
}