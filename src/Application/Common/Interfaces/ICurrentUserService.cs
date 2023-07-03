using Gconnect.Application.Auth;
using Microsoft.EntityFrameworkCore;

namespace Gconnect.Application.Common.Interfaces;

public interface ICurrentUserService
{
    string? UserId { get; }
    string? UserName { get; }   
   
}