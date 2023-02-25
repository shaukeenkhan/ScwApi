using SCW.Models.BaseClass;
using SCW.Models;

namespace SCW.Services
{
    public interface IHomeService
    {
        Task<BaseResponse<NoResult>> InsertUpdateInstitute(InstituteModelRequest request);
        Task<BaseResponse<InstituteModelResult>> GetInstitute(GetInstituteModelRequest request);
        Task<BaseResponse<NoResult>> UpdateBankInfo(BankInfoModelRequest request);
        Task<BaseResponse<DropDownResult>> GetDropdownList(DropDownRequest request);
       
    }
}
