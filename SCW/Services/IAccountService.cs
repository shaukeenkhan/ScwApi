using SCW.Models.BaseClass;
using SCW.Models;

namespace SCW.Services
{
    public interface IAccountService
    {
       
        Task<BaseResponse<AccountResponseModel>> CheckInstUserLogin(AdminSignUpModelRequest request);
        Task<BaseResponse<AccountResponseModel>> InstAdminUserLogin(AccountModelRequest request);


    }
}