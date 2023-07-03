using Gconnect.API.Common;
using Gconnect.Application.Common.Interfaces;
using Gconnect.Application.Common.Models;
using Gconnect.Application.CQRS.QuanLyTaiKhoan.Queries;
using Gconnect.Application.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Gconnect.API.Controllers.User;
[Route("api/[controller]/[action]")]
public class UserController : ApiControllerBase
{
    private readonly IQuanLyTaiKhoan _iquanlyTaiKhoan;
    public UserController(IQuanLyTaiKhoan iquanlyTaiKhoan1)
    {
        _iquanlyTaiKhoan = iquanlyTaiKhoan1;
    }
    [HttpDelete]
    public async Task<ApiResponse<int>> DeleteUserById(string userId)
    {
        var response = new ApiResponse<int>();
        response.Result = await _iquanlyTaiKhoan.DeleteUser(userId);
        return response;
    }
    [HttpPost]
    public async Task<ApiResponse<string>> Create(TaiKhoanViewModel user)
    {
        var response = new ApiResponse<string>();
        response.Result = await _iquanlyTaiKhoan.Create(user);
        return response;
    }
    [HttpPut]
    public async Task<ApiResponse<string>> Update(TaiKhoanViewModel user)
    {
        var response = new ApiResponse<string>();
        response.Result = await _iquanlyTaiKhoan.Update(user);
        return response;
    }
    [HttpGet]
    public async Task<ApiResponse<PaginatedList<UserDTO>>> GetAllPaging([FromQuery] GetQuanLyTaiKhoanPaging query)
    {
        var response = new ApiResponse<PaginatedList<UserDTO>>();
        response.Result = await _iquanlyTaiKhoan.getAllPaging(query.KeySearch, query.PageNumber, query.PageSize);
        return response;
    }
    [HttpGet]
    public async Task<ApiResponse<TaiKhoanViewModel>> GetById(string id)
    {
        var response = new ApiResponse<TaiKhoanViewModel>();
        response.Result = await _iquanlyTaiKhoan.GetById(id);
        return response;
    }
}
