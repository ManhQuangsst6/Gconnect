using Gconnect.Application.Common.Models;
using Gconnect.Application.DTO;

namespace Gconnect.Application.Common.Interfaces;

public interface IIdentityService
{
    Task<string> GetUserNameAsync(string userId);

    Task<bool> IsInRoleAsync(string userId, string role);

    Task<bool> AuthorizeAsync(string userId, string policyName);

    Task<(Result Result, string UserId)> CreateUserAsync(string userName, string password);

    Task<Result> DeleteUserAsync(string userId);
    Task<Result> DeleteUserByUserNameAsync(string username);
    Task<PaginatedList<UserDTO>> getAllPaging(string keySearch, int pageNumber, int pageSize);
    Task<UserDTO> GetById(string userId);
    List<RoleDto> GetRole(string userId);
    Task<int> UpdateRoleForUser(string userId, List<string> rolesIds);
    List<RoleDto> getAllRoleOfUser(string userId);
    Task<int> UpdateLockOut(string userId, bool LockOutState);
    Task<int> DeleteUser(string userId);
    Task<string> Create(UserDTO user);
    Task<string> Update(UserDTO user);
}
