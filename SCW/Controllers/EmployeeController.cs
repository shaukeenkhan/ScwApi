using Microsoft.AspNetCore.Mvc;
using SCW.Models.BaseClass;
using SCW.Models;
using SCW.Services;
using Microsoft.AspNetCore.Authorization;
using SCW.Controllers.Identity;

namespace SCW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : IdentityController
    {
        private IConfiguration _config;
        private readonly IEmployeeService _empService;

        public EmployeeController(IConfiguration config, IEmployeeService empService)
        {
            this._config = config;
            this._empService = empService;
        }


        [HttpPost]
        [Route("addemployee")]
        [Authorize]
        public async Task<ActionResult> AddEmployee([FromForm] EmployeeModelRequest request)
        {
            BaseResponse<NoResult> response = new BaseResponse<NoResult>();
            request.OwnerId = Convert.ToInt32(OwnerId);

            response = await this._empService.AddEmployee(request);
            return (new JsonResult(response));
        }

        [HttpPost]
        [Route("getemployeelist")]
        [Authorize]
        public async Task<ActionResult> GetEmployeeList(GetEmployeeModelRequest request)
        {
            BaseResponse<EmployeeModelResult> response = new BaseResponse<EmployeeModelResult>();
            request.OwnerId = Convert.ToInt32(OwnerId);
            response = await this._empService.GetEmployeeList(request);
            return (new JsonResult(response));
        }

        [HttpPost]
        [Route("uploademppicture")]
        [Authorize]
        public async Task<ActionResult> UploadEmpPicture([FromForm] EmployeePictureModelRequest request)
        {
            BaseResponse<NoResult> response = new BaseResponse<NoResult>();
            request.OwnerId = Convert.ToInt32(OwnerId);

            response = await this._empService.UploadEmpPicture(request);
            return (new JsonResult(response));
        }

        [HttpPost]
        [Route("addclass")]
        [Authorize]
        public async Task<ActionResult> AddClass([FromForm] ClassModelRequest request)
        {
            BaseResponse<NoResult> response = new BaseResponse<NoResult>();
            request.OwnerId = Convert.ToInt32(OwnerId);

            response = await this._empService.AddClass(request);
            return (new JsonResult(response));
        }

        [HttpPost]
        [Route("getclasslist")]
        [Authorize]
        public async Task<ActionResult> GetClassList(GetClassModelRequest request)
        {
            BaseResponse<ClassModelResult> response = new BaseResponse<ClassModelResult>();
            request.OwnerId = Convert.ToInt32(OwnerId);
            response = await this._empService.GetClassList(request);
            return (new JsonResult(response));
        }


    }
}
