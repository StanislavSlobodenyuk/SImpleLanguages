﻿using Domain.Entity.User;

namespace Dto.AuthorizationDTO
{
    public class TokensDto
    {
        public string AccessToken { get; set; } = string.Empty;
        public string RefreshToken { get; set;} = string.Empty;
    }
}
