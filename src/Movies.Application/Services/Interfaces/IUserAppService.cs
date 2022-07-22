using Movies.Application.Models.User;

namespace Movies.Application.Services.Interfaces;

public interface IUserAppService
{
    Task<List<GetAllUserResult>> GetAll();
    Task<GetOneUserResult> GetById(long id);
    Task<CreateUserResult> Create(CreateUserRequest user);
    Task<UpdateUserResult> Update(long id, UpdateUserRequest user);
    Task<bool> Delete(long id);
}
