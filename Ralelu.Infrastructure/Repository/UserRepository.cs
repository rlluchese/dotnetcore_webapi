using Ralelu.Domain.Entity;
using Ralelu.Domain.Repository;
using Ralelu.Infrastructure.Base;

namespace Ralelu.Infrastructure.Repository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context)
        {

        }
    }
}
