using System.Runtime.Serialization;

namespace SCW.Models
{
    public class MastersModel
    {

    }


    public class InstituteModelRequest
    {
        public Int64? Id { get; set; }
        public string? Name { get; set; }
        public string? TargetLine { get; set; }
        public string? PhoneNo { get; set; }
        public string? Website { get; set; }
        public int? CountryId { get; set; }
        public int? StateId { get; set; }
        public int? CityId { get; set; }
        public string? ZipCode { get; set; }
        public string? Address { get; set; }
        public string? Logo { get; set; }
        [System.Text.Json.Serialization.JsonIgnore]
        public int? OwnerId { get; set; }

        public IFormFile files { get; set; }


    }
    public class GetInstituteModelRequest
    {
        [System.Text.Json.Serialization.JsonIgnore]
        public int? OwnerId { get; set; }
    }
    public class InstituteModelResult
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public string? TargetLine { get; set; }
        public string? PhoneNo { get; set; }
        public string? Website { get; set; }
        public int? CountryId { get; set; }
        public int? StateId { get; set; }
        public int? CityId { get; set; }
        public string? ZipCode { get; set; }
        public string? Address { get; set; }
        public string? Logo { get; set; }

        [System.Text.Json.Serialization.JsonIgnore]
        public int? OwnerId { get; set; }

        public string? CountryName { get; set; }
        public string? StateName { get; set; }
        public string? CityName { get; set; }
    }


    public class BankInfoModelRequest
    {
        public Int64? Id { get; set; }
        public string? Name { get; set; }
        public string? BankName { get; set; }
        public string? AccountNo { get; set; }
        public string? BranchName { get; set; }
     
        public string? BankLogo { get; set; }
        [System.Text.Json.Serialization.JsonIgnore]
        public int? OwnerId { get; set; }

        public IFormFile files { get; set; }


    }
    public class GetBankInfoModelRequest
    {
        [System.Text.Json.Serialization.JsonIgnore]
        public int? OwnerId { get; set; }
    }
    public class BankInfoModelResult
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public string? BankName { get; set; }
        public string? AccountNo { get; set; }
        public string? BranchName { get; set; }
        public string? BankLogo { get; set; }
        public bool? IsDefault { get; set; }
        public bool? IsActive { get; set; }

        [System.Text.Json.Serialization.JsonIgnore]
        public int? OwnerId { get; set; }

    }

    public class GetUserListModelRequest
    {
        public int? currentPage { get; set; }
        public int? recordsPerPage { get; set; }
        public string? UserName { get; set; }
        
    }
    public class UserListModelResult
    {
        public long? Rownumber { get; set; }
        public long? TotalRecords { get; set; }
        public int? Id { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? UserName { get; set; }
        public string? FullName { get; set; }
        public int? StatusFkId { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? ParentUserId { get; set; }

       
    }




    public class TeamsModelRequest
    {
        public string? Flag { get; set; }
        public int? Id { get; set; }
        public Guid? CompanyId { get; set; }
        public int? DirectorId { get; set; }
        public int? BeneficiaryId { get; set; }
        public int? AuthorisedPersonId { get; set; }
        public bool? IsActive { get; set; }


    }
    public class GetTeamsModelRequest
    {
        public int? currentPage { get; set; }
        public int? recordsPerPage { get; set; }
        public Guid? CompanyId { get; set; }
    }
    public class GetTeamsModelResult
    {
        public long? TotalRecords { get; set; }
        public long? Rownumber { get; set; }
        public int? Id { get; set; }
        public Guid? CompanyId { get; set; }

        public int? DirectorId { get; set; }
        public int? BeneficiaryId { get; set; }
        public int? AuthorisedPersonId { get; set; }
        public bool? IsActive { get; set; }

        public string? Director { get; set; }
        public string? Beneficiary { get; set; }
        public string? AuthorisedPerson { get; set; }



    }
    public class AdvisorsModelRequest
    {
        public string? Flag { get; set; }
        public int? Id { get; set; }
        public Guid? CompanyId { get; set; }
        public int? DocumentTypeId { get; set; }
        public string? DocumentId { get; set; }
        public string? FullName { get; set; }
        public string? DOB { get; set; }
        public string? Nationality { get; set; }
        public string? ResidenceNationality { get; set; }
        public int? AllocatePercentage { get; set; }
        public bool? IsActive { get; set; }


    }
    public class GetAdvisorsModelRequest
    {
        public int? currentPage { get; set; }
        public int? recordsPerPage { get; set; }
        public Guid? CompanyId { get; set; }
    }
    public class AdvisorsModelResult
    {
        public long? TotalRecords { get; set; }
        public long? Rownumber { get; set; }
        public int? Id { get; set; }
        public Guid? CompanyId { get; set; }
        public int? DocumentTypeId { get; set; }
        public string? DocumentType { get; set; }
        public string? DocumentId { get; set; }
        public string? FullName { get; set; }
        public string? DOB { get; set; }
        public string? Nationality { get; set; }
        public string? ResidenceNationality { get; set; }
        public int? AllocatePercentage { get; set; }
        public bool? IsActive { get; set; }




    }
    public class PartnersModelRequest
    {
        public string? Flag { get; set; }
        public int? Id { get; set; }
        public Guid? CompanyId { get; set; }
        public string? FullName { get; set; }
        public string? Link { get; set; }
        public string? ShortDescription { get; set; }
        public bool? IsActive { get; set; }
        public string? Logo { get; set; }
        public IFormFile files { get; set; }

    }
    public class GetPartnersModelRequest
    {
        public int? currentPage { get; set; }
        public int? recordsPerPage { get; set; }
        public Guid? CompanyId { get; set; }
    }
    public class GetPartnersModelResult
    {
        public long? TotalRecords { get; set; }
        public long? Rownumber { get; set; }
        public int? Id { get; set; }
        public Guid? CompanyId { get; set; }
        public string? FullName { get; set; }
        public string? Link { get; set; }
        public string? ShortDescription { get; set; }
        public string? Logo { get; set; }
        public bool? IsActive { get; set; }



    }

    public class DropDownRequest
    {
        public string Flag { get; set; }
        public int? OptionId { get; set; }
        public int? OptionId2 { get; set; }
    }
    public class DropDownResult
    {
        public int Value { get; set; }
        public string Text { get; set; }
    }

    public class InvestorModelRequest
    {
        public string? Flag { get; set; }
        public string? Id { get; set; }
        public Guid? CompanyId { get; set; }
        public string? Name { get; set; }
        public string? EmailId { get; set; }
        public string? WalletAddress { get; set; }
        public bool? IsActive { get; set; }
        public List<InvestorList> tblInvestorType { get; set; }


    }
    public class InvestorList
    {
        public string? Name { get; set; }
        public string? EmailId { get; set; }
        public string? WalletAddress { get; set; }


    }
    public class GetInvestorModelRequest
    {
        public int? currentPage { get; set; }
        public int? recordsPerPage { get; set; }
        public Guid? CompanyId { get; set; }
    }
    public class GetInvestorModelResult
    {
        public long? TotalRecords { get; set; }
        public long? Rownumber { get; set; }
        public Guid? Id { get; set; }
        public Guid? CompanyId { get; set; }
        public string? Name { get; set; }
        public string? EmailId { get; set; }
        public string? WalletAddress { get; set; }
        public bool? IsActive { get; set; }



    }
}
