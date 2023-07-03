using Gconnect.Application.Common.Models;
using Gconnect.Application.DTO;

namespace Gconnect.Application.Common.Interfaces;
public interface IDMPhongService
{
    Task<DMPhongDTO> GetDepartmentNameAsync(string userId);
    Task<Result> DeleteDepartmentAsync(string departmentId);
    Task<Result> DeleteDepartmentByNameAsync(string departmentName);
    Task<PaginatedList<DMPhongDTO>> getAllPaging(string keySearch, int pageNumber, int pageSize);
    Task<DMPhongDTO> GetById(string departmentId);
    Task<(Result Result, string DepartmentID)> UpdateDepartmentAsync(string departmentName);
    Task<string> Create(DMPhongDTO department);
}
