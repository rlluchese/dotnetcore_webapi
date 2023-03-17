using Ralelu.Domain.Entity;

namespace Ralelu.Domain.Repository
{
    public interface IPostRepository : IGenericRepository<Post>
    {
        IEnumerable<Post> GetAllWithUser();
    }
}
