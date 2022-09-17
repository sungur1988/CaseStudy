using AutoMapper;
using Core.Dtos;
using Core.Identity;
using Core.Models;
using Core.Wrappers;
using IdentityService.Constants;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;

namespace IdentityService.IdentityServices
{
    public class AuthService : IAuthService
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly ITokenService _tokenService;
        private readonly CustomJwtSettings _jwtSettings;

        public AuthService(IUserService userService, IMapper mapper, ITokenService tokenService, IOptions<CustomJwtSettings> jwtSettings)
        {
            _userService = userService;
            _mapper = mapper;
            _tokenService = tokenService;
            _jwtSettings = jwtSettings.Value;
        }

        public async Task<ServiceResponse<RegisterResponseDto>> Register(RegisterRequestDto registerRequestDto)
        {

            var userResult = await _userService.CreateUserAsync(registerRequestDto);
            if (!userResult.IsSuccess)
            {
                return new ServiceResponse<RegisterResponseDto>(default, false, userResult.StatusCode);
            }
            var response = _mapper.Map<RegisterResponseDto>(userResult.Value);
            response.Token = await _tokenService.CreateTokenAsync(userResult.Value);

            return new ServiceResponse<RegisterResponseDto>(response, true, userResult.StatusCode);
        }

        public async Task<ServiceResponse<LoginResponseDto>> Login(LoginRequestDto loginRequestDto)
        {
            var user = await _userService.GetUser(loginRequestDto.Email);
            if (!user.IsSuccess)
            {
                return new ServiceResponse<LoginResponseDto>(default, user.IsSuccess, user.StatusCode, user.Message);
            }
            var signInResult = await _userService.Login(user.Value, loginRequestDto.Password);
            if (!signInResult)
                return new ServiceResponse<LoginResponseDto>(default, false, 401, Messages.LoginFailed);

            var token = await _tokenService.CreateTokenAsync(user.Value);
            var loginResponseDto = new LoginResponseDto { Id=user.Value.Id,Email=loginRequestDto.Email,UserName=user.Value.UserName,Token=token};
            return new ServiceResponse<LoginResponseDto>(loginResponseDto, true, 200, Messages.LoginSuccess);
        }
    }
}
