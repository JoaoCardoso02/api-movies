using Movies.Domain.Services.Interfaces;
using Movies.Domain.Models;

using Movies.Application.Services.Interfaces;
using Movies.Application.Models.User;

using Movies.Infrastructure.Cryptography.Interfaces;

namespace Movies.Application.Services;

public class UserAppService : IUserAppService
{
    private readonly IUserService UserService;
    private readonly ICryptography Cryptography;

    public UserAppService(
        IUserService userService,
        ICryptography cryptography
    ) {
        UserService = userService;
        Cryptography = cryptography;
    }

    public async Task<List<GetAllUserResult>> GetAll() {
        var users = await UserService.GetAll();

        List<GetAllUserResult> result = new List<GetAllUserResult>();

        users.ForEach(user => {
            if (user != null && user.Id != null) {
                result.Add(new GetAllUserResult {
                    Id = (long)user.Id,
                    Name = user.Name,
                    Email = user.Email,
                    BirthDate = user.BirthDate,
                });
            }
        });

        return result;
    }

    public async Task<GetOneUserResult> GetById(long id) {
        var user = await UserService.GetById(id);

        if (user == null || user.Id == null) {
            throw new Exception("User does not exist");
        }

        return new GetOneUserResult {
            Id = (long)user.Id,
            Name = user.Name,
            Email = user.Email,
            BirthDate = user.BirthDate,
        };
    }

    public async Task<CreateUserResult> Create(CreateUserRequest user) {
        var emailAlreadyRegistered = await UserService.GetByEmail(user.Email) == null;

        if (emailAlreadyRegistered) {
            throw new Exception("E-mail already used");
        }

        var passwordHash = Cryptography.HashPassword(user.Password);

        var userCreated = await UserService.Create(new Users(
            user.Name,
            user.Email,
            passwordHash,
            user.BirthDate
        ));

        if (userCreated == null || userCreated.Id == null) {
            throw new Exception("User does not created");
        }

        return new CreateUserResult {
            Id = (long)userCreated.Id,
            Name = userCreated.Name,
            Email = userCreated.Email,
            BirthDate = userCreated.BirthDate,
        };
    }

    public async Task<UpdateUserResult> Update(long id, UpdateUserRequest user) {
        var userUpdated = await UserService.Update(id, new Users(
            user.Name,
            user.Email,
            user.Password,
            user.BirthDate
        ));

        if (userUpdated == null || userUpdated.Id == null) {
            throw new Exception("User does not updated");
        }

        return new UpdateUserResult {
            Id = (long)userUpdated.Id,
            Name = userUpdated.Name,
            Email = userUpdated.Email,
            BirthDate = userUpdated.BirthDate,
        };
    }

    public async Task<bool> Delete(long id) {
        return await UserService.Delete(id);
    }
}
