using AutoMapper;
using Ralelu.Domain;
using Ralelu.Domain.Entity;
using Ralelu.WebAPI.Arguments.In.User;
using Ralelu.WebAPI.Arguments.Out.User;
using Ralelu.WebAPI.Services.Interfaces;

namespace Ralelu.WebAPI.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public UserOut Create(UserCreate userCreate)
        {
            User user = new User(userCreate.Name, userCreate.email);
            _unitOfWork.UserRepository.Add(user);
            _unitOfWork.Commit();

            return _mapper.Map<UserOut>(user);
        }

        public bool Delete(int id)
        {
            User user = _unitOfWork.UserRepository.Get(x => x.Id == id);

            if (user == null)
            {
                return false;
            }

            _unitOfWork.UserRepository.Remove(user);
            _unitOfWork.Commit();

            return true;
        }

        public IEnumerable<UserOut> GetAll()
        {
            return _unitOfWork.UserRepository.GetAllWithPosts().Select(x => _mapper.Map<UserOut>(x));
        }

        public UserOut GetById(int id)
        {
            User user = _unitOfWork.UserRepository.Get(x => x.Id == id);

            if (user == null)
            {
                return null;
            }

            return _mapper.Map<UserOut>(user);
        }

        public UserOut Update(UserCreate userCreate, int id)
        {
            User user = _unitOfWork.UserRepository.Get(x => x.Id == id);

            if (user == null)
            {
                return null;
            }

            user.Update(userCreate.Name, userCreate.email);
            _unitOfWork.UserRepository.Update(user);
            _unitOfWork.Commit();

            return _mapper.Map<UserOut>(user);
        }
    }
}
