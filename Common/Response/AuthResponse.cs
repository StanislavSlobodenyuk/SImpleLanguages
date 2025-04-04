
using Common.Enum;
using Dto.AuthorizationDTO;

namespace Common.Response
{
    public class AuthResponse : BaseResponse<TokensDto> 
    {
        public AuthStatus AuthStatus {  get; set; }
    }
}
