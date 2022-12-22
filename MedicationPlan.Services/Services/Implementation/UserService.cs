using AutoMapper;
using MedicationPlan.Entity.Models;
using MedicationPlan.Repository;
using MedicationPlan.Services.Abstract;
using MedicationPlan.Services.Models;

namespace MedicationPlan.Services.Implementation;

public class UserService : IUserService
{
    private readonly IRepository<User> UserRepository;
    private readonly IMapper mapper;
    public UserService(IRepository<User> UserRepository, IMapper mapper)
    {
        this.UserRepository = UserRepository;
        this.mapper = mapper;
    }

    public void DeleteUser(Guid id)
    {
        var UserToDelete = UserRepository.GetById(id);
        if (UserToDelete == null)
        {
            throw new Exception("User not found");
        }

        UserRepository.Delete(UserToDelete);
    }

    public UserModel GetUser(Guid id)
    {
        var User = UserRepository.GetById(id);
        return mapper.Map<UserModel>(User);
    }

    public PageModel<UserPreviewModel> GetUsers(int limit = 20, int offset = 0)
    {
        var Users = UserRepository.GetAll();
        int totalCount = Users.Count();
        var chunk = Users.OrderBy(x => x.Name).Skip(offset).Take(limit);

        return new PageModel<UserPreviewModel>()
        {
            Items = mapper.Map<IEnumerable<UserPreviewModel>>(Users),
            TotalCount = totalCount
        };
    }

    public UserModel UpdateUser(Guid id, UpdateUserModel User)
    {
        var existingUser = UserRepository.GetById(id);
        if (existingUser == null)
        {
            throw new Exception("User not found");
        }

        existingUser.FIO = User.FIO;
        existingUser.PhoneNumber = User.PhoneNumber;
        existingUser.Email = User.Email;
        existingUser.Snils = User.Snils;
        existingUser.Polis = User.Polis;
        existingUser.PasswordHash = User.PasswordHash;

        existingUser = UserRepository.Save(existingUser);
        return mapper.Map<UserModel>(existingUser);
    }

    UserModel IUserService.CreateUser(MedicationPlan.Services.Models.UserModel UserModel)
    {
      UserRepository.Save(mapper.Map<Entity.Models.User>(UserModel));
        return UserModel;
    }
}