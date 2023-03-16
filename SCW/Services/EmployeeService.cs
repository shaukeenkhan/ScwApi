using Newtonsoft.Json;
using SCW.Enums;
using System.Data;
using DataTableExtensions = SCW.common.DataTableExtension;
using SCW.Models;
using SCW.Models.BaseClass;
using SCW.uow;
using SCW.common;
using System.Net;

namespace SCW.Services
{
    public class EmployeeService : IEmployeeService
    {
        private IUnitOfWork _unitOfWork { get; set; }
        private IConfiguration _configuration;
        private Microsoft.AspNetCore.Hosting.IHostingEnvironment _hostingEnvironment;
        public EmployeeService(IUnitOfWork unitOfWork, IConfiguration configuration, Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
            _hostingEnvironment = hostingEnvironment;
        }

        public async Task<BaseResponse<NoResult>> AddEmployee(EmployeeModelRequest request)
        {
            BaseResponse<NoResult> response = new BaseResponse<NoResult>();
            try
            {
                var cryptpass = EncryptDecrypt.encrypt(request.Password.Trim());
                var target = Path.Combine(_hostingEnvironment.ContentRootPath, "Document");
                Directory.CreateDirectory(target);


                if (request.files != null)
                {
                    request.Photo = DataTableExtensions.GetUniqueFileName(request.files.FileName);
                    var filePath = Path.Combine(target, request.Photo);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await request.files.CopyToAsync(stream);
                    }
                }


                string[] paramName = { "@Id", "@EmpTypeId", "@UserName", "@Password", "@PhoneNumber", "@FullName", "@Email"
                ,"@JoiningDate","@MonthlySalary","@FatherName","@Specialization","@CNIC","@Education","@DOB","@GenderId","@Religion"
                ,"@BloodGroup","@Address","@Photo","@OwnerId"};
                DataTable dt = this._unitOfWork.GetDataFromStoredProcedure("[dbo].[PROC_ADD_EMPLOYEE]", paramName, request.Id, request.EmpTypeId, request.UserName
                    , cryptpass, request.PhoneNumber, request.FullName, request.Email, request.JoiningDate, request.MonthlySalary
                    , request.FatherName, request.Specialization, request.CNIC, request.Education, request.DOB, request.GenderId
                    , request.Religion, request.BloodGroup, request.Address,request.Photo, request.OwnerId);

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

        public async Task<BaseResponse<EmployeeModelResult>> GetEmployeeList(GetEmployeeModelRequest request)
        {
            BaseResponse<EmployeeModelResult> baseResponse = new BaseResponse<EmployeeModelResult>();
            try
            {
                string[] param = { "@currentPage", "@recordsPerPage","@Id", "@Name", "@OwnerId" };
                DataTable dt = this._unitOfWork.GetDataFromStoredProcedure("[dbo].[PROC_GET_EMPLOYEELIST]", param, request.currentPage, request.recordsPerPage, request.Id, request.Name,request.OwnerId);

                if (dt.Rows.Count > 0)
                {

                    List<EmployeeModelResult> result = DataTableExtension.ToList<EmployeeModelResult>(dt);
                    result = result.Select(x => new EmployeeModelResult
                    {
                        TotalRecords = x.TotalRecords,
                        Id = x.Id,
                        EmpTypeId = x.EmpTypeId,
                        EmpType = x.EmpType,
                        EmpCode = x.EmpCode,
                        UserName = x.UserName,
                        PhoneNumber = x.PhoneNumber,
                        FullName = x.FullName,
                        Email = x.Email,
                        JoiningDate = x.JoiningDate,
                        MonthlySalary=x.MonthlySalary,
                        Photo=x.Photo,
                        FatherName=x.FatherName,
                        Specialization=x.Specialization,
                        CNIC=x.CNIC,
                        Education=x.Education,
                        DOB=x.DOB,
                        GenderId=x.GenderId,
                        GenderName=x.GenderName,
                        Religion=x.Religion,
                        BloodGroup=x.BloodGroup,
                        Address=x.Address,
                        CreatedDate = x.CreatedDate

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

        public async Task<BaseResponse<NoResult>> UploadEmpPicture(EmployeePictureModelRequest request)
        {
            BaseResponse<NoResult> response = new BaseResponse<NoResult>();
            try
            {

                var target = Path.Combine(_hostingEnvironment.ContentRootPath, "Document");
                Directory.CreateDirectory(target);


                if (request.files != null)
                {
                    request.Photo = DataTableExtensions.GetUniqueFileName(request.files.FileName);
                    var filePath = Path.Combine(target, request.Photo);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await request.files.CopyToAsync(stream);
                    }
                }

                string[] paramName = { "@Id", "@Photo", "@OwnerId"};
                DataTable dt = this._unitOfWork.GetDataFromStoredProcedure("[dbo].[PROC_UPDATE_PHOTO_EMPLOYEE]", paramName, request.Id, request.Photo,request.OwnerId);

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


        public async Task<BaseResponse<NoResult>> AddClass(ClassModelRequest request)
        {
            BaseResponse<NoResult> response = new BaseResponse<NoResult>();
            try
            {

                string[] paramName = { "@Id", "@EmployeeId", "@ClassName", "@TutionFee","@OwnerId"};
                DataTable dt = this._unitOfWork.GetDataFromStoredProcedure("[dbo].[PROC_ADD_CLASS]", paramName, request.Id, request.EmployeeId
                    , request.ClassName, request.TutionFee,request.OwnerId);

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

        public async Task<BaseResponse<ClassModelResult>> GetClassList(GetClassModelRequest request)
        {
            BaseResponse<ClassModelResult> baseResponse = new BaseResponse<ClassModelResult>();
            try
            {
                string[] param = { "@currentPage", "@recordsPerPage", "@Id", "@ClassName", "@OwnerId" };
                DataTable dt = this._unitOfWork.GetDataFromStoredProcedure("[dbo].[PROC_GET_CLASS_LIST]", param, request.currentPage, request.recordsPerPage, request.ClassName, request.OwnerId);

                if (dt.Rows.Count > 0)
                {

                    List<ClassModelResult> result = DataTableExtension.ToList<ClassModelResult>(dt);
                    result = result.Select(x => new ClassModelResult
                    {
                        TotalRecords = x.TotalRecords,
                        Id = x.Id,
                        ClassName = x.ClassName,
                        EmployeeId = x.EmployeeId,
                        EmployeeName = x.EmployeeName,
                        TutionFee = x.TutionFee,
                        IsActive = x.IsActive,

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
