using AutoMapper;
using CRUD_WEB_API.Helpers;
using CRUD_WEB_API.DTO;

namespace CRUD_WEB_API.Interfaces
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<MeetUp> _meetupRepository;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public UserService(IRepository<User> userRepository,
                           IRepository<MeetUp> meetupRepository,
                           IConfiguration configuration,
                           IMapper mapper)
        {
            _meetupRepository = meetupRepository;
            _userRepository = userRepository;
            _configuration = configuration;
            _mapper = mapper;
        }

        public string Authenticate(AuthenticateRequest model)
        {
            var user = _userRepository
                .GetAll()
                .FirstOrDefault(x => x.Username == model.Username &&
                                     x.Password == model.Password);

            if (user is null)
            {
                return null;
            }

            var token = _configuration.GenerateJwtToken(user);

            return token;
        }

        public async Task<bool> Register(UserDTO userModel)
        {
            var user = _mapper.Map<User>(userModel);
            var existingUser = _userRepository
                .GetAll()
                .FirstOrDefault((userBd) => userBd.Username == user.Username);
            if (existingUser is not null)
            {
                return false;
            }

            await _userRepository.Create(user);
            return true;
        }

        public IEnumerable<User> GetAll()
        {
            return _userRepository.GetAll();
        }

        public User GetById(int id)
        {
            return _userRepository.GetById(id);
        }

        public async Task<bool> RegisterToMeetUp(int userId, int meetupId)
        {
            var user = _userRepository.GetById(userId);
            var meetUp = _meetupRepository.GetById(meetupId);
            meetUp.Users.Add(user);
            await _meetupRepository.SaveChangesAsync();

            return true;
        }
    }
}