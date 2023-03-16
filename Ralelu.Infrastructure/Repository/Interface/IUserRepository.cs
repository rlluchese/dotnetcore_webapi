using Ralelu.Domain.Entity;

namespace Ralelu.Infrastructure.Repository.Interface
{
    public interface IUserRepository
    {
        void Create(User user);
        IEnumerable<User> GetAll();
        User GetById(int id);
        void Delete(User user);
        void DeleteById(int id);
        void Update(User user);
    }
}
