namespace SCW.Models
{
    public class AccountModel
    {

    }
    public class AccountModelRequest
    {
        public string? UserName { get; set; }
        public string? Password { get; set; }


    }
    public class AdminSignUpModelRequest
    {
        public string? Name { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }


    }
    public class AccountModelResult
    {
        public int? UserId { get; set; }
        public int? ParentUserId { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? FullName { get; set; }
        public int? StatusFkId { get; set; }
        public string? PasswordHash { get; set; }
        public string? SecurityStamp { get; set; }
        public int? ResponseCode { get; set; }
        public string? ResponseMessage { get; set; }
        

    }
    public class AccountResponseModel
    {
        public AccountResponseModel()
        {
            userLists= new List<UserList>();
        }
        public List<UserList> userLists { get; set; }
        public string id_token {get;set;}
        public bool IsSAdmin { get; set; }
        public bool IsInstLoginPage { get; set; }
    }


    public class UserList
    {
      
        public int? UserId { get; set; }
        public int? ParentUserId { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? FullName { get; set; }
        public int? StatusFkId { get; set; }


    }

    public class CustomerModelRequest
    {
        public string? UserName { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public Guid? UserType { get; set; }
        public string? UserAccount { get; set; }

    }
    public class CompanyModelRequest 
    {
        public string? FullName { get; set; }
        public string? Site { get; set; }
        public string? Domain { get; set; }
        public string? SocialLink { get; set; }
        public string? ShortDescription { get; set; }
        public string? DateOfRegistration { get; set; }
        public string? PlaceOfRegistration { get; set; }
        public string? UserAccount { get; set; }
        public IFormFile files { get; set; }
        public string? Attachment { get; set; }
    }
}
