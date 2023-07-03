using Gconnect.API.Common;
using Gconnect.Application.Common.Models;
using Gconnect.Application.DTO;
using Gconnect.Application.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Gconnect.API.Controllers.System;
[Route("api/[controller]/[action]")]
[ApiController]
public class RoleController : ApiControllerBase
{
    private readonly IRoleServices _roleServices;
    public RoleController(IRoleServices roleServices)
    {
        _roleServices = roleServices;
    }
    //[HttpGet]
    //public async Task<ApiResponse<PaginatedList<RoleDto>>> GetRoles([FromQuery] RolePagingQuery query)
    //{
    //    var vm = new ApiResponse<PaginatedList<RoleDto>>();
    //    vm.Result = await _roleServices.GetRoles(query.KeySearch, query.PageSize, query.PageNumber);        
    //    return vm;
    //}

    [HttpGet]
    public async Task<ApiResponse<PaginatedList<RoleDto>>> GetRoles(string KeySearch, int PageNumber, int PageSize, string SortExpression)
    {
        var vm = new ApiResponse<PaginatedList<RoleDto>>();
        vm.Result = await _roleServices.GetRoles(KeySearch, PageSize, PageNumber);
        return vm;
    }
    public async Task<ApiResponse<List<RoleDto>>> GetAllRoles()
    {
        var vm = new ApiResponse<List<RoleDto>>();
        vm.Result = await _roleServices.GetAllRoles();
        return vm;
    }
    [HttpGet]
    public ApiResponse<RoleDto> GetRole(string id)
    {
        var res = new ApiResponse<RoleDto>();
        res.Result = _roleServices.GetRole(id);
        return res;
    }
    [HttpPost]
    public ApiResponse<string> CreateRole(RoleDto role)
    {
        var res = new ApiResponse<string>();
        try
        {
            res.Result = _roleServices.SaveRole(role);
        }
        catch (Exception ex)
        {
            res.Success = false;
            res.Message = ex.Message;
        }
        return res;
    }
    [HttpPut]
    public ApiResponse<string> UpdateRole(RoleDto role)
    {
        var res = new ApiResponse<string>();
        try
        {
            _roleServices.UpdateRole(role);
            res.Result = role.Id;
        }
        catch (Exception ex)
        {
            res.Success = false;
            res.Message = ex.Message;
        }
        return res;
    }
    [HttpDelete]
    public ApiResponse<bool> DeleteRole(string id)
    {
        var res = new ApiResponse<bool>();
        try
        {
            _roleServices.DeleteRole(id);
        }
        catch (Exception ex)
        {
            res.Success = false;
            res.Message = ex.Message;
        }

        return res;
    }
}

public record RolePagingQuery
{
    public string KeySearch { get; set; } = string.Empty;
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
    public string SortExpression { get; set; } = "IdTinh asc";
}
