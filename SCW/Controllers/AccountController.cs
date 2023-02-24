using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SCW.Models.BaseClass;
using SCW.Models;
using SCW.Services;
using SCW.Controllers.Identity;

namespace SCW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : IdentityController
    {
        private IConfiguration _config;
        private readonly IAccountService _accountService;

        public AccountController(IConfiguration config, IAccountService accountService)
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
        [HttpPost("checkinstadminlogin")]
        public async Task<ActionResult> CheckInstAdminLogin(AdminSignUpModelRequest request)
        {


            BaseResponse<AccountResponseModel> response = new BaseResponse<AccountResponseModel>();

            response = await this._accountService.CheckInstUserLogin(request);
            return (new JsonResult(response));
        }
        [HttpPost("instadminlogin")]
        public async Task<ActionResult> InstAdminLogin(AccountModelRequest request)
        {


            BaseResponse<AccountResponseModel> response = new BaseResponse<AccountResponseModel>();

            response = await this._accountService.InstAdminUserLogin(request);
            return (new JsonResult(response));
        }

        [HttpGet("Test")]
        [Authorize]
        public async Task Test()
        {
            var id = UserId;
        }
    }
}
