namespace SCW.Models
{
    public class Employee
    {
    }

    public class EmployeeModelRequest
    {
        public Int64? Id { get; set; }
        public int? EmpTypeId { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? PhoneNumber { get; set; }
        public string? FullName { get; set; }

        public string? Email { get; set; }
        public DateTime? JoiningDate { get; set; }
        public decimal? MonthlySalary { get; set; }
        public string? FatherName { get; set; }
        public string? Specialization { get; set; }
        public string? CNIC { get; set; }
        public string? Education { get; set; }
        public DateTime? DOB { get; set; }
        public int? GenderId { get; set; }
        public string? Religion { get; set; }
        public string? BloodGroup { get; set; }
        public string? Address { get; set; }
        public string? Photo { get; set; }

        [System.Text.Json.Serialization.JsonIgnore]
        public int? OwnerId { get; set; }

        public IFormFile files { get; set; }


    }

    public class EmployeePictureModelRequest
    {
        public Int64? Id { get; set; }
        public string? Photo { get; set; }

        [System.Text.Json.Serialization.JsonIgnore]
        public int? OwnerId { get; set; }

        public IFormFile files { get; set; }


    }

    public class GetEmployeeModelRequest
    {
        public int? currentPage { get; set; }
        public int? recordsPerPage { get; set; }
        public Int64? Id { get; set; }
        public string? Name { get; set; }
        public int? OwnerId { get; set; }

    }
    public class EmployeeModelResult
    {
        public long? Rownumber { get; set; }
        public long? TotalRecords { get; set; }
        public Int64? Id { get; set; }
        public int? EmpTypeId { get; set; }
        public string? UserName { get; set; }
        public string? EmpCode { get; set; }
        public string? EmpType { get; set; }
        public string? Password { get; set; }
        public string? PhoneNumber { get; set; }
        public string? FullName { get; set; }

        public string? Email { get; set; }
        public DateTime? JoiningDate { get; set; }
        public decimal? MonthlySalary { get; set; }
        public string? FatherName { get; set; }
        public string? Specialization { get; set; }
        public string? CNIC { get; set; }
        public string? Education { get; set; }
        public DateTime? DOB { get; set; }
        public int? GenderId { get; set; }
        public string? GenderName { get; set; }
        public string? Religion { get; set; }
        public string? BloodGroup { get; set; }
        public string? Address { get; set; }
        public string? Photo { get; set; }
        public DateTime? CreatedDate { get; set; }
        public bool? IsActive { get; set; }

    }

    public class ClassModelRequest
    {
        public Int64? Id { get; set; }
        public string? ClassName { get; set; }
        public Int64? EmployeeId { get; set; }
        public string? EmployeeName { get; set; }
        public decimal? TutionFee { get; set; }
        public bool? IsActive { get; set; }

        [System.Text.Json.Serialization.JsonIgnore]
        public int? OwnerId { get; set; }



    }

   
    public class GetClassModelRequest
    {
        public int? currentPage { get; set; }
        public int? recordsPerPage { get; set; }
        public Int64? Id { get; set; }
        public string? ClassName { get; set; }
        public int? OwnerId { get; set; }

    }
    public class ClassModelResult
    {
        public long? Rownumber { get; set; }
        public long? TotalRecords { get; set; }
        public Int64? Id { get; set; }
        public string? ClassName { get; set; }
        public Int64? EmployeeId { get; set; }
        public string? EmployeeName { get; set; }
        public decimal? TutionFee { get; set; }
        public bool? IsActive { get; set; }

    }

}
