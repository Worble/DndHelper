using DndDmHelperData.Repositories.Interfaces;
using DndDmHelperData.UnitOfWork.Interface;
using DndDmWebApp.ViewModels;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DndDmWebApp
{
    public class Helper
    {
        //rudimentary validation checking; simply checks if the current user is up to date, and updates their credentials if not. 
        //can be used to check if they have been banned/etc and display a warning or sign them out.
        public static async Task ValidateAsync(CookieValidatePrincipalContext context)
        {
            if (context.Principal.Identity.IsAuthenticated)
            {
                // Pull database from registered DI services.
                var work = context.HttpContext.RequestServices.GetRequiredService<IUnitOfWork>();
                var userPrincipal = context.Principal;
                var user = work.UserRepository.GetDTO(int.Parse(userPrincipal.FindFirstValue(ClaimTypes.NameIdentifier)));

                // Look for the last changed claim.
                string lastUpdated = userPrincipal.FindFirstValue("LastEdited");

                if (string.IsNullOrEmpty(lastUpdated) || user.LastEdited.ToString() != lastUpdated)
                {
                    var principal = SetClaims(user);
                    context.ReplacePrincipal(principal);
                    context.ShouldRenew = true;

                    //context.RejectPrincipal();
                    //await context.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                }
            }
        }

        /// <summary>
        /// Sets the user claims from the DTO.
        /// </summary>
        /// <param name="user">The user DTO.</param>
        /// <returns></returns>
        public static ClaimsPrincipal SetClaims(UserDTO user)
        {
            var claims = new List<Claim>() {
                        new Claim(ClaimTypes.Email, user.EmailAddress),
                        new Claim(ClaimTypes.NameIdentifier, user.ID.ToString()),
                        new Claim("LastUpdated", string.Empty, ClaimValueTypes.Time)
                    };

            var userIdentity = new ClaimsIdentity(claims, "User");
            return new ClaimsPrincipal(userIdentity);
        }
    }
}
