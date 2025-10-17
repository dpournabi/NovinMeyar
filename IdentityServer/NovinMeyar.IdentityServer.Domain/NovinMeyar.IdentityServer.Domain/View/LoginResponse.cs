using NovinMeyar.Common;
using NovinMeyar.IdentityServer.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace NovinMeyar.IdentityServer.Domain.View
{
    public class LoginResponse : ResponseModel
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public DateTime ExpireDate { get; set; }
        public string TokenType { get; set; }
        public bool ConfirmByAdmin { get; set; }
        public IEnumerable<Claim> Claims { get; set; }
    }
}
