using Microsoft.AspNetCore.Mvc;
using SCW.Controllers.Identity;
using SCW.Models.BaseClass;
using SCW.Models;
using SCW.Services;
using SCW.Services.SuperAdmin;
using Microsoft.AspNetCore.Authorization;

namespace SCW.Controllers.SuperAdmin
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperAccountController : IdentityController
    {
        private IConfiguration _config;
        private readonly ISuperAccountService _accountService;

        public SuperAccountController(IConfiguration config, ISuperAccountService accountService)
        {
            this._config = config;
            this._accountService = accountService;
        }

        [HttpPost("superuserlogin")]
        public async Task<ActionResult> SuperUserLogin(AccountModelRequest request)
        {

            BaseResponse<AccountResponseModel> response = new BaseResponse<AccountResponseModel>();

            response = await this._accountService.UserLogin(request);
            return (new JsonResult(response));
        }


        [HttpPost("getuserlist")]
        [Authorize]
        public async Task<ActionResult> GetUserList(GetUserListModelRequest request)
        {
            BaseResponse<UserListModelResult> response = new BaseResponse<UserListModelResult>();
            response = await this._accountService.GetUserList(request);
            return (new JsonResult(response));
        }

    }
}
