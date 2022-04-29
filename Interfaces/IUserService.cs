using CRUD_WEB_API.Models;

namespace CRUD_WEB_API.Services
{
    public interface IUserService
    {
        string Authenticate(AuthenticateRequest model);
        Task<bool> Register(UserDTO userModel);
        IEnumerable<User> GetAll();
        User GetById(int id);
        Task<bool> RegisterToMeetUp(int userId, int meetupId);
    }
}