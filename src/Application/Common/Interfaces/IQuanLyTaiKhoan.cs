using Gconnect.Application.Common.Models;
using Gconnect.Application.DTO;

namespace Gconnect.Application.Common.Interfaces;
public interface IQuanLyTaiKhoan
{
    Task<int> DeleteUser(string userId);
    Task<string> Create(TaiKhoanViewModel user);
    Task<string> Update(TaiKhoanViewModel user);
    Task<PaginatedList<UserDTO>> getAllPaging(string keySearch, int pageNumber, int pageSize);
    Task<TaiKhoanViewModel> GetById(string userId);
}
