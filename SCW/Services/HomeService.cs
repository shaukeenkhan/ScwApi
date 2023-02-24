using Newtonsoft.Json;
using SCW.Enums;
using System.Data;
using DataTableExtensions = SCW.common.DataTableExtension;
using SCW.Models;
using SCW.Models.BaseClass;
using SCW.uow;
using SCW.common;

namespace SCW.Services
{
    public class HomeService : IHomeService
    {
        private IUnitOfWork _unitOfWork { get; set; }
        private IConfiguration _configuration;
        private Microsoft.AspNetCore.Hosting.IHostingEnvironment _hostingEnvironment;
        public HomeService(IUnitOfWork unitOfWork, IConfiguration configuration, Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
            _hostingEnvironment = hostingEnvironment;
        }

        public async Task<BaseResponse<NoResult>> InsertUpdateInstitute(InstituteModelRequest request)
        {
            BaseResponse<NoResult> response = new BaseResponse<NoResult>();
            try
            {
              
                var target = Path.Combine(_hostingEnvironment.ContentRootPath, "Document");
                Directory.CreateDirectory(target);

                //request.files.ForEach(async file =>
                //{
                //    if (file.Length <= 0) return;
                //    var filePath = Path.Combine(target, file.FileName);
                //    using (var stream = new FileStream(filePath, FileMode.Create))
                //    {
                //        await file.CopyToAsync(stream);
                //    }
                //});
                if (request.files != null)
                {
                    request.Logo = DataTableExtensions.GetUniqueFileName(request.files.FileName);
                    var filePath = Path.Combine(target, request.Logo);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await request.files.CopyToAsync(stream);
                    }
                }

                string[] paramName = { "@Id", "@Name", "@TargetLine", "@PhoneNo", "@Website", "@CountryId", "@StateId", "@CityId", "@ZipCode", "@Address", "@Logo", "@OwnerId" };
                DataTable dt = this._unitOfWork.GetDataFromStoredProcedure("[dbo].[PROC_INSERT_UPDATE_INSTITUTE]", paramName, request.Id, request.Name, request.TargetLine
                    , request.PhoneNo, request.Website, request.CountryId, request.StateId, request.CityId, request.ZipCode,request.Address, request.Logo, request.OwnerId);

                if (dt.Rows.Count > 0)
                {
                    response.rs = Convert.ToInt32(dt.Rows[0]["ResponseCode"]);
                    response.rm = Convert.ToString(dt.Rows[0]["ResponseMessage"]);
                }
                else
                {
                    response.rs = 0;
                    response.rm = "Failed";
                }

            }
            catch (Exception ex)
            {
                response.rs = 0;
                response.rm = "Failed";
            }

            return response;
        }

        public async Task<BaseResponse<InstituteModelResult>> GetInstitute(GetInstituteModelRequest request)
        {
            BaseResponse<InstituteModelResult> baseResponse = new BaseResponse<InstituteModelResult>();
            try
            {
                string[] param = { "@OwnerId" };
                DataTable dt = this._unitOfWork.GetDataFromStoredProcedure("[dbo].[PROC_GET_INSTITUTE]", param, request.OwnerId);

                if (dt.Rows.Count > 0)
                {
                    var files = _configuration["DocumentUrl"]; 

                    List<InstituteModelResult> result = DataTableExtension.ToList<InstituteModelResult>(dt);
                    result = result.Select(x => new InstituteModelResult
                    {
                        Id = x.Id,
                        Name = x.Name,
                        TargetLine = x.TargetLine,
                        PhoneNo = x.PhoneNo,
                        Website = x.Website,
                        CountryId = x.CountryId,
                        CountryName = x.CountryName,
                        StateId = x.StateId,
                        StateName = x.StateName,
                        CityId = x.CityId,
                        CityName = x.CityName,
                        Address = x.Address,
                        Logo = x.Logo != null ? files + x.Logo : null,
                        OwnerId = x.OwnerId,

                    }).ToList();

                    baseResponse.rc = result;
                    baseResponse.rs = 1;
                    baseResponse.rm = Convert.ToString(EnumMessages.Successful);
                }
                else
                {
                    baseResponse.rs = 0;
                    baseResponse.rm = Convert.ToString(EnumMessages.No_record_found);
                }
            }
            catch (Exception ex)
            {
                baseResponse.rs = 0;
                baseResponse.rm = Convert.ToString(EnumMessages.Exception);
            }
            return baseResponse;
        }

      

        public async Task<BaseResponse<DropDownResult>> GetDropdownList(DropDownRequest request)
        {
            BaseResponse<DropDownResult> baseResponse = new BaseResponse<DropDownResult>();
            try
            {
                string[] param = { "@Flag", "@OptionId", "@OptionId2" };
                var result = this._unitOfWork.GetDataFromDigitalStoredProcedure<DropDownResult>("[dbo].[PROC_GET_DROPDOWN_LIST]", param, request.Flag, request?.OptionId, request?.OptionId2);
                if (result.Count > 0)
                {
                    baseResponse.rc = result;
                    baseResponse.rs = 1;
                    baseResponse.rm = Convert.ToString(EnumMessages.Success);

                }
                else
                {
                    baseResponse.rs = 0;
                    baseResponse.rm = Convert.ToString(EnumMessages.No_record_found);
                }
            }
            catch (Exception ex)
            {
                baseResponse.rs = 0;
                baseResponse.rm = Convert.ToString(EnumMessages.Exception);
            }
            return baseResponse;
        }



    }
}
