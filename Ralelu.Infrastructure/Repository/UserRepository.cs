using Microsoft.EntityFrameworkCore;
using Ralelu.Domain.Entity;
using Ralelu.Infrastructure.Repository.Interface;

namespace Ralelu.Infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;
        private DbSet<User> _users;

        public UserRepository(AppDbContext context)
        {
            _context = context;
            _users = _context.Users;
        }

        public void Create(User user)
        {
            _users.Add(user);
            _context.SaveChanges();
        }

        public void Delete(User user)
        {
            _users.Remove(user);
            _context.SaveChanges();
        }

        public void DeleteById(int id)
        {
            User current = _users.Where(x => x.Id == id).FirstOrDefault();

            if (current != null)
            {
                _users.Remove(current);
                _context.SaveChanges();
            }
        }

        public IEnumerable<User> GetAll()
        {
            return _users.ToList();
        }

        public User GetById(int id)
        {
            return _users.Where(x => x.Id == id).FirstOrDefault();
        }

        public void Update(User user)
        {
            _context.Update(user);
            _context.SaveChanges();
        }
    }
}
