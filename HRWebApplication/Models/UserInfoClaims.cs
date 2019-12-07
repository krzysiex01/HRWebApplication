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

        public async Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
        {
            
            if (!principal.HasClaim(c => c.Type == ClaimTypes.Role))
            {
                var user  = _context.Users.FirstOrDefault( x=> x.ProviderUserId == principal.FindFirst(ClaimTypes.NameIdentifier).Value);
                ClaimsIdentity id = new ClaimsIdentity();
                if(user is null)
                {
                    //Add new user to databese
                    var name = principal.FindFirst(ClaimTypes.GivenName);
                    var surname = principal.FindFirst(ClaimTypes.Surname);
                    var email = principal.FindFirst("emails");
                    var country = principal.FindFirst("country");
                    var city = principal.FindFirst("city");

                    User newUser = new User()
                    {
                        City = city.Value,
                        Country = country.Value,
                        EmailAddress = email.Value,
                        FirstName = name.Value,
                        LastName = surname.Value,
                        ProviderUserId = principal.FindFirst(ClaimTypes.NameIdentifier).Value,
                        ProviderName = "AZURE_AD_B2C",
                        Role = "User"
                    };

                    await _context.Users.AddAsync(newUser);
                    await _context.SaveChangesAsync();
                    id.AddClaim(new Claim(ClaimTypes.Role, "User"));
                }
                else
                {
                    id.AddClaim(new Claim(ClaimTypes.Role, user.Role));
                }
                principal.AddIdentity(id);
            }
            return await Task.FromResult(principal);
        }
    }
}
