using SCW.Models.BaseClass;
using SCW.Models;

namespace SCW.Services
{
    public interface IEmployeeService
    {
        Task<BaseResponse<NoResult>> AddEmployee(EmployeeModelRequest request);
        Task<BaseResponse<EmployeeModelResult>> GetEmployeeList(GetEmployeeModelRequest request);
        Task<BaseResponse<NoResult>> UploadEmpPicture(EmployeePictureModelRequest request);
        Task<BaseResponse<NoResult>> AddClass(ClassModelRequest request);
        Task<BaseResponse<ClassModelResult>> GetClassList(GetClassModelRequest request);
    }
}
