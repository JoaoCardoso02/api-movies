using Movies.Application.Models.User;

namespace Movies.Application.Services.Interfaces;

public interface IUserAppService
{
    Task<List<GetAllUserResult>> GetAll();
    Task<CreateUserResult> Create(CreateUserRequest user);
}
