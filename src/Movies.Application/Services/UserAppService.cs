using Movies.Domain.Services.Interfaces;
using Movies.Application.Models.User;

namespace Movies.Application.Services;

public class UserAppService
{
    private readonly IUserService _userService;

    public UserAppService(IUserService UserService)
    {
        _userService = UserService;
    }

    public async Task<List<GetAllUserResult>> GetAll() {
        var users = await _userService.GetAll();

        List<GetAllUserResult> result = new List<GetAllUserResult>();

        users.ForEach(user => {
            result.Add(new GetAllUserResult(user.Id));
        });

        return result;
    }
}
