using Movies.Domain.Services.Interfaces;
using Movies.Domain.Services;
using Movies.Domain.Models;
using Movies.Application.Models.User;
using Movies.Application.Services.Interfaces;

namespace Movies.Application.Services;

public class UserAppService : IUserAppService
{
    private readonly IUserService _userService;

    public UserAppService()
    {
        _userService = new UserService();
    }

    public async Task<List<GetAllUserResult>> GetAll() {
        var users = await _userService.GetAll();

        List<GetAllUserResult> result = new List<GetAllUserResult>();

        users.ForEach(user => {
            result.Add(new GetAllUserResult {
                Id = (long)user.Id,
                Name = user.Name,
                Email = user.Email,
                Password = user.Password,
                BirthDate = user.BirthDate,
            });
        });

        return result;
    }

    public async Task<GetOneUserResult> GetById(long id) {
        var user = await _userService.GetById(id);

        if (user.Id == null) {
            throw new Exception("User does not return Id");
        }

        return new GetOneUserResult {
            Id = (long)user.Id,
            Name = user.Name,
            Email = user.Email,
            Password = user.Password,
            BirthDate = user.BirthDate,
        };

    }

    public async Task<CreateUserResult> Create(CreateUserRequest user) {
        var userCreated = await _userService.Create(new Users(
            user.Name,
            user.Email,
            user.Password,
            user.BirthDate
        ));

        if (userCreated.Id == null) {
            throw new Exception("User does not return Id");
        }

        return new CreateUserResult {
            Id = (long)userCreated.Id,
            Name = userCreated.Name,
            Email = userCreated.Email,
            Password = userCreated.Password,
            BirthDate = userCreated.BirthDate,
        };
    }
}
