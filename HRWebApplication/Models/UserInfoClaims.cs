using HRWebApplication.EntityFramework;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace HRWebApplication.Models
{
    public class UserInfoClaims : IClaimsTransformation
    {
        private readonly DataContext _context;
        public UserInfoClaims(DataContext context)
        {
            _context = context;
        }

        public Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
        {
            if (!principal.HasClaim(c => c.Type == ClaimTypes.Role))
            {
                var user  = _context.Users.FirstOrDefault( x=> x.ProviderUserId == principal.FindFirst(ClaimTypes.NameIdentifier).Value);

                ClaimsIdentity id = new ClaimsIdentity();
                id.AddClaim(new Claim(ClaimTypes.Role, user.Role));
                principal.AddIdentity(id);
            }
            return Task.FromResult(principal);
        }
    }
}
