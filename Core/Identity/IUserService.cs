using Core.Dtos;
using Core.Entities;
using Core.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Core.Identity
{
    public interface IUserService
    {
        Task<ServiceResponse<AppUser>> CreateUserAsync(RegisterRequestDto registerRequestDto);
        Task<ServiceResponse<AppUser>> GetUser(string email);
        Task<bool> Login(AppUser user, string password);
        Task<IList<Claim>> GetClaims(AppUser appUser);
        Task<IList<string>> GetRoles(AppUser appUser);
    }
}
