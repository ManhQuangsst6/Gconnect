using Gconnect.Application.Common.Models;
using Gconnect.Application.DTO;

namespace Gconnect.Application.Interface;
public interface IRoleServices
{
    public Task<PaginatedList<RoleDto>> GetRoles(string keySearch, int pageSize, int pageNumber);
    public RoleDto? GetRole(string id);
    public string SaveRole(RoleDto role);
    public void DeleteRole(string id);
    public void UpdateRole(RoleDto role);
    public Task<List<RoleDto>> GetAllRoles();
}
