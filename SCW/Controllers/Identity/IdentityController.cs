using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace SCW.Controllers.Identity
{
    public class IdentityController : ControllerBase
    {
        public IdentityController()
        {
            //CurrentUser = this.User;
        }

        public ClaimsPrincipal CurrentUser
        {
            get
            {
                return HttpContext?.User;
            }
        }


        public string UserId
        {
            get
            {
                return CurrentUser?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            }
        }
        public string Name
        {
            get
            {
                return CurrentUser.FindFirst(ClaimTypes.Name).Value;
            }
        }
        public string Role
        {
            get
            {
                return CurrentUser.FindFirst(ClaimTypes.Role).Value;
            }
        }
        public string Account
        {
            get
            {
                return CurrentUser.FindFirst(ClaimTypes.PrimarySid).Value;
            }
        }

        public string IsTemp
        {
            get
            {
                return CurrentUser.FindFirst("IsTemp").Value;
            }
        }
        public Guid CompanyId
        {
            get
            {
                return Guid.Parse(CurrentUser.FindFirst("CompanyId").Value); 
            }
        }
        public string OwnerId
        {
            get
            {
                return CurrentUser.FindFirst("OwnerId").Value;
            }
        }

    }
}
