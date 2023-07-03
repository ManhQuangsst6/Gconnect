using Gconnect.API.Common;
using Gconnect.Application.Common.Interfaces;
using Gconnect.Application.Common.Models;
using Gconnect.Application.CQRS.QuanLyTaiKhoan.Queries;
using Gconnect.Application.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Gconnect.API.Controllers.System;

[Route("api/[controller]/[action]")]
public class IdentityController : ApiControllerBase
{
    private readonly IIdentityService _identityService;
    public IdentityController(IIdentityService identityService)
    {
        _identityService = identityService;
    }
    [HttpDelete("Delete")]
    public bool DeleteUser(string username)
    {
        var rest = _identityService.DeleteUserByUserNameAsync(username);
        return rest.Result.Succeeded;
    }
    [HttpGet("GetUsername")]
    public string GetUserNameAsync(string userId)
    {
        var result = _identityService.GetUserNameAsync(userId);
        return result.Result;
    }
    [HttpGet("IsInRole")]
    public bool IsInRoleAsync(string userId, string role)
    {
        var result = _identityService.IsInRoleAsync(userId, role);
        return result.Result;
    }
    [HttpGet("Authorize")]
    public bool AuthorizeAsync(string userId, string policyName)
    {
        return _identityService.AuthorizeAsync(userId, policyName).Result;
    }
    [HttpPost("CreateUser")]
    public string CreateUserAsync(string userName, string password)
    {
        var result = _identityService.CreateUserAsync(userName, password).Result;
        return result.Result.Succeeded ? result.UserId : string.Join("- ", result.Result.Errors);
    }
    [HttpDelete("DeleteUserById")]
    public bool DeleteUserAsync(string userId)
    {
        return _identityService.DeleteUserAsync(userId).Result.Succeeded;
    }
    [HttpDelete("DeleteUserByUsername")]
    public bool DeleteUserByUserNameAsync(string username)
    {
        return _identityService.DeleteUserByUserNameAsync(username).Result.Succeeded;
    }

    [HttpGet]
    public async Task<ApiResponse<PaginatedList<UserDTO>>> GetAllPaging([FromQuery] GetQuanLyTaiKhoanPaging query)
    {
        var response = new ApiResponse<PaginatedList<UserDTO>>();
        response.Result = await _identityService.getAllPaging(query.KeySearch, query.PageNumber, query.PageSize);
        return response;
    }
    [HttpGet]
    public async Task<ApiResponse<UserDTO>> GetById(string id)
    {
        var response = new ApiResponse<UserDTO>();
        response.Result = await _identityService.GetById(id);
        return response;
    }
    [HttpGet]
    public async Task<ApiResponse<List<RoleDto>>> GetRole(string userId)
    {
        var response = new ApiResponse<List<RoleDto>>();
        response.Result = _identityService.GetRole(userId);
        return response;
    }
    [HttpPut]
    public async Task<ApiResponse<int>> UpdateRole(string id, List<string> roleIds)
    {
        var response = new ApiResponse<int>();
        response.Result = await _identityService.UpdateRoleForUser(id, roleIds);
        return response;
    }
    [HttpGet]
    public async Task<ApiResponse<List<RoleDto>>> GetAllRole(string userId)
    {
        var response = new ApiResponse<List<RoleDto>>();
        response.Result = _identityService.getAllRoleOfUser(userId);
        return response;
    }
    [HttpPut]
    public async Task<ApiResponse<int>> UpdateLockOut(string userid, bool lockOutState)
    {
        var response = new ApiResponse<int>();
        response.Result = await _identityService.UpdateLockOut(userid, lockOutState);
        return response;
    }
    [HttpDelete]
    public async Task<ApiResponse<int>> DeleteUserById(string userId)
    {
        var response = new ApiResponse<int>();
        response.Result = await _identityService.DeleteUser(userId);
        return response;
    }
    [HttpPost]
    public async Task<ApiResponse<string>> Create(UserDTO user)
    {
        var response = new ApiResponse<string>();
        response.Result = await _identityService.Create(user);
        return response;
    }
    [HttpPut]
    public async Task<ApiResponse<string>> Update(UserDTO user)
    {
        var response = new ApiResponse<string>();
        response.Result = await _identityService.Update(user);
        return response;
    }

}
