using MedicationPlan.Entities.Models;
namespace MedicationPlan.Entities.Models;

public interface IUserService
{
    UserModel GetUser(Guid id);

    UserModel UpdateUser(Guid id, UpdateUserModel User);

    void DeleteUser(Guid id);

    PageModel<UserPreviewModel> GetUsers(int limit = 20, int offset = 0);

    UserModel CreateUser(UserModel UserModel);
}