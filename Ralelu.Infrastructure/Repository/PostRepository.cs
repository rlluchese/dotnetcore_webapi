using Microsoft.EntityFrameworkCore;
using Ralelu.Domain.Entity;
using Ralelu.Domain.Repository;
using Ralelu.Infrastructure.Base;

namespace Ralelu.Infrastructure.Repository
{
    public class PostRepository : GenericRepository<Post>, IPostRepository
    {
        public PostRepository(AppDbContext context) : base(context)
        {
        }

        public IEnumerable<Post> GetAllWithUser()
        {
            return _dbSet.Include(x => x.User).AsEnumerable();
        }
    }
}
