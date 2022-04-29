using CRUD_WEB_API.DTO;

namespace CRUD_WEB_API.Interfaces
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