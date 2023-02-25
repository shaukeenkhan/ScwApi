using SCW.Enums;
using System.Data;
using SCW.Models;
using SCW.Models.BaseClass;
using SCW.uow;
using DataTableExtensions = SCW.common.DataTableExtension;
using SCW.common;

namespace SCW.Services
{
    public class AccountService : IAccountService
    {
        private IUnitOfWork _unitOfWork { get; set; }
        private IConfiguration _configuration;
        private ITokenService _tokenService { get; set; }
        private Microsoft.AspNetCore.Hosting.IHostingEnvironment _hostingEnvironment;
        public AccountService(IUnitOfWork unitOfWork, IConfiguration configuration, ITokenService tokenService, Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
            this._tokenService = tokenService;
            _hostingEnvironment = hostingEnvironment;
        }

        public async Task<BaseResponse<AccountResponseModel>> CheckInstUserLogin(AdminSignUpModelRequest request)
        {
            BaseResponse<AccountResponseModel> baseResponse = new BaseResponse<AccountResponseModel>();

            AccountResponseModel accountResponseModel = new AccountResponseModel();
            try
            {
                var cryptpass = EncryptDecrypt.encrypt(request.Password.Trim());
                string[] param = { "@Name", "@UserName", "@Password" };
                var result = this._unitOfWork.GetDataFromDigitalStoredProcedure<AccountModelResult>("[dbo].[PROC_CHECK_INST_ADMIN]", param, request.Name,request.UserName, cryptpass);
                if (result.Count > 0)
                {

                    var responseobj = result.Select(x => new UserList { UserId = x.UserId,ParentUserId=x.ParentUserId, FullName = x.FullName, Email = x.Email, StatusFkId = x.StatusFkId }).ToList();





                    if (result.FirstOrDefault().ResponseCode == 1)
                    {


                        var UserDTO = result.Select(x => new UserDTO { Id = x.UserId, ParentUserId = x.ParentUserId, UserName = x.UserName, FullName = x.FullName, Email = x.Email }).FirstOrDefault();

                        accountResponseModel.id_token = _tokenService.BuildAccessToken(UserDTO);
                        accountResponseModel.IsInstLoginPage = false;
                        accountResponseModel.userLists = responseobj;
                        //accountResponseModel.IsCustomer = result.FirstOrDefault().IsCustomer;
                        //accountResponseModel.IsCompany = result.FirstOrDefault().IsCompany;

                        baseResponse.res = accountResponseModel;
                        baseResponse.rs = 1;
                        baseResponse.rm = Convert.ToString(EnumMessages.Successful);
                    }
                    else if (result.FirstOrDefault().ResponseCode == 2)
                    {


                        accountResponseModel.id_token = "";
                        accountResponseModel.IsInstLoginPage = true;
                        accountResponseModel.userLists = responseobj;

                        baseResponse.res = accountResponseModel;
                        baseResponse.rs =Convert.ToInt32(result.FirstOrDefault().ResponseCode);
                        baseResponse.rm = Convert.ToString(result.FirstOrDefault().ResponseMessage);
                    }

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

        public async Task<BaseResponse<AccountResponseModel>> InstAdminUserLogin(AccountModelRequest request)
        {
            BaseResponse<AccountResponseModel> baseResponse = new BaseResponse<AccountResponseModel>();

            AccountResponseModel accountResponseModel = new AccountResponseModel();
            try
            {
                var cryptpass = EncryptDecrypt.encrypt(request.Password.Trim());
                string[] param = { "@UserName", "@Password" };
                var result = this._unitOfWork.GetDataFromDigitalStoredProcedure<AccountModelResult>("[dbo].[PROC_INST_USERADMIN_LOGIN]", param, request.UserName, cryptpass);
                if (result.Count > 0)
                {

                    var responseobj = result.Select(x => new UserList { UserId = x.UserId, FullName = x.FullName, Email = x.Email, StatusFkId = x.StatusFkId }).ToList();





                    if (result.FirstOrDefault().ResponseCode == 1)
                    {


                        var UserDTO = result.Select(x => new UserDTO { Id = x.UserId, UserName = x.UserName, FullName = x.FullName, Email = x.Email }).FirstOrDefault();

                        accountResponseModel.id_token = _tokenService.BuildAccessToken(UserDTO);
                        accountResponseModel.IsSAdmin = false;
                        //accountResponseModel.IsCustomer = result.FirstOrDefault().IsCustomer;
                        //accountResponseModel.IsCompany = result.FirstOrDefault().IsCompany;

                        baseResponse.res = accountResponseModel;
                        baseResponse.rs = 1;
                        baseResponse.rm = Convert.ToString(EnumMessages.Successful);
                    }
                    else if (result.FirstOrDefault().ResponseCode == 2)
                    {


                        accountResponseModel.id_token = "";
                        accountResponseModel.IsSAdmin = true;

                        baseResponse.res = accountResponseModel;
                        baseResponse.rs = Convert.ToInt32(result.FirstOrDefault().ResponseCode);
                        baseResponse.rm = Convert.ToString(result.FirstOrDefault().ResponseMessage);
                    }

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
