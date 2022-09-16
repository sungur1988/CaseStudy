using Core.Dtos;
using Core.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Identity
{
    public interface IAuthService
    {
        Task<ServiceResponse<RegisterResponseDto>> Register(RegisterRequestDto registerRequestDto);
        Task<ServiceResponse<LoginResponseDto>> Login(LoginRequestDto loginRequestDto);
    }
}
