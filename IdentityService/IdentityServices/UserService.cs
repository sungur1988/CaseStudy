using AutoMapper;
using Core.Dtos;
using Core.Entities;
using Core.Identity;
using Core.Wrappers;
using IdentityService.Constants;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace IdentityService.IdentityServices
{
    public class UserService : IUserService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<IdentityRole<int>> _roleManager;
        private readonly IMapper _mapper;

        public UserService(UserManager<AppUser> userManager, IMapper mapper, SignInManager<AppUser> signInManager, RoleManager<IdentityRole<int>> roleManager)
        {
            _userManager = userManager;
            _mapper = mapper;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        public async Task<ServiceResponse<AppUser>> CreateUserAsync(RegisterRequestDto registerRequestDto)
        {
            var appUser = _mapper.Map<AppUser>(registerRequestDto);
            var result = await _userManager.CreateAsync(appUser, registerRequestDto.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(appUser, "Customer");
                return new ServiceResponse<AppUser>(appUser, true, 204);
            }

            return new ServiceResponse<AppUser>(default, false, 500);
        }

        public async Task<ServiceResponse<AppUser>> GetUser(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
                return new ServiceResponse<AppUser>(default, false, 404, Messages.UserNotFound);
            return new ServiceResponse<AppUser>(user, true, 200);
        }

        public async Task<IList<Claim>> GetClaims(AppUser appUser)
        {
            return await _userManager.GetClaimsAsync(appUser);
        }

        public async Task<IList<string>> GetRoles(AppUser appUser)
        {
            return await _userManager.GetRolesAsync(appUser);
        }

        public async Task<bool> Login(AppUser user, string password)
        {
            var result = await _signInManager.PasswordSignInAsync(user, password, false, false);
            return result.Succeeded;
        }
    }
}
