using SCW.Enums;
using System.Data;
using SCW.Models;
using SCW.Models.BaseClass;
using SCW.uow;
using DataTableExtensions = SCW.common.DataTableExtension;
using SCW.common;

namespace SCW.Services.SuperAdmin
{
    public class SuperAccountService: ISuperAccountService
    {
        private IUnitOfWork _unitOfWork { get; set; }
        private IConfiguration _configuration;
        private ITokenService _tokenService { get; set; }
        private Microsoft.AspNetCore.Hosting.IHostingEnvironment _hostingEnvironment;
        public SuperAccountService(IUnitOfWork unitOfWork, IConfiguration configuration, ITokenService tokenService, Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
            this._tokenService = tokenService;
            _hostingEnvironment = hostingEnvironment;
        }

        public async Task<BaseResponse<AccountResponseModel>> UserLogin(AccountModelRequest request)
        {
            BaseResponse<AccountResponseModel> baseResponse = new BaseResponse<AccountResponseModel>();

            AccountResponseModel accountResponseModel = new AccountResponseModel();
            try
            {
                var cryptpass = EncryptDecrypt.encrypt(request.Password.Trim());
                string[] param = { "@UserName", "@Password" };
                var result = this._unitOfWork.GetDataFromDigitalStoredProcedure<AccountModelResult>("[dbo].[S_PROC_SADMIN_LOGIN]", param, request.UserName, cryptpass);
                if (result.Count > 0)
                {

                    var responseobj = result.Select(x => new UserList { UserId = x.UserId, UserName = x.UserName, FullName = x.FullName, Email = x.Email, StatusFkId = x.StatusFkId }).ToList();





                    if (result.FirstOrDefault().ResponseCode == 1)
                    {


                        var UserDTO = result.Select(x => new UserDTO { Id = x.UserId, UserName = x.UserName, FullName = x.FullName, Email = x.Email }).FirstOrDefault();

                        accountResponseModel.id_token = _tokenService.BuildIdToken(UserDTO);
                        accountResponseModel.IsSAdmin = true;
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
                        accountResponseModel.IsSAdmin = false;
                        accountResponseModel.userLists = responseobj;

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


        public async Task<BaseResponse<UserListModelResult>> GetUserList(GetUserListModelRequest request)
        {
            BaseResponse<UserListModelResult> baseResponse = new BaseResponse<UserListModelResult>();
            try
            {
                string[] param = { "@currentPage", "@recordsPerPage", "@UserName" };
                DataTable dt = this._unitOfWork.GetDataFromStoredProcedure("[dbo].[S_PROC_GET_USERLIST]", param, request.currentPage,request.recordsPerPage,request.UserName);

                if (dt.Rows.Count > 0)
                {

                    List<UserListModelResult> result = DataTableExtension.ToList<UserListModelResult>(dt);
                    result = result.Select(x => new UserListModelResult
                    {
                        TotalRecords = x.TotalRecords,
                        Id = x.Id,
                        Email = x.Email,
                        PhoneNumber = x.PhoneNumber,
                        UserName = x.UserName,
                        FullName = x.FullName,
                        StatusFkId = x.StatusFkId,
                        CreatedOn = x.CreatedOn,
                        ModifiedOn = x.ModifiedOn,
                        ParentUserId = x.ParentUserId,

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

    }
}
