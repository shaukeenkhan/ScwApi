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
    public class HomeController : IdentityController
    {
        private IConfiguration _config;
        private readonly IHomeService _homeService;

        public HomeController(IConfiguration config, IHomeService homeService)
        {
            this._config = config;
            this._homeService = homeService;
        }


        [HttpPost]
        [Route("updateinstitute")]
        [Authorize]
        public async Task<ActionResult> UpdateInstitute([FromForm]InstituteModelRequest request)
        {
            BaseResponse<NoResult> response = new BaseResponse<NoResult>();
            request.OwnerId =Convert.ToInt32(OwnerId);

            response = await this._homeService.InsertUpdateInstitute(request);
            return (new JsonResult(response));
        }

        [HttpGet]
        [Route("getinstitute")]
        [Authorize]
        public async Task<ActionResult> GetInstitute([FromQuery] GetInstituteModelRequest request)
        {
            BaseResponse<InstituteModelResult> response = new BaseResponse<InstituteModelResult>();
            request.OwnerId = Convert.ToInt32(OwnerId);
            response = await this._homeService.GetInstitute(request);
            return (new JsonResult(response));
        }


        [HttpPost]
        [Route("updatebankinfo")]
        [Authorize]
        public async Task<ActionResult> UpdateBankInfo([FromForm] BankInfoModelRequest request)
        {
            BaseResponse<NoResult> response = new BaseResponse<NoResult>();
            request.OwnerId = Convert.ToInt32(OwnerId);

            response = await this._homeService.UpdateBankInfo(request);
            return (new JsonResult(response));
        }

        [HttpGet]
        [Route("getdropdownlist")]
        public async Task<ActionResult> GetDropdownList([FromQuery]DropDownRequest request)
        {
            BaseResponse<DropDownResult> response = new BaseResponse<DropDownResult>();

            response = await this._homeService.GetDropdownList(request);
            return (new JsonResult(response));
        }


      

    }
}
