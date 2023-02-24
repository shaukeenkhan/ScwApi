using SCW.Models;

namespace SCW.Services
{
    public interface ITokenService
    {

    


        public string BuildIdToken( UserDTO user);
        public string BuildAccessToken( UserDTO user);
        public bool IsTokenValid(string token);
    }
}