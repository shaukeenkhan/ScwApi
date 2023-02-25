using SCW.Models.BaseClass;
using SCW.Models;

namespace SCW.Services.SuperAdmin
{
    public interface ISuperAccountService
    {
        Task<BaseResponse<AccountResponseModel>> UserLogin(AccountModelRequest request);
    }
}
