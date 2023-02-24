namespace SCW.Models
{
    public class UserDTO
    {
        public int? Id { get; set; }
        public int? ParentUserId { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }

       // public Guid? Role { get; set; }
       
        //public string Account { get; set; }
        public int? StatusFkId { get; set; }
        
        //public bool? IsAdmin { get; set; }
    }
}
