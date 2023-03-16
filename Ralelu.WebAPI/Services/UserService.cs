using AutoMapper;
using Ralelu.Domain.Entity;
using Ralelu.Infrastructure.Repository.Interface;
using Ralelu.WebAPI.Arguments.In.User;
using Ralelu.WebAPI.Arguments.Out.User;
using Ralelu.WebAPI.Services.Interfaces;

namespace Ralelu.WebAPI.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public UserOut Create(UserCreate userCreate)
        {
            User user = new User(userCreate.Name, userCreate.email);
            _userRepository.Create(user);

            return _mapper.Map<UserOut>(user);
        }

        public bool Delete(int id)
        {
            User user = _userRepository.GetById(id);

            if (user == null)
            {
                return false;
            }

            _userRepository.Delete(user);

            return true;
        }

        public IEnumerable<UserOut> GetAll()
        {
            return _userRepository.GetAll().Select(x => _mapper.Map<UserOut>(x));
        }

        public UserOut GetById(int id)
        {
            User user = _userRepository.GetById(id);

            if (user == null)
            {
                return null;
            }

            return _mapper.Map<UserOut>(user);
        }

        public UserOut Update(UserCreate userCreate, int id)
        {
            User user = _userRepository.GetById(id);

            if (user == null)
            {
                return null;
            }

            user.Update(userCreate.Name, userCreate.email);
            _userRepository.Update(user);

            return _mapper.Map<UserOut>(user);
        }
    }
}
