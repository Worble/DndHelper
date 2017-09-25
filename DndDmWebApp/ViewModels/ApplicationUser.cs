using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DndDmWebApp.ViewModels
{
    public class ApplicationUser : ClaimsPrincipal
    {

        public ApplicationUser(ClaimsPrincipal principal)
        : base(principal) { }

        public int ID
        {
            get
            {
                if (this.FindFirstValue(ClaimTypes.NameIdentifier) != null)
                {
                    return int.Parse(this.FindFirstValue(ClaimTypes.NameIdentifier));
                }
                else
                {
                    return 0;
                }
            }
        }

        public string EmailAddress
        {
            get
            {
                if (this.FindFirstValue(ClaimTypes.Email) != null)
                {
                    return this.FindFirstValue(ClaimTypes.Email);
                }
                else
                {
                    return string.Empty;
                }
            }
        }

        public string Role
        {
            get
            {
                if (this.FindFirstValue(ClaimTypes.Role) != null)
                {
                    return this.FindFirstValue(ClaimTypes.Role);
                }
                else
                {
                    return string.Empty;
                }
            }
        }
    }
}
